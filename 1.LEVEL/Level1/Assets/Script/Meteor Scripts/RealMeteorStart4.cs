using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMeteorStart4 : MonoBehaviour
{
    public static bool otisEnter4 = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            otisEnter4 = true;

    }
}
