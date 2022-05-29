using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;

    public EndLevel _endLevel;

    public ColumnTrigger _columnTrigger;

    // Update is called once per frame
    void Update()
    {
        if (_columnTrigger.door.GetComponent<BoxCollider>().enabled)
        {
            if (_endLevel.isEndOfLevel)
            {
                FadeToNextLevel();
            }
        }
    }
    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
   

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
