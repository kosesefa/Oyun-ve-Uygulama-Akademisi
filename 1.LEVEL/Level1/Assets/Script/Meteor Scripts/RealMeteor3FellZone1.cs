using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMeteor3FellZone1 : MonoBehaviour
{
    public GameObject meteor;
    private void Start()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("RealMeteor"))
        {
            Debug.Log("girdi");
            if (RealMeteor3.fell == false)
            {
                RealMeteor3.fell = true;
                Debug.Log("ifin içine girdi");
            }
        }
    }
}
