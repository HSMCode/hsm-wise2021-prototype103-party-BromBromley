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
        /*lookingAwayTimer();
        Debug.Log(timer);

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
        lookingAwayTimer();
        Debug.Log(timer);


        if (timer <= 0)
        {
            head.transform.Rotate(new Vector3(0, 90, 0) * rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    public void lookingAwayTimer()
    {
        timer -= Time.deltaTime; //counting down seconds
    }

    IEnumerator wait() //waits before turning the head back
        {
            int waitTime = Random.Range (5, 10);
            yield return new WaitForSeconds (waitTime);
            head.transform.Rotate(new Vector3(0, -90, 0) * rotationSpeed * Time.deltaTime, Space.World);
            timer = Random.Range(5, 15);
        }
}
