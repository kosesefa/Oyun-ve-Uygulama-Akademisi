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
        //StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = true;
        //StarterAssets.StarterAssetsInputs.instance.cursorLocked = true;
        canvas.SetActive(false);
        thirdPersonController = this.gameObject.GetComponent<ThirdPersonController>();
        //thirdPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OnGround"))
        {
            animator.SetTrigger("death");
            canvas.SetActive(true);
            isDead = true;
            Cursor.visible = true;
            StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = false;
            StarterAssets.StarterAssetsInputs.instance.cursorLocked = false;
            StarterAssets.ThirdPersonController.LockCameraPosition = true;
            thirdPersonController.enabled = false;
            //StartCoroutine(deathTime());
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
    /*IEnumerator deathTime()
    {
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 0;
    }
    */
}