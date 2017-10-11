using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//Se que hacer un find es costoso, pero para un menu no deberia ser problema
	public void setDificulty(float dif){
		Debug.Log ("Seteo Dificultad " + dif );
		GameObject.Find ("GameState").GetComponent<GameState> ().setDificulty (dif);
	}
}
