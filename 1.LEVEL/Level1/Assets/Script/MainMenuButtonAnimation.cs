using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonAnimation : MonoBehaviour
{
    private const int P = 3;
    [SerializeField] public GameObject playButton;
    [SerializeField] public GameObject SettingsButton;
    [SerializeField] public GameObject quitButton;
    [SerializeField] public int AccelerationX;
    [SerializeField] public int AccelerationY;


    void FixedUpdate()
    {
        buttonIntro();
    }

    void buttonIntro()
    {
        
    }
}
