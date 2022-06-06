using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RealMeteor6 : MonoBehaviour
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

        if (fell == false && RealMeteorStart6.otisEnter6 == true)
        {
            rb.useGravity = true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-224.5288F, 94.91963f, 205.1848f), Time.fixedDeltaTime * speed);
        }
    }
}
