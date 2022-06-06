using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] public GameObject _PauseMenu;
    [SerializeField] public GameObject _SettingsMenu;
    [SerializeField] Slider volumeSlider;
    public static bool inControllsMenu = false;


    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && inControllsMenu == true && Death.isDead == false)
        {
            Debug.Log("esc bastý");
            _Pause();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
    // Update is called once per frame
    void _Pause()
    {
        _PauseMenu.SetActive(true);
        _SettingsMenu.SetActive(false);
        inControllsMenu = false;
    }
    public void controllsButton()
    {
        inControllsMenu = true;
    }
    public void BackButton()
    {
        _PauseMenu.SetActive(true);
        _SettingsMenu.SetActive(false);
        inControllsMenu = false;
    }

}