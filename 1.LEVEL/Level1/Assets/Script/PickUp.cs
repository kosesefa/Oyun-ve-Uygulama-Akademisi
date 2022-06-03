using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickUp : MonoBehaviour
{
    [Space(15)]
    public Image Crosshair;
    [Space(15)]
    public float _Distance;             //Max distance between character and object to be able to interact
    public GameObject KeyInHand;
    [Space(15)]
    [SerializeField] public float holdRange;
    private GameObject heldObject;
    public Transform holdParent;
    [SerializeField] float moveForce;
    [Space(15)]
    public float positionDistance;
    [Space(15)]
    [SerializeField] GameObject character;
    [SerializeField] bool pushObject = true;
    [SerializeField] bool pullObject = true;
    [Space(15)]                                            //public Transform holdParentOriginalPos;
    [SerializeField] float maxPushDistance;
    [SerializeField] float maxPullDistance;
    [Space(15)]
    [SerializeField] Animator animator;
    [Space(15)]
    //public GameObject put›tem;
    PutItem putItem;
    public static GameObject Light1;
    public static GameObject Light2;
    public static GameObject Light3;
    public static GameObject Light4;
    public static GameObject Light5;
    public static bool canTake = false;
    public static bool isTaken = false;


    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {

            Light1 = new GameObject();
            Light2 = new GameObject();
            Light3 = new GameObject();
            Light4 = new GameObject();
            Light5 = new GameObject();
            Light1 = GameObject.FindGameObjectWithTag("Light1");
            Light2 = GameObject.FindGameObjectWithTag("Light2");
            Light3 = GameObject.FindGameObjectWithTag("Light3");
            Light4 = GameObject.FindGameObjectWithTag("Light4");
            Light5 = GameObject.FindGameObjectWithTag("Light5");
            Light1.SetActive(false);
            Light2.SetActive(false);
            Light3.SetActive(false);
            Light4.SetActive(false);
            Light5.SetActive(false);
        }

    }

    void Update()
    {
        PickUpYourHand();
        bugCheck();
        HoldItem();
    }
    /*void PickUpYourHandEvents()
    {
        PickUpYourHand();
    }
    */

    void PickUpYourHand()
    {
        if (canTake == true)
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
                        hit.collider.gameObject.SetActive(false);
                        //KeyInHand.SetActive(true);
                        animator.SetTrigger("PickUp");
                        PutItem.GateKeyinHand.SetActive(true);
                        isTaken = true;

                    }
                }
            }
        }
    }

    void HoldItem()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, holdRange))
                {
                    //hit.point - (rayDir * -1 * yourValue);
                    PickUpObject(hit.transform.gameObject);
                }
            }
            else
            {
                dropObject();
            }
        }
        if (heldObject != null)
        {
            MoveObject();
        }
    }
    void MoveObject()
    {
        if (Vector3.Distance(heldObject.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObject.transform.position);
            heldObject.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
            //heldObject.GetComponent<Rigidbody>().velocity = Vector3.Slerp(heldObject.transform.position, moveDirection, 99);
            //heldObject.GetComponent<Rigidbody>().MovePosition(Vector3.Slerp(heldObject.transform.position, moveDirection, 3));
            //holdParent.GetComponent<Rigidbody>().MovePosition(Vector3.Slerp(holdParent.transform.position, moveDirection, 3));
            //holdParent.transform.Translate(Vector3.Slerp(holdParent.transform.position, moveDirection, 3));
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && pushObject) // Object push
        {
            holdParent.transform.position = holdParent.transform.position + holdParent.transform.forward;

        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && pullObject) // Object pull
        {
            holdParent.transform.position = holdParent.transform.position - holdParent.transform.forward;
        }
    }
    void PickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 15;

            objRig.transform.parent = holdParent.transform.parent;
            heldObject = pickObj;
        }
    }

    void dropObject()
    {
        Rigidbody heldRig = heldObject.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;

        heldObject.transform.parent = null;
        heldObject = null;
        holdParent.transform.localPosition = new Vector3(0, 0, 7.94f);
    }
    void bugCheck()     //Max & Min push-pull distance to avoid bugs
    {
        positionDistance = Vector3.Distance(holdParent.transform.position, character.transform.position);
        if (positionDistance < maxPullDistance)
        {
            pullObject = false;
        }
        else
        {
            pullObject = true;
        }
        if (positionDistance > maxPushDistance)
        {
            pushObject = false;
        }
        else
        {
            pushObject = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        holdParent.transform.position = new Vector3(holdParent.position.x, 0, holdParent.position.z);
    }

}
