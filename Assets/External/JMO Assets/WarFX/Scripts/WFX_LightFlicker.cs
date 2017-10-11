using UnityEngine;
using System.Collections;

/**
 *	Rapidly sets a light on/off.
 *	
 *	(c) 2015, Jean Moreno
**/

[RequireComponent(typeof(Light))]
public class WFX_LightFlicker : MonoBehaviour
{
	public float time = 0.05f;
	
	private float timer;

    private bool emiting = false;

	void Start ()
	{
		timer = 0;
	}

    private void Update() {
        if (emiting) {
            timer += Time.deltaTime;
            if(timer > time) {
                emiting = false;
                GetComponent<Light>().enabled = false;
            }
        }

    }
    public void startEmiting() {
        timer = 0;
        GetComponent<Light>().enabled = true;
        emiting = true;
    }
}
