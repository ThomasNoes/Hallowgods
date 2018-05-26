using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleImages : MonoBehaviour {

    Vector3 parentScale;

	// Use this for initialization
	void Start () {
        parentScale = transform.parent.localScale;// GetComponentInParent<GameObject>();
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1 / parentScale.z, 1 / parentScale.y, 1 / parentScale.x));


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
