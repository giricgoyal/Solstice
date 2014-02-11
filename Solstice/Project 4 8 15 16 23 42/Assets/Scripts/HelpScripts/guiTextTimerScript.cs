using UnityEngine;
using System.Collections;

public class guiTextTimerScript : MonoBehaviour {
	
	//public GameObject timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Utilities.calumitySpell) {
			if (Utilities.currentSeason == Utilities.winter) {
				guiText.text = ((int)Utilities.freezeTimer).ToString();
			}
			else if (Utilities.currentSeason == Utilities.spring) {
				guiText.text = ((int)Utilities.griffonTimer).ToString();
			}
			else if (Utilities.currentSeason == Utilities.summer) {
				guiText.text = ((int)Utilities.steamTimer).ToString();
			}
		}
		else {
			guiText.text = "0";
		}
	}
}
