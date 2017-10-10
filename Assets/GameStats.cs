using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameStats {

	public int shots;
	public int barrelsHit;
	public int pwupHit;
	public float score;

	public GameStats(){
		shots = 0;
		barrelsHit = 0;
		pwupHit = 0;
	}

	public float getAccuracy(){
		return (barrelsHit+pwupHit)/((float)shots);
	}

}