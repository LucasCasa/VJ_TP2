using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour {

	public float hit_distance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = this.transform.position;
		if (Mathf.Abs (pos.x) < hit_distance && Mathf.Abs (pos.z) < hit_distance) {
			// TODO: Reduce life logic
			gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
			gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			gameObject.SetActive(false);
		}
	}
}
