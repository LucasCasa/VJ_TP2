using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float speedH = 0.001f;
    public float speedV = 0.001f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    CursorLockMode wantedMode;


    private Vector2 lastMoouse = new Vector2();
    // Use this for initialization
    void Start () {
        lastMoouse = Input.mousePosition;
        Cursor.lockState = CursorLockMode.Locked;
	}

    void Update() {
        yaw += speedH * (Input.mousePosition.x - lastMoouse.x);
        pitch -= speedV * (Input.mousePosition.y - lastMoouse.y);
        Debug.Log((Input.mousePosition.y - lastMoouse.y) + " " + (Input.mousePosition.x - lastMoouse.x));
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        lastMoouse = Input.mousePosition;
        if(Input.GetKeyDown(KeyCode.P)) {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
