using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessTableTrigger : MonoBehaviour
{
    public static bool a7 = false;
    public static bool c8 = false;
    public static bool f1 = false;
    public static bool c7 = false;
    public static bool h4 = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ChessKey")
        {
            if (transform.tag=="A7")
            {
                a7 = true;
                Debug.Log("a7 true");
            }
            if (transform.tag=="C8")
            {
                c8 = true;
                Debug.Log("c8 true");
            }
            if (transform.tag=="F1")
            {
                f1 = true;
                Debug.Log("f1 true");
            }
            if (transform.tag == "C7")
            {
                c7 = true;
                Debug.Log("c7 true");
            }
            if (transform.tag == "H4")
            {
                h4 = true;
                Debug.Log("h4 true");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ChessKey")
        {
            if (transform.tag == "A7")
            {
                a7 = false;
            }
            if (transform.tag == "C8")
            {
                c8 = false;
            }
            if (transform.tag == "F1")
            {
                f1 = false;
            }
            if (transform.tag == "C7")
            {
                c7 = false;
            }
            if (transform.tag == "H4")
            {
                h4 = false;
            }
        }
    }
}
