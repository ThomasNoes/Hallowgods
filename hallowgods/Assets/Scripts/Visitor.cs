using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Visitor : MonoBehaviour {

    ProtoTypeManager proto;
    public Button Q1;
    public Button Q2;
    public Button Q3;
    public Button Q4;
    public Button candyButton;
    public Sprite childCandy;
    public Sprite godCandy;
    public Button askButton;
    public Text answer;
    string givenAnswer = "";
    int candyLeft;

    AudioSource audioPlayer;
    public AudioClip giveCandy;
    public AudioClip takeCandy;
    public AudioClip paper;
    public AudioClip writing;

    ScrollUp scrollAct;

    public bool _isGod;

    public bool _isMarkedGod = false;

    public Sprite Characterimg;

    public string[] characterAnswers;


    //Jakob stuff
    private bool WaitForKey = false;
    private bool RunOnce = false;
    private bool IsMarked = false;

    int characterAmount;
    int rnd;

    //reference to a object/script with all images and answers

	// Use this for initialization
	void Start () {
        audioPlayer = GetComponent<AudioSource>();

        Q1.onClick.AddListener(OnClickAction1);
        Q2.onClick.AddListener(OnClickAction2);
        Q3.onClick.AddListener(OnClickAction3);
        Q4.onClick.AddListener(OnClickAction4);
        candyButton.onClick.AddListener(OnClickCandy);
        askButton.onClick.AddListener(MakeQuestionsAppear);

        GameObject g = GameObject.FindGameObjectWithTag("Scroll");
        proto = GetComponentInParent<ProtoTypeManager>();


        scrollAct = g.GetComponent<ScrollUp>();

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
        GetComponentInChildren<SpriteRenderer>().sprite = Characterimg;

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void currentGuess()
    {
        _isMarkedGod = !_isMarkedGod;

        SwitchCandyImage();


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

        if (Input.GetMouseButtonDown(0))
        {
            MakeQuestionsAppear();
        }

    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1)){

            currentGuess();
        }
    }

    void Visibility()
    {
        if(_isMarkedGod == true)
        {
            GetComponentInChildren<MeshRenderer>().enabled = true;
        } else {
            GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }

    void OnClickAction1()
    {
        if (IsMarked == true && RunOnce == false)
        {
            PlaySound(writing);
            scrollAct._continue = true;
            answer.text = characterAnswers[0];
            givenAnswer = characterAnswers[0];
            IsMarked = false;
            Q1.interactable = false;
            RunOnce = true;
        }
    }

    void OnClickAction2()
    {
        if (IsMarked == true && RunOnce == false)
        {
            PlaySound(writing);
            scrollAct._continue = true;
            answer.text = characterAnswers[1];
            givenAnswer = characterAnswers[1];
            Q2.interactable = false;
            IsMarked = false;
            RunOnce = true;
        }
    }

    void OnClickAction3()
    {
        if (IsMarked == true && RunOnce == false)
        {
            PlaySound(writing);
            scrollAct._continue = true;
            answer.text = characterAnswers[2];
            givenAnswer = characterAnswers[2];
            Q3.interactable = false;
            IsMarked = false;
            RunOnce = true;
        }
    }

    void OnClickAction4()
    {
        if (IsMarked == true && RunOnce == false)
        {
            PlaySound(writing);
            scrollAct._continue = true;
            answer.text = characterAnswers[3];
            givenAnswer = characterAnswers[3];
            Q4.interactable = false;
            IsMarked = false;
            RunOnce = true;
        }
    }

    void OnClickCandy()
    {
        if (_isMarkedGod)
        {
            _isMarkedGod = !_isMarkedGod;
            SwitchCandyImage();
        }
        else if(!_isMarkedGod && candyLeft > 0)
        {
            _isMarkedGod = !_isMarkedGod;
            SwitchCandyImage();
        }
        proto.DisplayCandyLeft();

    }

    void SwitchCandyImage()
    {
        if (_isMarkedGod)
        {
            PlaySound(giveCandy);
            candyButton.image.sprite = godCandy;
            Debug.Log("You guessed God");
        }
        else
        {
            PlaySound(takeCandy);
            candyButton.image.sprite = childCandy;
            Debug.Log("You guess Child");
        }

    }

    void MakeQuestionsAppear()
    {
        if (RunOnce == false)
        {
            PlaySound(paper);
            scrollAct._continue = true;
            WaitForKey = true;
            Debug.Log("Please choose question");
            proto.DeselectAllVisitors();
            IsMarked = true;

        }
        else
        {
            PlaySound(writing);
            answer.text = givenAnswer;
            Debug.Log("You can only ask one question per person");
        }
    }
    public void SetCandyLeft(int count)
    {
        candyLeft = count;
    }

    public void PlaySound(AudioClip audio)
    {
        audioPlayer.clip = audio;
        audioPlayer.Play();
    }

    public void StopSound()
    {
        audioPlayer.Stop();
    }

    public void SetIsMarkedFalse()
    {
        IsMarked = false;
    }
}
