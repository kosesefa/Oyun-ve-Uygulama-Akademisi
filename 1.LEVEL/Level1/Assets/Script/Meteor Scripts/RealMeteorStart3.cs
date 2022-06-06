using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMeteorStart3 : MonoBehaviour
{
    public static bool otisEnter3 = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            otisEnter3 = true;

    }
}
