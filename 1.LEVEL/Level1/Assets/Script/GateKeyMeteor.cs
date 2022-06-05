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
    public Rigidbody rb;


    void Start()
    {
        rb.useGravity = false;
    }

    void FixedUpdate()
    {

        //CameraShake3.Instance.ShakeCamera(5f, .1f);
        if (fell==false)
        {
            if (ChessTableTrigger.a7 == true && ChessTableTrigger.c7==true && ChessTableTrigger.c8==true && ChessTableTrigger.f1==true && ChessTableTrigger.h4 == true)
            {
                //CameraShake3.Instance.ShakeCamera(77f,10f);
                rb.useGravity=true;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(-6.134393f, -35.33926f, 405.0842f), Time.fixedDeltaTime * speed);

            }
        }
    }
}
