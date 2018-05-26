using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollUp : MonoBehaviour {


    public bool _canScroll;
    public bool _continue = false;

    public float distance;

    Vector3 endPoint = new Vector3(0,160,0);
    Vector3 startPoint = new Vector3(0, 0, 0);
    Vector3 destination;

    int speed = 5;
    float t=0;


    Vector3 current;

	// Use this for initialization
	void Start () {
        destination = startPoint;
        transform.position = destination;
        endPoint.y = distance;
	}
	
	// Update is called once per frame
	void Update () {

        if (_canScroll)
        {
            if (_continue)
            {
                t += speed * Time.deltaTime;

                if (t > 1)
                {
                    t = 1;
                    prepareForNextScroll();
                }
                else if (t<0)
                {
                    t = 0;
                    prepareForNextScroll();
                }

                transform.position = (1 - t) * startPoint + t * endPoint;


                //if (destination.y !=transform.position.y)
                //{
                //    current = transform.position;
                //    current.y += speed;
                //    Debug.Log(current.y);
                //    transform.position = current;
                //}
                //else
                //{
                //    if(destination == endPoint)
                //    {
                //        destination = startPoint;
                //    }
                //    else
                //    {
                //        destination = endPoint;
                //    }
                //    speed *= -1;
                //    _continue = false;
                }

                
            }
        }

    void prepareForNextScroll()
    {
        speed *= -1;
        _continue = false;
    }  



    public void scroll()
    {
        _continue = true;
    }
}
