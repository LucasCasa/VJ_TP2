using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour {

	public float height = 10;
	public float minAxisDistance = 10;
	public float maxAxisDistance = 20;
	public float duration = 10;
	public float minScale = 0.1f;

	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector3 (Random.Range(minAxisDistance,maxAxisDistance), height, Random.Range(minAxisDistance,maxAxisDistance));
	}
	
	// Update is called once per frame
	void Update () {
		float reduction = Time.deltaTime/duration;
		gameObject.transform.localScale -= new Vector3 (reduction, reduction, reduction);
		if (gameObject.transform.localScale.x <= minScale)
			Destroy (gameObject);
	}

	public abstract void Effect (Player player);
}
