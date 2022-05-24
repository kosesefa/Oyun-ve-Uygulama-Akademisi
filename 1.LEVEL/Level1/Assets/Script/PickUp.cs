using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public Image Crosshair;

    public float _Distance;             //Max distance between character and object to be able to interact
    public GameObject KeyInHand;

    [SerializeField] public float holdRange;
    private GameObject heldObject;
    public Transform holdParent;
    [SerializeField] float moveForce;

    public float positionDistance;

    [SerializeField] GameObject character;
    [SerializeField] bool pushObject=true;
    [SerializeField] bool pullObject=true;

    
    void Update()
    {
        PickUpYourHand();
        HoldItem();
        bugCheck();
    }

    void PickUpYourHand()
    {
        Vector3 _forward = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Crosshair.color = Color.white;

        if (Physics.Raycast(transform.position, _forward, out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            if (hit.distance <= _Distance && hit.collider.gameObject.tag == "Collectable")
            {
                Crosshair.color = Color.red;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(hit.collider.gameObject);
                    KeyInHand.SetActive(true);
                }
            }
        }
    }

    void HoldItem()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject==null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit, holdRange))
                {
                    PickUpObject(hit.transform.gameObject);
                }
            }
            else
            {
                dropObject();
            }
        }
        if (heldObject!=null)
        {
            MoveObject();
        }
    }
    void PickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 15;
            
            objRig.transform.parent = holdParent;
            heldObject = pickObj;
        }
    }
    void MoveObject()
    {
        if (Vector3.Distance(heldObject.transform.position,holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObject.transform.position);
            heldObject.GetComponent<Rigidbody>().AddForce(moveDirection*moveForce);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && pushObject) // Object push
        {
            holdParent.transform.position = holdParent.transform.position + holdParent.transform.forward;

        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && pullObject) // Object pull
        {
            holdParent.transform.position= holdParent.transform.position -holdParent.transform.forward;

        }
    }
    void dropObject()
    {
        Rigidbody heldRig = heldObject.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;

        heldObject.transform.parent = null;
        heldObject = null;
    }
    void bugCheck()     //Max & Min push-pull distance to avoid bugs
    {
        positionDistance = Vector3.Distance(holdParent.transform.position, character.transform.position);
        if (positionDistance<8f)
        {
            pullObject = false;
        }
        else
        {
            pullObject = true;
        }
        if (positionDistance>11f)
        {
            pushObject = false;
        }
        else
        {
            pushObject = true;
        }
    }
}
