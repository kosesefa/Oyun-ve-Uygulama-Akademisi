using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMeteorStart2 : MonoBehaviour
{
    public static bool otisEnter2 = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            otisEnter2 = true;
     
    }
}
