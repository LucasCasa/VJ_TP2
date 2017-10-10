using System;
using UnityEngine;
using UnityEngine.UI;

public class StatsLoader : MonoBehaviour {

	public Text score;
	public Text statText;

	private GameState state;
	private GameStats stats;

	// Use this for initialization
	void Start () {
		this.state = GameObject.Find ("GameState").GetComponent<GameState> ();
		this.stats = state.getStats();

		score.text = "Score: " + stats.score;
		statText.text = "Difficulty:	" + getDifficulty() + "\tShots:	" + stats.shots + "\tAccuracy: " + stats.getAccuracy();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private string getDifficulty(){
		switch((int)Math.Round(state.getDifficulty()*4,0)){
			case 1: return "Easy";
			case 2: return "Medium";
			case 4: return "Hard";
			case 8: return "Impossible";
			default: return "Medium";	
		}
	}

}
