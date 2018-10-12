using System;
using UnityEngine;
using System.Collections;
//using Debug = System.Diagnostics.Debug;

        
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float speedMultiplier;
    private float startSpeed;

    public float speedIncreaseMilestone;
    private float speedMilestoneCount;
    private float startSpeedMilestoneCount;

    public float jumpForce;

    public float jumpTime;
    private float jumpTimeCounter;

    private Rigidbody2D myRigidBody;

    public bool grounded;
    public Transform groundCheck;
    private bool hasJumped = false;
    private bool canDoubleJump;

    public LayerMask whatIsGround;
    public float groundedRadius;

    private Animator myAnimator;

    public GameManager gameManager;



	void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;

        startSpeed = moveSpeed;
        startSpeedMilestoneCount = speedMilestoneCount;
    }
	
	
    // Raycast and Speed update
	void Update ()
	{
        Vector2 man = new Vector2(transform.position.x -0.2f , transform.position.y);
	    RaycastHit2D hit = Physics2D.Raycast(man, Vector2.down, 1.5f, whatIsGround);
        grounded = hit;

        if(transform.position.x > speedIncreaseMilestone)
        {
            moveSpeed = moveSpeed * speedMultiplier;

            speedIncreaseMilestone += 50;

            
        }
        

        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
        //Jump + double jump
        
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                hasJumped = true;
                canDoubleJump = true;  
            }
            else if(!grounded && canDoubleJump)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                hasJumped = true;
                jumpTimeCounter = jumpTime;
                canDoubleJump = false;

            }
        }

        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
        
            if(jumpTimeCounter > 0 && hasJumped)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

	

        myAnimator.SetFloat("Speed", myRigidBody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);

	}
    //Death
    void OnCollisionEnter2D(Collision2D other)
    {
  
        if(other.gameObject.tag == "killbox")
        {
            gameManager.RestartGame();
            moveSpeed = startSpeed;
            speedMilestoneCount = startSpeedMilestoneCount;
        }
    }
}
