using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour {

    public GameObject EasyB;
    public GameObject MediumB;
    public GameObject HardB;
    public GameObject ImpossibleB;

    public void diffSelected(int diff)
    {
        switch (diff)
        {
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
            case 4:
                EasyB.SetActive(false);
                MediumB.SetActive(false);
                HardB.SetActive(true);
                ImpossibleB.SetActive(false);
                break;
            case 8:
                EasyB.SetActive(false);
                MediumB.SetActive(false);
                HardB.SetActive(false);
                ImpossibleB.SetActive(true);
                break;
        }
    }

    void Awake()
    {
        float difficulty = GameObject.Find("GameState").GetComponent<GameState>().getDifficulty();
        diffSelected((int)(difficulty * 4));
    }

	//Se que hacer un find es costoso, pero para un menu no deberia ser problema
	public void setDificulty(float dif){
		Debug.Log ("Seteo Dificultad " + dif );
		GameObject.Find ("GameState").GetComponent<GameState> ().setDificulty (dif);
	}
}
