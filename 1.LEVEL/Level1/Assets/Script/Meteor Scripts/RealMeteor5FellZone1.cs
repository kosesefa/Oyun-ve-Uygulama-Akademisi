using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMeteor5FellZone1 : MonoBehaviour
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
            if (RealMeteor5.fell == false)
            {
                RealMeteor5.fell = true;
                Debug.Log("ifin içine girdi");
            }
        }
    }
}
