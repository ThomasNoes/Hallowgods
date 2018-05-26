using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driveCar : MonoBehaviour {

    public Transform startTrans;
    public Transform endTrans;
    public float speed;
    public bool otherWay;


    Vector3 forward;

	// Use this for initialization
	void Start () {
        transform.position = startTrans.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z > endTrans.position.z && !otherWay)
        {
            transform.position = startTrans.position;
        }
        if (transform.position.z < endTrans.position.z && otherWay)
        {
            transform.position = startTrans.position;
        }
    }
}
