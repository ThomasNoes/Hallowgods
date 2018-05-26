using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCloud : MonoBehaviour {

    public int speed;

    void Update()
    {
        // Rotate the object around its local X axis at 1 degree per second
       // transform.Rotate(Vector3.right * Time.deltaTime);

        // ...also rotate around the World's Y axis
        transform.Rotate(speed * Vector3.up * Time.deltaTime, Space.World);
    }
}
