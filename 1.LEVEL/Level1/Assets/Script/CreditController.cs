using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreditController : MonoBehaviour
{
    [SerializeField] GameObject ReturnMenu;

    private void Start()
    {
        Cursor.visible = false;
        StartCoroutine(CursorVisible());
    }

    public void Menu()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("Menu 1");
    }

    public void QuitGame()
    {
       Application.Quit();
    }

    IEnumerator CursorVisible()
    {
        yield return new WaitForSeconds(20);
        Cursor.visible = true;
    }
}
