using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    //death animation script
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OnGround"))
        {
            animator.SetTrigger("death");       
        }
    }
}
