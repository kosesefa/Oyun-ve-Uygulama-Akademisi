using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSound : MonoBehaviour
{
    public AudioSource SlimeAudio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Slime")|| other.CompareTag("NPC"))
        {
           SlimeAudio.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Slime") || other.CompareTag("NPC"))
        {
            SlimeAudio.enabled = false; 
        }

    }


}
