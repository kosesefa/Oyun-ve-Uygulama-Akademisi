using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutItem : MonoBehaviour
{
    public static GameObject PlacedGateKey;
    public static GameObject GateKeyinHand;
    private bool CanPut = false;


    void Start()
    {
        PlacedGateKey = GameObject.Find("Placed GateKey");
        GateKeyinHand = GameObject.Find("GateKey in Hand");
        GateKeyinHand.SetActive(false);
        PlacedGateKey.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CanPut==true )
        {
            GateKeyinHand.SetActive(false);
            PlacedGateKey.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanPut = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        CanPut= false;
    }
}
