using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour
{

    public GameObject platformDestructionPoint;
    
	void Start ()
    {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
	}


	void Update ()
    {
        //set platforms unActive
	    if(transform.position.x < platformDestructionPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
	}
}
