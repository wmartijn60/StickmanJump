using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoAndStart : MonoBehaviour
{
    private ParticleSystem ps;

    private bool isGrounded = true;

	void Start ()
	{
	    ps = GetComponent<ParticleSystem>();
	    ps.Play();
	}
	
    //particle aan en uitzetter
	void Update ()
	{
	    bool groundCheck = GameObject.Find("Player").GetComponent<PlayerController>().grounded;

        if (isGrounded != groundCheck)
        {
            isGrounded = groundCheck;


            if (!isGrounded)
            {

                ps.Stop();
                ParticleSystem.EmissionModule emit = ps.emission;
                emit.rateOverDistanceMultiplier = 0f;

            }
            else
            {
             
                ps.Play();
                ParticleSystem.EmissionModule emit = ps.emission;
                emit.rateOverDistanceMultiplier = 1f;
            }

        }


	}
}
