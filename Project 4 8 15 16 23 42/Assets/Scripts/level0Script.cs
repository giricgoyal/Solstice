using UnityEngine;
using System.Collections;

public class level0Script : MonoBehaviour {
	
	float timer, timer1, timer2;
	string loading = "Loading Level, Please Wait";
	string dot = ".";
	string extra = "";
	bool showimage = false;
	bool startTimer = false;
	
	public GameObject light;
	public GameObject plane;
	public GameObject text1;
	public GameObject text2;
	
	// Use this for initialization
	void Start () {
		timer = 2;
		timer1 = 2.5f;
		
		if (Utilities.isWall) {
			Utilities.scaleFactor = 1920.0f/1366.0f * 2.0f;
		}
		else {
			Utilities.scaleFactor = 1;
		}
		Screen.SetResolution((int)Mathf.Abs(1366*Utilities.scaleFactor), (int)Mathf.Abs(768*Utilities.scaleFactor), false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!showimage) {
			text1.renderer.enabled = true;
			text2.renderer.enabled = true;
			timer1 -= Time.deltaTime;
			if (timer1 < 0) {
				showimage = true;
				text1.renderer.enabled = false;
				text2.renderer.enabled = false;
			}
		}
		if (showimage) {
			plane.renderer.enabled = true;
			if (light.light.intensity <= 1.0) {
				light.light.intensity += Time.deltaTime;
			}
			else {
				startTimer = true;
			}
		}
		if (startTimer) {
			timer -= Time.deltaTime;
			print (timer);
			if (timer < 0) {
				Application.LoadLevel("level1");
			}
			
			if (extra.Length <= 5) {
				extra = extra + dot;
			}
			else {
				extra = "";
			}
		}
	}
	
	void OnGUI() {		
		if (startTimer) {
			GUI.Label(new Rect(600*Utilities.scaleFactor, 680 * Utilities.scaleFactor, 500*Utilities.scaleFactor, 30*Utilities.scaleFactor), loading + extra);
		}
	}
}
