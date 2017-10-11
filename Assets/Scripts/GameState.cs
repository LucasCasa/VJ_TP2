﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

	private static GameState _instance ;
	private float dificulty;
	private bool sceneChanged = false;
	private GameStats stats;
	private float time;
    public AudioClip ded;

	Player player;
	// Use this for initialization
	void Awake () {
		//if we don't have an [_instance] set yet
		if (!_instance){
			_instance = this;
		//otherwise, if we do, kill this thing
		}else{
			Destroy (this.gameObject);
			return;
		}
		SceneManager.activeSceneChanged += LoadLevel;
		dificulty = 0.5f;
		time = 0;
		DontDestroyOnLoad(this.gameObject) ;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null && player.life <= 0) {
			this.stats = player.getStats();
			stats.score = this.time;
			SceneManager.LoadScene ("End");
		}
		this.time += Time.deltaTime;
	}

	void LoadLevel(Scene a, Scene b){
		if (b.name == "Game") {
			player = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Player> ();
			ProyectileManager p = GameObject.FindGameObjectWithTag ("Proyectile Manager").GetComponent<ProyectileManager> ();
			Debug.Log ("dificultad " + dificulty);
			p.SetDificulty(dificulty);
			Debug.Log ("Ya setee la dificultad " + p.dificulty);
            this.time = 0;
		} else if (b.name == "End") {
            AudioSource.PlayClipAtPoint(ded, new Vector3(0, 0, 0));
            Cursor.lockState = CursorLockMode.None;
            //Muestro el Score en pantalla
        }
	}

	public void setDificulty(float dif){
		if (dif < 0.25 || dif > 2) {
			Debug.Log("ERROR");
		}
		dificulty = dif;
		Debug.Log (dificulty);
	}
	void OnDestroy(){
		Debug.Log ("Goodbye" + dificulty);
	}

	public float getDifficulty(){
		return this.dificulty;
	}
	
	public GameStats getStats(){
		return this.stats;
	}

    public float getTime(){
        return this.time;
    }
}
