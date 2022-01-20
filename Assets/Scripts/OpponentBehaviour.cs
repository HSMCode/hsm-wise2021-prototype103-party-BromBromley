using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class OpponentBehaviour : MonoBehaviour
{
    // this script makes the opponent look away from time to time
    // attached to opponent body
    public float timer;
    public GameObject head;
    public float rotationAngle;
    public bool countdown;
    public bool lookingForward;
    public bool gotCaught;
    private float timerSeconds;
    private CheatCheck _cheatCheck;
    private PieceController _pieceController;

    void Awake()
    {
        _cheatCheck = FindObjectOfType<CheatCheck>();
        _pieceController = FindObjectOfType<PieceController>();
    }

    void Start()
    {
        timer = Random.Range(8, 10);

        countdown = false;
        lookingForward = true;
        gotCaught = false;
    }

    void Update()
    {
        LookingAwayTimer();

        if (timerSeconds == 0 && countdown && lookingForward == true) //head rotates in a specific range of the timer
        {
            
            StartCoroutine (WaitTurn());

            lookingForward = false;
        }
    }
    

    public void LookingAwayTimer() //time the opponents looks forward before turning their head
    {
        if (countdown)
        {
            timer -= Time.deltaTime;
            timerSeconds = Mathf.FloorToInt(timer % 60f);
        }
    }

    IEnumerator WaitTurn() //waits before turning the head back
    {
        head.transform.Rotate(new Vector3(0, 45, 0), Space.World);
        timer = 0;
        countdown = false;
        gotCaught = false;
        
        int waitTime = Random.Range (1, 4); //time the enemy is looking away
        yield return new WaitForSeconds(waitTime);

        head.transform.rotation = Quaternion.Euler(0,0,90); //reset head rotation to zero
            
        _cheatCheck.perceivedSteps = _pieceController.stepsTaken;
        timer = Random.Range(5, 10);
        countdown = true;
        lookingForward = true;
    }
}
