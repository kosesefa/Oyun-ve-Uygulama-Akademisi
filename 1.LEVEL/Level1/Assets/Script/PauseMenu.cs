using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Death.isDead==false)
        {
            if (GameIsPaused)
            {
                ResumeGame();
            } else
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
        Cursor.visible=true;
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
