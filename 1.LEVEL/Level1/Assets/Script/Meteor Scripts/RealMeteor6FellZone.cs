using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMeteor6FellZone : MonoBehaviour
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
            if (RealMeteor6.fell == false)
            {
                RealMeteor6.fell = true;
                Debug.Log("ifin içine girdi");
            }
        }
    }
}
