using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

	private static GameState _instance ;
	private float dificulty;
	// Use this for initialization
	void Awake () {
		//if we don't have an [_instance] set yet
		if(!_instance)
			_instance = this ;
		//otherwise, if we do, kill this thing
		else
			Destroy(this.gameObject);


		DontDestroyOnLoad(this.gameObject) ;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void loadGameScene(){
		SceneManager.LoadScene ("Game");
	}

}
