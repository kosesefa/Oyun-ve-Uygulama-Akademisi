using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugFixer : MonoBehaviour
{
    public GameObject Character;

    private void Start()
    {
        Character = GameObject.Find("PlayerArmature");
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = Character.transform.position + Character.transform.forward*3 +Character.transform.up ;
    }
}
