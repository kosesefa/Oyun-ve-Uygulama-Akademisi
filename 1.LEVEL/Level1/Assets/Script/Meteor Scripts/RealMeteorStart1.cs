using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMeteorStart1 : MonoBehaviour
{
    public static bool otisEnter = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        otisEnter = true;
     
    }
}
