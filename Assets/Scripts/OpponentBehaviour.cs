using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentBehaviour : MonoBehaviour
{
    public Transform headRotation;
    public float timer;
    public GameObject head;
    private float rotationSpeed = 10;
    public float rotationAngle;
    void Start()
    {
        timer = Random.Range(5, 15);
    }

    void Update()
    {
        //tells the opponent to look away once the timer hits zero, but leads to their head spinning uncontrollably instead of facing the front again
        // none of the attempts to fix it have worked so far
        lookingAwayTimer();
        Debug.Log(timer);


        if (timer <= 0) //head rotates, but can't stand still or face the player
        {
            head.transform.Rotate(new Vector3(0, 90, 0) * rotationSpeed * Time.deltaTime, Space.World);
            Debug.Log("head starts spinning uncontrollably"); //because the timer stays below 0
        }

        /* nested loops to rotate the head
        if (timer >= 0 && timer <= 1)
        {
            //StartCoroutine (wait());
            head.transform.Rotate(new Vector3(0, 90, 0) * rotationSpeed * Time.deltaTime, Space.World);
            if (timer <= -3)
            {
                Debug.Log("timer hit -3");
                head.transform.Rotate(new Vector3(0, -90, 0) * rotationSpeed * Time.deltaTime, Space.World);
                timer = Random.Range(5, 15);
            }
        }*/

        /* coroutine to rotate the head
        if (timer >= 0 && timer <= 1)
        {
            //StartCoroutine (wait());
            head.transform.Rotate(new Vector3(0, 90, 0) * rotationSpeed * Time.deltaTime, Space.World);
        }*/
    }

    public void lookingAwayTimer()
    {
        timer -= Time.deltaTime; //counting down seconds
    }

    IEnumerator wait() //waits before turning the head back (not working yet)
        {
            int waitTime = Random.Range (5, 10); 
            yield return new WaitForSeconds (waitTime);
            head.transform.Rotate(new Vector3(0, -90, 0) * rotationSpeed * Time.deltaTime, Space.World);
            timer = Random.Range(5, 15);
        }
}
