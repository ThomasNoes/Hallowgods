using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTilt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rotate = new Vector3(Screen.height-Input.mousePosition.y/10-120, -(Screen.width/2-Input.mousePosition.x)/50, 0);


        transform.eulerAngles = rotate;
        Debug.Log(Input.mousePosition);
	}
}
