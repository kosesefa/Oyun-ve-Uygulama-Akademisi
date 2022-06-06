using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMeteor4FellZone : MonoBehaviour
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
            if (RealMeteor4.fell == false)
            {
                RealMeteor4.fell = true;
                Debug.Log("ifin içine girdi");
            }
        }
    }
}
