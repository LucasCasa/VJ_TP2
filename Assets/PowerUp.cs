using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	public float height;
	public float axisDistance;
	public float duration;
	public float minScale;

	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector3 (Random.Range(-axisDistance,axisDistance), height, Random.Range(-axisDistance,axisDistance));
	}
	
	// Update is called once per frame
	void Update () {
		float reduction = Time.deltaTime/duration;
		gameObject.transform.localScale -= new Vector3 (reduction, reduction, reduction);
		if (gameObject.transform.localScale.x <= minScale)
			Destroy (gameObject);
	}
}
