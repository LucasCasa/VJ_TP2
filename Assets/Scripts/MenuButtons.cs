using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject EasyB;
	public GameObject MediumB;
	public GameObject HardB;
	public GameObject ImpossibleB;

	public void diffSelected(int diff){
        switch (diff){
            case 1:
                EasyB.SetActive(true);
                MediumB.SetActive(false);
                HardB.SetActive(false);
                ImpossibleB.SetActive(false);
                break;
            case 2:
				EasyB.SetActive(false);
				MediumB.SetActive(true);
				HardB.SetActive(false);
				ImpossibleB.SetActive(false);
                break;
			case 3:
				EasyB.SetActive(false);
				MediumB.SetActive(false);
				HardB.SetActive(true);
				ImpossibleB.SetActive(false);
                break;
            case 4:
				EasyB.SetActive(false);
				MediumB.SetActive(false);
				HardB.SetActive(false);
				ImpossibleB.SetActive(true);
                break;
        }
    }

    public void goToGame()
    {
        SceneManager.LoadScene("Game");
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
