using UnityEngine;
using System.Collections;

public class portal : MonoBehaviour {
	
	float angle = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Utilities.state == Utilities.stateMainGame) {
			
			
		}
	}
	
	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag("Player")) {
			Application.LoadLevel("levelEnd");
		}
	}
}
