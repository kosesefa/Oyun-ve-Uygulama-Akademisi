using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMeteor1FellZone1 : MonoBehaviour
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
            if (RealMeteor1.fell == false)
            {
                RealMeteor1.fell = true;
                Debug.Log("ifin içine girdi");
            }
        }
    }
}
