using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsButton : MonoBehaviour
{
    [SerializeField] public GameObject _PauseMenu;
    [SerializeField] public GameObject _ControllsMenu;
    public static bool inControllsMenu = false;
    void Start()
    {


    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && inControllsMenu == true && Death.isDead==false)
        {
            Debug.Log("esc bastý");
            _Pause();
        }
    }
    void _Pause()
    {
        _PauseMenu.SetActive(true);
        _ControllsMenu.SetActive(false);
        NPCDialogue.canEsc = true;
        inControllsMenu = false;
    }
    public void BackButton()
    {
        _PauseMenu.SetActive(true);
        _ControllsMenu.SetActive(false);
        inControllsMenu = false;
    }
    public void controllsButton()
    {
        inControllsMenu = true;
    }
}