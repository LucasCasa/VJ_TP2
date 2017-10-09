using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private Vector3 offset;
    private float increment = 0.2f;

	// Use this for initialization
	void Start () {
        offset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (offset.z.CompareTo(0) == 0 && offset.x.CompareTo(400) < 0)
        {
            offset.z = 0;
            offset.x += increment;

        }else if (offset.z.CompareTo(400) == 0 && offset.x.CompareTo(0) > 0)
        {
            offset.z = 0;
            offset.x -= increment;   
        }else if (offset.x.CompareTo(400) == 0 && offset.z.CompareTo(400) < 0)
        {
			offset.z += increment;
            offset.x = 400;
        }else if (offset.x.CompareTo(0) == 0 && offset.z.CompareTo(0) > 0)
        {
			offset.z -= increment;
			offset.x = 0;
        }
 
		transform.position = offset;
	}
}
