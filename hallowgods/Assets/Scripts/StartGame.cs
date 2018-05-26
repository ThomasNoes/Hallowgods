using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    public Button StartBtn;
    public GameObject StartPanel;

    void Start () {

       StartBtn.onClick.AddListener(InitializeGame);

    }
	

	void Update () {
		
	}

    void InitializeGame()
    {

        StartPanel.SetActive(false);

    }

}
