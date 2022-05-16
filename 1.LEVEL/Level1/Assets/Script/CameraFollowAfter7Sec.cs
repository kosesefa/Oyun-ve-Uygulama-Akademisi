using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollowAfter7Sec : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AnimatedCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 97;
        TPCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 98;
        StartCoroutine("CameraActions");  
    }

    IEnumerator CameraActions()
    {

        yield return new WaitForSeconds(ActionCameraPlayTime);
        TPCamera.SetActive(true);
        AnimatedCamera.SetActive(false);
        Debug.Log("Kamera aktiviteleri");

    }

    [SerializeField] public GameObject TPCamera;     
    [SerializeField] public GameObject AnimatedCamera;
    [SerializeField] public float ActionCameraPlayTime;
    
}
