using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMeteorStart5 : MonoBehaviour
{
    public static bool otisEnter5 = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            otisEnter5 = true;

    }
}
