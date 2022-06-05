using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake3 : MonoBehaviour
{
    [SerializeField]public GameObject shakeCam;
    private void Update()
    {
        if (ChessTableTrigger.a7 == true && ChessTableTrigger.c7 == true && ChessTableTrigger.c8 == true && ChessTableTrigger.f1 == true && ChessTableTrigger.h4 == true)
        {
            shakeCam.GetComponent<CinemachineVirtualCamera>().Priority = 15;
            StartCoroutine(shakeDisable());
        }
    }
    IEnumerator shakeDisable()
    {
        yield return new WaitForSeconds(5);
        shakeCam.GetComponent<CinemachineVirtualCamera>().enabled = false;
    }
}



