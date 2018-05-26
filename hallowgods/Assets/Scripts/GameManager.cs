using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager singleton = null;
    public GameObject inputManagerPreFab;


    private InputManager inputManager;

    private int currentLevel = 0;
    private string currentState = "";


	// Use this for initialization
	void Awake () {
		//make sure there is only one gamamanger
        if(singleton == null)
        {
            singleton = this;
        }
        else if(singleton != this)
        {
            Destroy(this.gameObject);
        }

        //keep singleton between scenes
        DontDestroyOnLoad(this.gameObject);


        inputManager = Instantiate(inputManagerPreFab).GetComponent<InputManager>();
        inputManager.transform.parent = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        checkInput();
	}

    public void shoot()
    {
       // Debug.Log("pow pow");
    }

    public void checkInput()
    {
        inputManager.checkingInput();
    }
}
