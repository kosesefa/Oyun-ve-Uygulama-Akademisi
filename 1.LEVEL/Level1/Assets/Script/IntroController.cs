using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    [SerializeField] GameObject continueButton;
    private void Start()
    {
        StartCoroutine(CursorVisible());
    }
    public void NewGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator CursorVisible()
    {
        yield return new WaitForSeconds(15);
        Cursor.visible = true;
    }
}
