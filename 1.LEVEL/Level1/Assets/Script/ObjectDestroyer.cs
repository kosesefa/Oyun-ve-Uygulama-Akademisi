using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -100)
        {
            Destroy(gameObject);
        }
    }
}
