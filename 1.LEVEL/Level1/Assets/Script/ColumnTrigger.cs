using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnTrigger : MonoBehaviour
{
   
    public GameObject door;
    public GameObject doorLight;
    private Animator _animator;
    private Animation _animaton;

   

    private void Start()
    {
        door.GetComponent<BoxCollider>().enabled = false;
        
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Key"))
        {
            
            door.GetComponent<BoxCollider>().enabled = true;
            doorLight.SetActive(true);
            _animator.SetTrigger("FadeIn");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Key"))
            door.GetComponent<BoxCollider>().enabled = false;
            _animator.SetTrigger("FadeOut");
            doorLight.SetActive(false);
            
        }
        
    }

