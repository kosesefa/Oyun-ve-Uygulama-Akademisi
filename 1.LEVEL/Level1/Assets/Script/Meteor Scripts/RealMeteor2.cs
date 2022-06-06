using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RealMeteor2 : MonoBehaviour
{
    CameraShake3 cs;
    // Adjust the speed for the application.
    public float speed;
    public static bool fell = false;


    // The target (cylinder) position.
    public Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update()
    {

        if (fell == false && RealMeteorStart2.otisEnter2 == true)
        {
            rb.useGravity = true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-39.72008f, 41.32275f, 113.9712f), Time.fixedDeltaTime * speed);
        }
    }
}
