using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{ 
    public float speed;
    
    public Transform startPoint, endPoint;
    
    public float delay;

    private Transform destinationTarget, departTarget;

    private float startTime;

    private float movingLenght;

    bool isWaiting;

    private RedButtonTrigger _redButtonTrigger;


    void Start()
    {
        departTarget = startPoint;
        destinationTarget = endPoint;

        startTime = Time.time;
        movingLenght = Vector3.Distance(departTarget.position, destinationTarget.position);
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();  
    }

    private void Move()
    {
        if (!isWaiting)
        {
            if (Vector3.Distance(transform.position, destinationTarget.position) > 0.01f)
            {
                float distCovered = (Time.time - startTime) * speed;

                float fractionOfMoving = distCovered / movingLenght;

                transform.position = Vector3.Lerp(departTarget.position, destinationTarget.position, fractionOfMoving);

            }
            else
            {
                isWaiting = true;
                StartCoroutine(changeDelay());
            }
        
        }
    }

    void ChangeDestination()
    {
        if (departTarget == endPoint && destinationTarget == startPoint)
        {
            departTarget = startPoint;
            destinationTarget = endPoint;
        }
        else
        {
            departTarget = endPoint;
            destinationTarget = startPoint;
        } 
    }

    IEnumerator changeDelay()
    {
        yield return new WaitForSeconds(delay);
        ChangeDestination();
        startTime = Time.time;
        movingLenght = Vector3.Distance(departTarget.position, destinationTarget.position);
        isWaiting = false;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }
}
