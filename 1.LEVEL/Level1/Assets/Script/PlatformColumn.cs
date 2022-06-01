using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColumn : MonoBehaviour
{
    private MovingPlatform _movingPlatform;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            _movingPlatform.newPosition = _movingPlatform.position3.position;
           
            
        }
    }
}
