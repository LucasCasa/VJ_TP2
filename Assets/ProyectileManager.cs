using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileManager : MonoBehaviour {

	public int size;
	public GameObject proyectile;
	public float start_time;
	public float interval;
	public float distance;
	public float force;

	private List<GameObject> list = new List<GameObject>();

	// Use this for initialization
	void Start () {
		for (int i = 0; i < size; i++) {
			GameObject go = Instantiate(proyectile);
			go.SetActive (false);
			list.Add (go);
		}

		InvokeRepeating("LaunchProjectile", start_time, interval);
	}

	void Update(){
		
	}
	
	void LaunchProjectile(){
		GameObject go = list.Find(x => x.activeInHierarchy == false);
		if (go == null)
			return;
		go.SetActive (true);
		Vector2 pos = Random.insideUnitCircle*distance;
		go.transform.position = new Vector3 (pos.x, 4.0f, pos.y+20);
		go.GetComponent<Rigidbody> ().AddForce (new Vector3 (-pos.x,0.0f,-pos.y)*force, ForceMode.Impulse);
	}
}
