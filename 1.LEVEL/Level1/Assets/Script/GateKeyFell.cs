using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GateKeyFell : MonoBehaviour
{
    public Transform trail;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("girdi");
        if (GateKeyMeteor.fell==false)
        {
            GateKeyMeteor.fell = true;
            trail.DOScale(new Vector3(0, 0, 0), 5);
            Debug.Log("ifin içine girdi");
        }
    }
}
