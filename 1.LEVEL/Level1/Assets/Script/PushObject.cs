using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    [SerializeField]
    private float ForceMagnitude;
 
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;
        if (rigidbody != null)
        {
            Vector3 ForceDirection = hit.gameObject.transform.position - transform.position;
            ForceDirection.y = 0;
            ForceDirection.Normalize();
            rigidbody.AddForceAtPosition(ForceDirection * ForceMagnitude, transform.position, ForceMode.Impulse);
        }
    }
}
