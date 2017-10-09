using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

	private static GameState _instance ;
	private float dificulty;
	private bool sceneChanged = false;
	Player player;
	// Use this for initialization
	void Awake () {
		//if we don't have an [_instance] set yet
		if(!_instance)
			_instance = this ;
		//otherwise, if we do, kill this thing
		else
			Destroy(this.gameObject);

		SceneManager.activeSceneChanged += LoadLevel;
		DontDestroyOnLoad(this.gameObject) ;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void LoadLevel(Scene a, Scene b){
		if (a.buildIndex == 0) {
			player = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Player> ();
		} else if (a.buildIndex == 1) {
			//Muestro el Score en pantalla
		} else if (a.buildIndex == 2) {
			if (b.buildIndex == 1) {
				player = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Player> ();
			} else {
				
			}
		}
	}
	
	

}
