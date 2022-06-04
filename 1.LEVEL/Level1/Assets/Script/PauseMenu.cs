using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject CharacterController;
    private void Start()
    {
        NPCDialogue.canEsc = true;

        CharacterController = GameObject.Find("PlayerArmature");
        CharacterController.AddComponent<CharacterController>(); ;
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && RockDialogue.RockCanESC==true && NPCDialogue2.SecondNPCCanEsc==true && SoundManager.inControllsMenu ==false && ControlsButton.inControllsMenu==false && Death.isDead == false && NPCDialogue.canEsc == true && SecondGameZone.canEscSecondGame==true)
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = true;
        StarterAssets.StarterAssetsInputs.instance.cursorLocked = true;
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    public void PauseGame()
    {
        
        Cursor.visible = true;
        StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = false;
        StarterAssets.StarterAssetsInputs.instance.cursorLocked = false;
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}