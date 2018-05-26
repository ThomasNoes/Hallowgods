using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsAnswers : MonoBehaviour
{

    public bool _isGod;
    public bool _isMarkedGod = false;

    private bool WaitForKey = false;
    private bool RunOnce = false;

    public Sprite Characterimg;

    public string[] characterAnswers;


    int characterAmount;
    int rnd;

    //reference to a object/script with all images and answers

    // Use this for initialization
    void Start()
    {

        if (_isGod)
        {
            //set characterAmount to god characters

        }
        else
        {
            //set characterAmount to childcharacters
        }
        rnd = Random.Range(0, characterAmount);

        //get character img
        // Characterimg = characterarray [rnd]

        //get answer list
        //characterAnswers = characterAnswers Array [rnd]
    }

    // Update is called once per frame
    void Update()
    {

        if (WaitForKey == true && RunOnce == false)
        {
            if (Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("3") || Input.GetKeyDown("4") || Input.GetKeyDown("5"))
            {
                if (Input.GetKeyDown("1"))
                {
                    Debug.Log(characterAnswers[0]);
                }
                if (Input.GetKeyDown("2"))
                {
                    Debug.Log(characterAnswers[1]);
                }
                if (Input.GetKeyDown("3"))
                {
                    Debug.Log(characterAnswers[2]);
                }
                if (Input.GetKeyDown("4"))
                {
                    Debug.Log(characterAnswers[3]);
                }
                if (Input.GetKeyDown("5"))
                {
                    Debug.Log(characterAnswers[4]);
                }
                WaitForKey = false;
                RunOnce = true;
            }

            Debug.Log("Please press a number from 1-5");
        }


    }

    public string currentGuess()
    {
        if (_isMarkedGod)
        {
            return "Changed guess to be Child";
        }
        return "Changed guess to be God";
    }

    public bool GuessedCorrect()
    {
        if (_isGod == true && _isMarkedGod == true)
        {
            return true;
        }
        return false;
    }

    void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0)) {

            if (RunOnce == false)
            {

                WaitForKey = true;
            }
            else
            {
                Debug.Log("You can only ask one question per person");
            }
        }

        if (Input.GetMouseButtonDown(2))
        {
            if (_isMarkedGod == true)
            {
                _isMarkedGod = false;
            } else
            {
                _isMarkedGod = true;
            }

            Debug.Log(currentGuess());
        }
 
    }

}
