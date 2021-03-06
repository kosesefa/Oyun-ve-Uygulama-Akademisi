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
    public GameObject CanvasUI;
    PauseMenu pauseMenu;
    public static ThirdPersonController thirdPersonController;
    [SerializeField] AudioSource DeathAudio;
    public static ThirdPersonController cc;


    public void Start()
    {
        cc = GetComponent(typeof(ThirdPersonController)) as ThirdPersonController;
        pauseMenu = new PauseMenu();
        PauseMenu.GameIsPaused = false;
        canvas.SetActive(false);
        thirdPersonController = this.gameObject.GetComponent<ThirdPersonController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("OnGround") || other.gameObject.CompareTag("NPC"))
        {
            animator.SetTrigger("death");
            DeathAudio.Play();
            canvas.SetActive(true);
            Cursor.visible = true;
            isDead = true;
            PauseMenu.GameIsPaused = false;
            //pauseMenu.pauseMenuUI.SetActive(false);
            StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = false;
            StarterAssets.StarterAssetsInputs.instance.cursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
            StarterAssets.ThirdPersonController.LockCameraPosition = true;
            thirdPersonController.enabled = false;
            CanvasUI.SetActive(false);
        }
    }



    public void Restart()
    {
        if (isDead == true)
        {
            Cursor.visible = false;
            StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = true;
            StarterAssets.StarterAssetsInputs.instance.cursorLocked = true;
            isDead = false;
            //pauseMenu.pauseMenuUI.SetActive(false);
            PauseMenu.GameIsPaused = false;
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            thirdPersonController.enabled = true;
            CanvasUI.SetActive(false);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            animator.enabled = false;
            DeathAudio.enabled = false;

        }
    }


}