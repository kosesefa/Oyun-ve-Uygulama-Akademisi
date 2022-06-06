using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RealMeteor1 : MonoBehaviour
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

        if (fell == false && RealMeteorStart1.otisEnter==true)
        {
            rb.useGravity = true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-33.932f, 40.14f, 110.91f), Time.fixedDeltaTime * speed);
        }
    }
}
