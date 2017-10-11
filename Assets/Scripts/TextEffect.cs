using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffect : MonoBehaviour {
	Text text;
	float time = 0;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		time += 0.1f;
		text.color = new Color (Mathf.Sin (time) / 4 + 0.75f, Mathf.Sin (time) / 4 + 0.75f, 0);
	}
}
