using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIUpdater : MonoBehaviour {

    public Text health;
    public Image healthIcon;
	public Text timer;
	public Image shieldIcon;

    public RectTransform bulletBar;
    public Camera cam;

	public GameObject pauseScreen;
	public GameObject HUD;

	private float time = 0;
    private int bulletWidth = 25;

    public Player player;
	public bool paused;
	public Button Cont;
	public Button Menu;
	public Button Exit;

    // Use this for initialization
    void Start () {
		Cont.onClick.AddListener (Continue);
		Menu.onClick.AddListener (GotoMenu);
		Exit.onClick.AddListener (Quit);
        bulletBar.sizeDelta = new Vector2(bulletWidth * player.BulletCapacity, 77);
        bulletBar.position = new Vector3(cam.pixelWidth - bulletWidth * player.BulletCapacity - 30, 15, 0);
        health.text = health.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P)) {
			if(!paused){
				Cursor.lockState = CursorLockMode.None;
				paused = true;
				player.Pause ();
				Time.timeScale = 0;
				HUD.SetActive (false);
				pauseScreen.SetActive (true);
			}else{
				Cursor.lockState = CursorLockMode.Locked;
				paused = false;
				Time.timeScale = 1;
				pauseScreen.SetActive (false);
				HUD.SetActive (true);
				player.Continue ();
			}
		}
		if(!paused){
			if (player.shield)
				shieldIcon.fillAmount = player.shieldDuration / player.totalShieldDuration;
			else
				shieldIcon.fillAmount = 0;	
			bulletBar.sizeDelta = new Vector2(bulletWidth * player.BulletAvailable, 77);
			health.text = player.life.ToString();
			time += Time.deltaTime;
			string timeStr = time.ToString ();
			timer.text = "Time:\n" + timeStr.Substring(0,timeStr.IndexOf(".") + 2);
		}
	}

	void Continue(){
		Cursor.lockState = CursorLockMode.Locked;
		paused = false;
		Time.timeScale = 1;
		pauseScreen.SetActive (false);
		HUD.SetActive (true);
		player.Continue ();
	}

	void GotoMenu(){
		//TODO
	}
	void Quit (){
	
	}
}
