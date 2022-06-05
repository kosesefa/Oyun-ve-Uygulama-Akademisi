using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessTableTrigger : MonoBehaviour
{
    public static bool a7=false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ChessKey")
        {
            a7 = true;
            Debug.Log("a7 true");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ChessKey")
        {
            a7 = false;
            Debug.Log("a7 false");
        }
    }
}
