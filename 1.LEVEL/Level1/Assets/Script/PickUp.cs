using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public Image Crosshair;
    public float _Distance;
    void Update()
    {
        Vector3 _forward = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Crosshair.color = Color.white;

        if (Physics.Raycast(transform.position,_forward,out hit))
        {
            Debug.DrawLine(transform.position, hit.point,Color.red);
            if (hit.distance<=_Distance && hit.collider.gameObject.tag=="Collectable")
            {
                Crosshair.color = Color.red;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
