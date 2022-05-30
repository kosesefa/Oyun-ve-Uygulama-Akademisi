using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrol : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] wayPoints;
    int wayPointIndex;
    Vector3 target;
    
    void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        DestinationUpdate();
    }
   
    void Update()
    {
        if (Vector3.Distance(transform.position,target)<1)
        {
            RepeatWaypointIndex();
            DestinationUpdate();
        }
    }
    void DestinationUpdate()
    {
        target = wayPoints[wayPointIndex].position;
        agent.SetDestination(target);
    }
    void RepeatWaypointIndex()
    {
        wayPointIndex++;
        if (wayPointIndex==wayPoints.Length)
        {
           wayPointIndex = 0;
        }

    }
}
