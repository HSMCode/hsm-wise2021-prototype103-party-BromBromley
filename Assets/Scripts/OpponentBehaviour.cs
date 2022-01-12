using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class OpponentBehaviour : MonoBehaviour
{
    public Transform headRotation;
    public float timer;
    public GameObject head;
    private float rotationSpeed = 10;
    public float rotationAngle;
    public bool countdown;
    void Start()
    {
        timer = Random.Range(8, 10);
        countdown = true;
    }

    void Update()
    {
        //tells the opponent to look away once the timer hits zero, but leads to their head spinning uncontrollably instead of facing the front again
        // none of the attempts to fix it have worked so far
        LookingAwayTimer();
        // Debug.Log(timer);


        if (timer > 1 && timer < 5 && countdown) //head rotates, but can't stand still or face the player
        {
            head.transform.Rotate(new Vector3(0, (90 * rotationSpeed) * Time.deltaTime, 0), Space.World);
            Debug.Log("head starts spinning uncontrollably"); //because the timer stays below 0
        }

        // nested loops to rotate the head
        else if (timer < 1 && countdown)
        {
            StartCoroutine (WaitTurn());
            
            // if (timer < -3)
            // {
            //     Debug.Log("timer hit -3");
            //     head.transform.Rotate(new Vector3(0, -90, 0), Space.World);
            //     timer = Random.Range(5, 15);
            // }
        }
        
        // coroutine to rotate the head
        // if (timer > 0) //&& timer <= 1)
        // {
        //     StartCoroutine (wait());
        //     head.transform.Rotate(new Vector3(0, 90, 0), Space.World);
        // }
    }
    

    public void LookingAwayTimer()
    {
        if (countdown)
        {
            timer -= Time.deltaTime; //counting down seconds
        }
    }

    IEnumerator WaitTurn() //waits before turning the head back (not working yet)
    {
        timer = 0;
        countdown = false;
        // reset head rotation to zero
        head.transform.rotation = Quaternion.Euler(0,0,0);
        
        int waitTime = Random.Range (5, 10);
        yield return new WaitForSeconds(waitTime);
            
        Debug.Log("reset counter");
        timer = Random.Range(5, 15);
        countdown = true;
    }
}
