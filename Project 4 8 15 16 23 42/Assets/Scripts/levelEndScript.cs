using UnityEngine;
using System.Collections;

public class levelEndScript : MonoBehaviour {
	

	public GameObject life;
	public GameObject text;
	bool checkpoint1 = false;
	bool goTocheckPoint1 = true;
	bool goToCheckPoint2 = false;
	bool showOnGUI = false;
	float distance;
	float distance2;
	float timerStay;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(life.transform.position, transform.position);
		if (goTocheckPoint1) {
			if (distance >= 2) {
				transform.Translate(Vector3.forward * 5 * Time.deltaTime);
				checkpoint1 = true;
				timerStay = 1;
			}
		}
		if (checkpoint1) {
			timerStay -= Time.deltaTime;
			if (timerStay < 0) {
				goToCheckPoint2 = true;
				checkpoint1 = false;
			}
		}
		if (goToCheckPoint2) {
			transform.Translate(Vector3.back * 10 * Time.deltaTime);
		}
		if (distance >= 35) {
			print ("to be continued....");
			goToCheckPoint2 = false;
			goTocheckPoint1 = false;
			showOnGUI = true;
		}
		
		if (showOnGUI) {
			distance2 = Vector3.Distance(transform.position, text.transform.position);
			text.renderer.enabled = true;
		}
	}
	
	void OnGUI() {
		if (showOnGUI) {
			print ("aaaa");
			if (GUI.Button(new Rect(Screen.width/2 - 50,Screen.height - 85,100,25), "Play Again")) {
				Application.LoadLevel("level0");
			}
			if (GUI.Button(new Rect(Screen.width/2 - 50,Screen.height - 55,100,25), "Quit")) {
				Application.Quit();
			}
		}
	}
}
