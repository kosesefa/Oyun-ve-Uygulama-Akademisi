using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSound : MonoBehaviour
{
    public AudioSource audio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Slime"))
        {
           audio.Play();
        }
    }


}
