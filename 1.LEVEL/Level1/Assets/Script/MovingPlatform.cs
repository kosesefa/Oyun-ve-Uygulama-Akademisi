using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovingPlatform : MonoBehaviour
{

    public Transform movingPlatform;
    public Transform position1;
    public Transform position2;
    public Transform position3;
    public Vector3 newPosition;
    public string currentState;
    public float speed;
    public float resetTime;
    
    void Start()
    {
        ChangeTarget();
    }
    
    void Update()
    {
        movingPlatform.position = Vector3.Slerp(movingPlatform.position, newPosition, speed * Time.deltaTime);
    }

    void ChangeTarget ()
    {
        if (currentState == "Moving To Position 1")
        {
            currentState = "Moving To Position 2";
            newPosition = position2.position;

        }
        else if (currentState == "Moving To Position 2")
        {
            currentState = "Moving To Position 1";
            newPosition = position1.position;
        }
        else if (currentState == "")
        {
            currentState = "Moving To Position 2";
            newPosition = position2.position;
        }
        
        
        Invoke("ChangeTarget",resetTime);
    }
    
}
