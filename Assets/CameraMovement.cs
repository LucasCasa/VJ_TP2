using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float speedH = 2f;
    public float speedV = 2f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    CursorLockMode wantedMode;
    public GameObject bulletPrefab;
    public GameObject bulletPosition;

    public ParticleSystem muzzle;
    public AudioSource sound;

    public WFX_LightFlicker bulletLightEffect;
    public GameObject explosion;

	public RectTransform bulletBar;
	public int bulletCapacity;
	public Text health;

	private Vector2 bulletWidth = new Vector2 (20, 0);

	public int life = 10;

    //private Vector2 lastMoouse = new Vector2();
    // Use this for initialization
    void Start () {
        //lastMoouse = Input.mousePosition;
        Cursor.lockState = CursorLockMode.Locked;
		bulletBar.sizeDelta = new Vector2 (bulletWidth.x * bulletCapacity, 77);
		health.text = life.ToString();
	}

    void Update() {
        yaw += speedH * Input.GetAxis("Mouse X");// (Input.mousePosition.x - lastMoouse.x);
        pitch -= speedV * Input.GetAxis("Mouse Y");// (Input.mousePosition.y - lastMoouse.y);
        //Debug.Log((Input.mousePosition.y - lastMoouse.y) + " " + (Input.mousePosition.x - lastMoouse.x));
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        //lastMoouse = Input.mousePosition;
        if(Input.GetKeyDown(KeyCode.P)) {
            Cursor.lockState = CursorLockMode.None;
        }
		if (bulletBar.sizeDelta.x / bulletWidth.x < bulletCapacity) {
			bulletBar.sizeDelta = bulletBar.sizeDelta + bulletWidth * Time.deltaTime;
		}
		if (Input.GetMouseButtonDown(0) && bulletBar.sizeDelta.x >= bulletWidth.x) {
            Debug.Log("Firee");
            Recoil();
            muzzle.Play();
            sound.Play();
			bulletBar.sizeDelta = bulletBar.sizeDelta - bulletWidth;
            bulletLightEffect.startEmiting();
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit, 200)) {
				if (hit.collider.tag == "target") {
					hit.collider.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
					hit.collider.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
					hit.collider.gameObject.SetActive (false);
				}
                print("Hit something!");
                explosion.transform.position = hit.point;
                explosion.SetActive(true);
                explosion.GetComponent<ParticleSystem>().Play();
                explosion.GetComponentInChildren<AudioSource>().Play();
            }
                
        
            /*GameObject go = Instantiate(bulletPrefab) as GameObject;
            go.transform.position = bulletPosition.transform.position;
            go.transform.rotation = bulletPosition.transform.rotation;
            go.GetComponent<Rigidbody>().AddForce(1000 * go.transform.up);
            go.GetComponent<Rigidbody>().useGravity = true;*/
        }
    }

    void Recoil() {
        yaw += Random.value*2 - 1;// (Input.mousePosition.x - lastMoouse.x);
        pitch -= Random.value;// (Input.mousePosition.y - lastMoouse.y);
        //Debug.Log((Input.mousePosition.y - lastMoouse.y) + " " + (Input.mousePosition.x - lastMoouse.x));
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
	void OnTriggerEnter(Collider other) {
		other.gameObject.SetActive(false);
		life--;
		health.text = life.ToString();
	}
}
