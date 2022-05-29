using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class Death : MonoBehaviour
{
    //death animation script
    [SerializeField] GameObject Otis;
    public Animator animator;
    [SerializeField] GameObject canvas;
    public static bool isDead = false;

    ThirdPersonController thirdPersonController;


    public void Start()
    {
        
        canvas.SetActive(false);
        thirdPersonController = this.gameObject.GetComponent<ThirdPersonController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OnGround") || other.CompareTag("NPC"))
        {
            animator.SetTrigger("death");
            canvas.SetActive(true);
            isDead = true;
            Cursor.visible = true;
            StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = false;
            StarterAssets.StarterAssetsInputs.instance.cursorLocked = false;
            StarterAssets.ThirdPersonController.LockCameraPosition = true;
            thirdPersonController.enabled = false;
        }
    }

    public void Restart()
    {
        Cursor.visible = false;
        StarterAssets.ThirdPersonController.LockCameraPosition = false;
        isDead = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
        thirdPersonController.enabled = true;


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OnGround") || other.CompareTag("NPC"))
        {
            animator.enabled = false;
            canvas.SetActive(true);
            isDead = true;
            Cursor.visible = true;
            StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = false;
            StarterAssets.StarterAssetsInputs.instance.cursorLocked = false;
            StarterAssets.ThirdPersonController.LockCameraPosition = true;
            thirdPersonController.enabled = false;
        }
    }

}