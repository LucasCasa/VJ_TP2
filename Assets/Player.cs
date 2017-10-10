using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {

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

    private Vector2 bulletWidth = new Vector2(25, 0);
    private float bulletAvailable;
    public int bulletCapacity;

    private GameStats stats;

    public int life = 10;
	public bool shield = false;
	public float shieldDuration = 0f;
	public float totalShieldDuration = 10f;
	bool paused = false;

    // Use this for initialization
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        bulletAvailable = bulletCapacity;
        stats = new GameStats();
    }

    void Update() {
		if (!paused) {
			yaw += speedH * Input.GetAxis ("Mouse X");
			pitch -= speedV * Input.GetAxis ("Mouse Y");
			transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f);
		}
        
        if (bulletAvailable < bulletCapacity) {
            bulletAvailable += Time.deltaTime;
        }
		if (Input.GetMouseButtonDown(0) && BulletAvailable > 1 && !paused) {
            bulletAvailable--;
            stats.shots += 1;

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit,500)) {
				if (hit.collider.tag == "target") {
                    stats.barrelsHit += 1;
					hit.collider.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
					hit.collider.gameObject.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
					hit.collider.gameObject.SetActive (false);
					HitEffects (hit);
				} else if (hit.collider.tag == "powerup") {
                    stats.pwupHit += 1;
					hit.collider.gameObject.GetComponent<PowerUp> ().Effect (this);
				}
            }
			ShootEffects();
        }
		if (shield) {
			shieldDuration -= Time.deltaTime;
			if (shieldDuration <= 0)
				shield = false;
		}
    }
    
    void ShootEffects() {
        Recoil();
        muzzle.Play();
        sound.Play();
        bulletLightEffect.startEmiting();
    }

    void HitEffects(RaycastHit hit) {
        explosion.transform.position = hit.point;
        explosion.SetActive(true);
        explosion.GetComponent<ParticleSystem>().Play();
        explosion.GetComponentInChildren<AudioSource>().Play();
    }
    void Recoil() {
        yaw += Random.value * 2 - 1;// (Input.mousePosition.x - lastMoouse.x);
        pitch -= Random.value;// (Input.mousePosition.y - lastMoouse.y);
        //Debug.Log((Input.mousePosition.y - lastMoouse.y) + " " + (Input.mousePosition.x - lastMoouse.x));
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
    void OnTriggerEnter(Collider other) {
        other.gameObject.SetActive(false);
		if (shield) {
			shield = false;
			shieldDuration = 0;
		} else {
			life--;     
		}
    }

    public float BulletAvailable {
        get { return bulletAvailable; }
    }
    public int BulletCapacity {
        get { return bulletCapacity; }
    }
	public void Continue(){
		paused = false;
	}
	public void Pause(){
		paused = true;
	}
    public GameStats getStats(){
        return this.stats;
    }

}
