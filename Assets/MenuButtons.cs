using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Text theMenu;

    Color highlighted = new Color(1, 1, 0); //Or however you do your color
    Color other = new Color(0.8f, 0.8f, 0); //Or however you do your color

    public void OnPointerEnter(PointerEventData eventData)
    {
        theMenu.color = highlighted;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        theMenu.color = other;
    }

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

    // Use this for initialization
	void Start () 
    {
        theMenu = this.GetComponentInChildren<Text>();
        theMenu.color = other;
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
}
