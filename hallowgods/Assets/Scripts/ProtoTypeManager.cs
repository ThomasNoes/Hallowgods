﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProtoTypeManager : MonoBehaviour {


    public List<GameObject> visitors;
    List<Visitor> scripts = new List<Visitor>();

    public GameObject resEnable;

    public Button continueBtn;
    public Button restartBtn;

    public Button bowlButton;
    bool _StartMoving = false;
    bool _isMoving = false;

    public int Totalround;
    int currentRound = 0;
    public  int moveSpeed;
    public int distance;
    float target;

    // Button assignment for enabling them again for next round
    public Button Q1;
    public Button Q2;
    public Button Q3;
    public Button Q4;
    public Text T1;
    public Text candyBowlText;
    public Text candyCountText;
    int candyLeft;
    int candyUsed;
    public int startCandyAmount;

    public AudioClip march;


    // Use this for initialization
    void Start () {

        bowlButton.onClick.AddListener(OnClickListener);
        continueBtn.onClick.AddListener(NextLevel);
        restartBtn.onClick.AddListener(ReloadLevel);

        for (int i = 0; i < visitors.Count; i++)
        {
            scripts.Add(visitors[i].GetComponent<Visitor>());
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (_StartMoving && !_isMoving)
        {
            roundsCount(); // Calls round counting
            target = transform.position.z + distance;
            _isMoving = true;
            scripts[0].PlaySound(march);
        }
        if (_isMoving)
        {
            Move(target);
        }

        candyLeft = CountCandyLeft();
        UpdateDateCandyLeft(candyLeft);
        DisplayCandyLeft();

	}
    public void DisplayCandyLeft()
    {
        if (Totalround == (Totalround - currentRound))
        {
            candyBowlText.text = "Send in the first kids";
        }
        else if (Totalround-1 == currentRound)
        {
            candyBowlText.text = "Hmm.. That was it";
        }
        else
        {
            candyBowlText.text = "Send in more kids";
        }
        candyCountText.text = ""+candyLeft;
    }

    public void UpdateDateCandyLeft(int candy)
    {
        for (int i = 0; i < visitors.Count; i++)
        {
            scripts[i].SetCandyLeft(candy);

        }
    }

    int CountCandyLeft()
    {
        candyUsed = 0;
        for (int i = 0; i < visitors.Count; i++)
        {
            if (scripts[i]._isMarkedGod)
            {
                candyUsed++;
            }
        }
        return (startCandyAmount - candyUsed);
    }

    void roundsCount()
    {
        currentRound++;
        if(currentRound >= Totalround)
        {
            GiveResults();
        }
    }

    void GiveResults()
    {
        CountCorrectGuess();
    }


    void Move(float destination)
    {
        Vector3 target = transform.position;
        target.z = transform.position.z + destination;
        if (transform.position.z <= destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        }
        else
        {
            _isMoving=false;
            _StartMoving = false;
            print("stop moving");
            scripts[0].StopSound();
        }

        
    }

    int CountCorrectGuess()
    {
        int correct = 0;
        int god = 0;

        for (int i = 0; i < visitors.Count; i++)
        {

            if (scripts[i].GuessedCorrect())
            {
                correct++;
            }
        }


        for (int i = 0; i < visitors.Count; i++)
        {

            if (scripts[i]._isGod)
            {
                god++;
            }
        }
        if (correct == god)
        {
        }
        else
        {
            continueBtn.interactable = false;
        }

        T1.text = (correct.ToString() + " of " + god.ToString());
        resEnable.SetActive(true);
        Debug.Log(correct);

        return correct;
    }

    void NextLevel()
    {
        Debug.Log("Next Level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);

    }
    void ReloadLevel()
    {
        Debug.Log("Reload Level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    void OnClickListener()
    {
        _StartMoving = true;

        Q1.interactable = true;
        Q2.interactable = true;
        Q3.interactable = true;
        Q4.interactable = true;
 
    }


    public void DeselectAllVisitors()
    {
        for (int i = 0; i < visitors.Count; i++)
        {

            scripts[i].SetIsMarkedFalse();
        }
    }
}
