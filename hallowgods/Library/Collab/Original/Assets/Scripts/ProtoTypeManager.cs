using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtoTypeManager : MonoBehaviour {


    public List<GameObject> visitors;
    List<Visitor> scripts = new List<Visitor>();

    public GameObject resEnable;

    int corrects;

    public Button bowlButton;
    bool _StartMoving = false;
    bool _isMoving = false;

    int Totalround = 3;
    int currentRound = 0;
    public  int moveSpeed;
    public int distance;
    float target;

    // Button assignment for enabling them again for next round
    public Button Q1;
    public Button Q2;
    public Button Q3;
    public Button Q4;


    // Use this for initialization
    void Start () {
        bowlButton.onClick.AddListener(OnClickListener);

        for (int i = 1; i < visitors.Count-1; i++)
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
        }
        if (_isMoving)
        {
            Move(target);
        }
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
        }

        
    }

    int CountCorrectGuess()
    {
        int correct=0;

        for (int i = 0; i < visitors.Count; i++)
        {
            if (scripts[i].GuessedCorrect())
            {
                correct++;
            }
        }
        // Add code to change result number here
        corrects = correct;

        return correct;
    }

    void OnClickListener()
    {
        _StartMoving = true;

        Q1.interactable = true;
        Q2.interactable = true;
        Q3.interactable = true;
        Q4.interactable = true;

        if (currentRound == Totalround-1)
        {
            resEnable.SetActive(true);
            Debug.Log(corrects);
        }
 
    }
}
