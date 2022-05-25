using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject playbutton;
    [SerializeField] GameObject controlsButton;
    [SerializeField] GameObject optionButton;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject newGame;
    [SerializeField] GameObject resumeGame;
    private void Start()
    {
        playbutton.SetActive(true);
        controlsButton.SetActive(true);
        optionButton.SetActive(true);
        quitButton.SetActive(true);
        newGame.SetActive(false);
        resumeGame.SetActive(false);
    }
    public void PlayGame()
    {
        playbutton.SetActive(false);
        controlsButton.SetActive(false);
        optionButton.SetActive(false);
        quitButton.SetActive(false);
        newGame.SetActive(true);
        resumeGame.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadGame()
    {

    }
}
