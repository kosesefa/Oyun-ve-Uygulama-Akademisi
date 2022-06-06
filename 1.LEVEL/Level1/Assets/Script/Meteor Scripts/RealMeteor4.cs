using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RealMeteor4 : MonoBehaviour
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

        if (fell == false && RealMeteorStart4.otisEnter4 == true)
        {
            rb.useGravity = true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.07593918f, 34.72511f, 186.1833f), Time.fixedDeltaTime * speed);
        }
    }
}
