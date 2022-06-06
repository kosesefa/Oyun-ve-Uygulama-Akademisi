using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMeteor2FellZone2 : MonoBehaviour
{
    public GameObject meteor;
    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RealMeteor"))
        {
            Debug.Log("girdi");
            if (RealMeteor2.fell == false)
            {
                RealMeteor2.fell = true;
                Debug.Log("ifin içine girdi");
            }
        }
    }
}
