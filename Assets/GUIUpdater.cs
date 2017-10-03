using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIUpdater : MonoBehaviour {

    public Text health;
    public Image healthIcon;
	public Text timer;

    public RectTransform bulletBar;
    public Camera cam;

	private float time = 0;
    private int bulletWidth = 25;

    public Player player;

    // Use this for initialization
    void Start () {

        bulletBar.sizeDelta = new Vector2(bulletWidth * player.BulletCapacity, 77);
        bulletBar.position = new Vector3(cam.pixelWidth - bulletWidth * player.BulletCapacity - 30, 15, 0);
        health.text = health.ToString();

    }
	
	// Update is called once per frame
	void Update () {
        bulletBar.sizeDelta = new Vector2(bulletWidth * player.BulletAvailable, 77);
        health.text = player.life.ToString();
		time += Time.deltaTime;
		string timeStr = time.ToString ();
		timer.text = "Time:\n" + timeStr.Substring(0,timeStr.IndexOf(".") + 2);
	}
}
