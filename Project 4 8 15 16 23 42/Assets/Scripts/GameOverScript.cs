using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	void OnGUI() {
		if (GUI.Button(new Rect(Screen.width/2 - 50,Screen.height - 85,100,25), "Play Again")) {
			Application.LoadLevel("level0");
		}
		if (GUI.Button(new Rect(Screen.width/2 - 50,Screen.height - 55,100,25), "Quit")) {
			Application.Quit();
		}
	}
}
