using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private GameManager gameManager;

    // Use this for initialization
    void Awake()
    {
        gameManager = GameManager.singleton;

    }

    // Update is called once per frame
    void Update () {

	}
    public void checkingInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameManager.shoot();
        }
    }

}
