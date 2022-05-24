using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoving : MonoBehaviour
{
    //[Order("Cam1")]
    [ShowOnly] public float frame = 0;
    [Space(10)]
    [Header("Camera 1 Settings")]
    [SerializeField] GameObject Cam1;
    [Range(0, 300)]
    [SerializeField] int MaxMovementFrame1;
    [SerializeField] float Cam1_VectorX;
    [SerializeField] float Cam1_VectorZ;
    [Space(10)]
    [Header("Camera 2 Settings")]
    [SerializeField] GameObject Cam2;
    [Range(0,600)]
    [SerializeField] int MaxMovementFrame2;
    [SerializeField] float Cam2_VectorX;
    [SerializeField] float Cam2_VectorZ;
    [Space(10)]
    [Header("Camera 3 Settings")]
    [SerializeField] GameObject Cam3;
    [Range(0,900)]
    [SerializeField] int MaxMovementFrame3;
    [SerializeField] float Cam3_VectorX;
    [SerializeField] float Cam3_VectorZ;
    [Space(10)]
    [Header("Camera 4 Settings")]
    [SerializeField] GameObject Cam4;
    [Range(0, 1200)]
    [SerializeField] int MaxMovementFrame4;
    [SerializeField] float Cam4_VectorX;
    [SerializeField] float Cam4_VectorZ;
    [Space(10)]
    [Header("Camera 5 Settings")]
    [SerializeField] GameObject Cam5;
    [Range(0, 1500)]
    [SerializeField] int MaxMovementFrame5;
    [SerializeField] float Cam5_VectorX;
    [SerializeField] float Cam5_VectorZ;

    void Start()
    {
        Cam1.SetActive(true);
        Cam2.SetActive(false);
        Cam3.SetActive(false);
        Cam4.SetActive(false);
        Cam5.SetActive(false);
    }

    void FixedUpdate()
    {
        frame++;
        CamTimer();
    }

    void CamTimer()
    {
        if (frame >= 0 && frame <= MaxMovementFrame1)
        {
            Cam1.GetComponent<Transform>().position = Cam1.GetComponent<Transform>().position + new Vector3(Cam1_VectorX * -0.001f, 0, -0.001f * Cam1_VectorZ);
            if (frame == MaxMovementFrame1)
            {
                Cam1.SetActive(false);
                Cam2.SetActive(true);
            }
        }
        if (((frame >= MaxMovementFrame1) && (frame <= MaxMovementFrame2)))
        {
            Cam2.GetComponent<Transform>().position = Cam2.GetComponent<Transform>().position + new Vector3(Cam2_VectorX * -0.001f, 0, -0.001f * Cam2_VectorZ);
            if (frame == MaxMovementFrame2)
            {
                Cam2.SetActive(false);
                Cam3.SetActive(true);
            }
        }
        if ((frame >= MaxMovementFrame2 && frame <= MaxMovementFrame3))
        {
            Cam3.GetComponent<Transform>().position = Cam3.GetComponent<Transform>().position + new Vector3(Cam3_VectorX * -0.001f, 0, -0.001f * Cam3_VectorZ);
            if (frame == MaxMovementFrame3)
            {
                Cam3.SetActive(false);
                Cam4.SetActive(true);
            }
        }
        if ((frame >= MaxMovementFrame3 && frame <= MaxMovementFrame4))
        {
            Cam4.GetComponent<Transform>().position = Cam4.GetComponent<Transform>().position + new Vector3(Cam4_VectorX * -0.001f, 0, -0.001f * Cam4_VectorZ);
            if (frame == MaxMovementFrame4)
            {
                Cam4.SetActive(false);
                Cam5.SetActive(true);
            }
        }
        
        if ((frame >= MaxMovementFrame4))
        {
            Cam5.GetComponent<Transform>().position = Cam5.GetComponent<Transform>().position + new Vector3(Cam5_VectorX * -0.001f, 0, -0.001f * Cam5_VectorZ);
            if (frame == MaxMovementFrame5)
            {
                Cam5.SetActive(false);
                Cam1.SetActive(true);
                frame = 0;
            }
        }
    }
}


