using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingKid : MonoBehaviour {

    Rigidbody rb;

    public float speed;
    public int maxSpeed;
    Vector3 moveVector = Vector3.forward;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (rb.velocity.magnitude < maxSpeed)
        {
            Debug.Log(rb.velocity.magnitude);
            rb.AddForce(moveVector * speed,ForceMode.Impulse);
        }



	}

}
