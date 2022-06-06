using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RealMeteor5 : MonoBehaviour
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

        if (fell == false && RealMeteorStart5.otisEnter5 == true)
        {
            rb.useGravity = true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-69.30943f, 42.88966f, 199.2748f), Time.fixedDeltaTime * speed);
        }
    }
}
