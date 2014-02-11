using UnityEngine;
using System.Collections;

public class helpScript2 : MonoBehaviour {
bool show = false;
	GameObject guitext;
	Texture2D texture;
	string text;
	float time;
	// Use this for initialization
	void Start () {
		guitext = GameObject.FindGameObjectWithTag("guiText");
		guitext.guiText.fontSize = (int)(25 * Utilities.scaleFactor);
		text = "Water: Use winter to freeze, summer to evaporate or spring to call Life. (Middle Mouse/z)";
		texture = new Texture2D((int)(900*Utilities.scaleFactor), (int)(35*Utilities.scaleFactor));
		for (int i=0; i<texture.width; i++) {
			for (int j=0; j<texture.height; j++) {
				texture.SetPixel(i,j,new Color32(0,0,0,120));
			}
		}
		texture.Apply();
	}
	
	// Update is called once per frame
	void Update () {
		if (show) {
			if (time < 0) {
				text = "";
			}
			time -= Time.deltaTime;
			if (time < 0) {
				text = "";
			}
			//print (show);
			guitext.guiText.material.color = new Color32(255,255,255,255);
			guitext.guiText.text = text;	
		}
		if (text.Equals("")) {
			show = false;
		}
	}
	
	void OnGUI() {
		if (show && time > 0) {
			GUI.Label(new Rect(350*Utilities.scaleFactor, Screen.height - (texture.height - 35)*Utilities.scaleFactor, 900*Utilities.scaleFactor, 35*Utilities.scaleFactor), texture);
		}
	}
	
	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag("Player")) {
			if (!show) {
				time = 5;
				show = true;
			}
		}
	}
	
	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.CompareTag("Player")) {
			//show = false;
		}
	}
}
