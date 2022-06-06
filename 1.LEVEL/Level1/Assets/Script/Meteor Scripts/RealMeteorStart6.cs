using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMeteorStart6 : MonoBehaviour
{
    public static bool otisEnter6 = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            otisEnter6 = true;

    }
}
