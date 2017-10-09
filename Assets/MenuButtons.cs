using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    public Text theMenu;

    public void goToGame()
    {
        SceneManager.LoadScene("game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void goToSettings()
    {
        SceneManager.LoadScene("settings");
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
