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
	public float time;

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
		go.transform.position = new Vector3 (pos.x, 0, pos.y);
		Vector3 force = calcBallisticVelocityVector (go.transform.position, new Vector3 (0, 0, 0), 45);
		var g = Physics.gravity.magnitude; // get the gravity value
		var hSpeed = Vector3.Distance(go.transform.position,new Vector3(0,0,0)) / time; // calculate the horizontal speed
		var vspeed = 0.5f*g*time;
		go.GetComponent<Rigidbody> ().velocity = hSpeed*Vector3.Normalize(-go.transform.position) + new Vector3(0,vspeed,0);
		//go.GetComponent<Rigidbody> ().AddForce (new Vector3 (-pos.x,0.0f,-pos.y)*force, ForceMode.Impulse);
	}

	private Vector3 calcBallisticVelocityVector(Vector3 source, Vector3 target, float angle){
		Vector3 direction = target - source;                            
		float h = direction.y;                                           
		direction.y = 0;                                               
		float distance = direction.magnitude;                           
		float a = angle * Mathf.Deg2Rad;                                
		direction.y = distance * Mathf.Tan(a);                            
		distance += h/Mathf.Tan(a);                                      

		// calculate velocity
		float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2*a));
		return velocity * direction.normalized;    
	}
}
