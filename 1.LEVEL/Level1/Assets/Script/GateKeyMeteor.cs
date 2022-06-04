using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GateKeyMeteor : MonoBehaviour
{
    CameraShake3 cs;
    // Adjust the speed for the application.
    public float speed;
    public static bool fell = false;

    // The target (cylinder) position.
    private Transform target;
    public Rigidbody rb;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (fell==false)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-0.22f, -34.79f, 404.43f), Time.fixedDeltaTime * speed);
        }
    }
}
