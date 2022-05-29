using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.Rendering;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject playbutton;
    [SerializeField] GameObject controlsButton;
    [SerializeField] GameObject optionButton;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject newGame;
    [SerializeField] GameObject loadGame;
    [SerializeField] GameObject loadGameText;
    private void Start()
    {
        playbutton.SetActive(true);
        controlsButton.SetActive(true);
        optionButton.SetActive(true);
        quitButton.SetActive(true);
        newGame.SetActive(false);
        loadGame.SetActive(false);
    }
    public void PlayGame()
    {
        playbutton.SetActive(false);
        controlsButton.SetActive(false);
        optionButton.SetActive(false);
        quitButton.SetActive(false);
        newGame.SetActive(true);
        loadGame.SetActive(true);
        if (File.Exists(Application.dataPath + "/" + "Save.atonal"))
        {
            loadGameText.GetComponent<TextMeshProUGUI>().color = new Color32(255,255,255,255);
        }
        else
        {
            loadGameText.GetComponent<TextMeshProUGUI>().color = new Color32(168,157,157,255);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void NewGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadGame()
    {
 
    }
}
