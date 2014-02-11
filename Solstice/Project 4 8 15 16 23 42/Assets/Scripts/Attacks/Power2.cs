using UnityEngine;
using System.Collections;

public class Power2 : MonoBehaviour {
	
	public GameObject player;
	public GameObject spell;
	private float startTime;
	float selectedBarValue;
	
	// Use this for initialization
	void Start () {
	}
	
	bool isBarEmpty() {
		if (selectedBarValue < 10.0f) {
			return true;
		}
		return false;
	}
	
	// Update is called once per frame
	void Update () {
		// Update spell effect based on current season
		if (Utilities.currentSeason == Utilities.winter) {
			spell = GameObject.Find("SpellWinterDefensive");
			selectedBarValue = Utilities.magiaBarWinter;
		}
		else if (Utilities.currentSeason == Utilities.spring) {
			spell = GameObject.Find("SpellSpringDefensive");
			selectedBarValue = Utilities.magiaBarSpring;
		}
		else if (Utilities.currentSeason == Utilities.summer) {
			spell = GameObject.Find("SpellSummerDefensive");
			selectedBarValue = Utilities.magiaBarSummer;
		}
		else if (Utilities.currentSeason == Utilities.fall) {
			spell = GameObject.Find("SpellFallDefensive");
			selectedBarValue = Utilities.magiaBarFall;
		}
		
		
		// check for input "defensive"
		if (Input.GetButtonUp("power2")) {
			if (!isBarEmpty()) {
				if (!Utilities.calumitySpell && !Utilities.defensiveSpell && !Utilities.calumitySpell) {
					startTime = Utilities.defensiveSpellTime;
				}
				Utilities.defensiveSpell = true;
				spell.particleSystem.enableEmission = true;
				
				if (Utilities.currentSeason == Utilities.winter) {
					Utilities.magiaBarWinter -= Utilities.magiaBarWinter * 7 / 100;
				}
				else if (Utilities.currentSeason == Utilities.spring) {
					Utilities.magiaBarSpring -= Utilities.magiaBarSpring * 7 / 100;
				}
				else if (Utilities.currentSeason == Utilities.summer) {
					Utilities.magiaBarSummer -= Utilities.magiaBarSummer * 7 / 100;
				}
				else if (Utilities.currentSeason == Utilities.fall) {
					Utilities.magiaBarFall -= Utilities.magiaBarFall * 7 / 100;
				}
			}
		}
			
		// Counter for spell
		if (Utilities.defensiveSpell) {
			print("defensive : " + startTime);
			startTime -= Time.deltaTime;
			if (startTime < 0) {
				spell.particleSystem.enableEmission = false;
				Utilities.defensiveSpell = false;
			}
		}
	}
}
