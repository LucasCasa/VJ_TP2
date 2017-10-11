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
        float difficulty = GameObject.Find("GameState").GetComponent<GameState>().getDifficulty();
        float angle = Random.value * difficulty * Mathf.PI;
        Vector2 pos = new Vector2(Mathf.Cos(angle) *Random.Range(minAxisDistance, maxAxisDistance), Mathf.Sin(angle) * Random.Range(minAxisDistance, maxAxisDistance));
		gameObject.transform.position = new Vector3 (pos.x, height, pos.y);
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
