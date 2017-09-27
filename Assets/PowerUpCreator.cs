using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCreator : MonoBehaviour
{
	public float maxTime;
	public float minTime;

	//current time
	private float time;

	//The time to spawn the object
	private float spawnTime;

	public GameObject[] powerUps;

	void Start()
	{
		SetRandomTime();
		time = minTime;
	}

	void FixedUpdate()
	{
		//Counts up
		time += Time.deltaTime;

		//Check if its the right time to spawn the object
		if (time >= spawnTime)
		{
			SpawnPowerUp();
			time = 0;
			SetRandomTime();
		}

	}


	//Spawns the object and resets the time
	void SpawnPowerUp()
	{
		Instantiate(RandomPowerUp());
	}

	GameObject RandomPowerUp()
	{
		int r = Mathf.FloorToInt(Random.Range(0, powerUps.Length));
		return powerUps [r];
	}

	//Sets the random time between minTime and maxTime
	void SetRandomTime()
	{
		spawnTime = Random.Range(minTime, maxTime);
	}

}

