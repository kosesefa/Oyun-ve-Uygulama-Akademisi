using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnTrigger : MonoBehaviour
{
   
    public GameObject door;
    public GameObject doorBoxCollider;
    public GameObject doorLight;
    public Animator _animator;
    //private Animation _animaton;

   

    private void Start()
    {    
        door.GetComponent<BoxCollider>().enabled = false;        
        doorBoxCollider.GetComponent<BoxCollider>().enabled = true;
        

    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Key"))
        { 
            door.GetComponent<BoxCollider>().enabled = true;
            doorBoxCollider.GetComponent<BoxCollider>().enabled = false; 
            doorLight.SetActive(true);
            
            _animator.SetBool("isLightOut",true);
            _animator.SetBool("isLightIn",false); 

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            door.GetComponent<BoxCollider>().enabled = false;
            doorBoxCollider.GetComponent<BoxCollider>().enabled = true; 
            
           _animator.SetBool("isLightIn",true);
            _animator.SetBool("isLightOut",false);
            //doorLight.SetActive(false);
            
        }
            
            
    }
        
    }

