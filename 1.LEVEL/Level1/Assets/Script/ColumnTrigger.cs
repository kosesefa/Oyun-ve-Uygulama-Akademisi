using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnTrigger : MonoBehaviour
{
   
    public GameObject door;

    private void Start()
    {
        door.GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            door.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
