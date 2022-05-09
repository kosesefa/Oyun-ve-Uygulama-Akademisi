using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class CameraFollowAfter7Sec : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CameraActions");
    }


    IEnumerator CameraActions()
    {

        yield return new WaitForSeconds(ActionCameraPlayTime);
        AnimatedCamera.SetActive(true);
        TPCamera.SetActive(false);

    }

    [SerializeField] public GameObject AnimatedCamera;     
    [SerializeField] public GameObject TPCamera;
    [SerializeField] public float ActionCameraPlayTime;
    
}
