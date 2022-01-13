using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class OpponentBehaviour : MonoBehaviour
{
    // this script makes the opponent look away from time to time
    public float timer;
    public GameObject head;
    //private float rotationSpeed = 10;
    public float rotationAngle;
    public bool countdown;
    public bool lookingForward;

    void Start()
    {
        timer = Random.Range(8, 10);

        countdown = false;
        lookingForward = true;
    }

    void Update()
    {
        LookingAwayTimer();

        if (timer > 1 && timer < 2 && countdown) //head rotates in a specific range of the timer
        {
            head.transform.Rotate(new Vector3(0, 60, 0), Space.World);

            lookingForward = false;
        }

        else if (timer < 1 && countdown)
        {
            StartCoroutine (WaitTurn());
        }
    }
    

    public void LookingAwayTimer() //time the opponents looks forward before turning their head
    {
        if (countdown)
        {
            timer -= Time.deltaTime;
        }
    }

    IEnumerator WaitTurn() //waits before turning the head back
    {
        timer = 0;
        countdown = false;
        
        int waitTime = Random.Range (3, 7); //time the enemy is looking away
        yield return new WaitForSeconds(waitTime);

        head.transform.rotation = Quaternion.Euler(0,0,0); //reset head rotation to zero
            
        timer = Random.Range(5, 10);
        countdown = true;
        lookingForward = true;
    }
}
