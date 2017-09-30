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

    public int life = 10;

    // Use this for initialization
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        bulletAvailable = bulletCapacity;
    }

    void Update() {
        yaw += speedH * Input.GetAxis("Mouse X");// (Input.mousePosition.x - lastMoouse.x);
        pitch -= speedV * Input.GetAxis("Mouse Y");// (Input.mousePosition.y - lastMoouse.y);
        //Debug.Log((Input.mousePosition.y - lastMoouse.y) + " " + (Input.mousePosition.x - lastMoouse.x));
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        //lastMoouse = Input.mousePosition;
        if (Input.GetKeyDown(KeyCode.P)) {
            Cursor.lockState = CursorLockMode.None;
        }
        if (bulletAvailable < bulletCapacity) {
            bulletAvailable += Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && BulletAvailable > 1) {
            bulletAvailable--;
            ShootEffects();
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500)) {
                if (hit.collider.tag == "target") {
                    hit.collider.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    hit.collider.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    hit.collider.gameObject.SetActive(false);
                    HitEffects(hit);
                }
            }
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
        life--;        
    }

    public float BulletAvailable {
        get { return bulletAvailable; }
    }
    public int BulletCapacity {
        get { return bulletCapacity; }
    }
}
