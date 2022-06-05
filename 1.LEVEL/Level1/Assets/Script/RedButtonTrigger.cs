using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButtonTrigger : MonoBehaviour
{
    public static bool checkmove = false;
    private void Start()
    {
        checkmove = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            checkmove = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        checkmove=false;
    }

}
