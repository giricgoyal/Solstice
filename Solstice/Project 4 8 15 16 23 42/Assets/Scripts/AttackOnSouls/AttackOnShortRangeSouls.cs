using UnityEngine;
using System.Collections;

public class AttackOnShortRangeSouls : MonoBehaviour {
	
	float distance;
	public GameObject target;
	public GameObject self;
	
	// Use this for initialization
	void Start () {
		self = GameObject.Find(name);
	}
	
	// Update is called once per frame
	void Update () {
		if (Utilities.state == Utilities.stateMainGame) {
			/*
			// effect of defensive spell
			if (Utilities.defensiveSpell == true) {
				distance = Vector3.Distance(target.transform.position, transform.position);
				// this is what will kill them if player casts spell
				// will depend on the season and the soul effected also the spell casted
				
				if (distance < Utilities.defensiveAttackDistance) {
					if (self.GetComponent<ShortRangeEnemyScript>().seasonType == Utilities.winter) {
						if (Utilities.currentSeason != Utilities.winter) {
							self.GetComponent<ShortRangeEnemyScript>().isActive = false;
							self.renderer.material.color = Color.white;
							Utilities.magiaBarWinter += Utilities.magiaBarWinter * 3.5f / 100f;
							Destroy(self, 2.0f);
						}
					}
					if (self.GetComponent<ShortRangeEnemyScript>().seasonType == Utilities.summer) {
						if (Utilities.currentSeason != Utilities.summer) {
							self.GetComponent<ShortRangeEnemyScript>().isActive = false;
							self.renderer.material.color = Color.white;
							Utilities.magiaBarSummer += Utilities.magiaBarSummer * 3.5f / 100f;
							Destroy(self, 2.0f);
						}
					}
				}
			}
			*/
			
			// effect of offensive spell
			// this part is in Power1.cs file
			// skipped from this file
			
			
			// effect of calamity spell
			if (Utilities.calumitySpell) {
				distance = Vector3.Distance(target.transform.position, transform.position);
				if (distance < Utilities.calamityAttackRadius) {
					if (self.GetComponent<ShortRangeEnemyScript>().seasonType == Utilities.winter) {
						if (Utilities.currentSeason != Utilities.winter) {
							self.GetComponent<ShortRangeEnemyScript>().isActive = false;
							self.renderer.material.color = Color.white;
							Utilities.magiaBarWinter += Utilities.magiaBarWinter * 15f / 100f;
							Destroy(self, 2.0f);
						}
					}
					if (self.GetComponent<ShortRangeEnemyScript>().seasonType == Utilities.summer) {
						if (Utilities.currentSeason != Utilities.summer) {
							self.GetComponent<ShortRangeEnemyScript>().isActive = false;
							self.renderer.material.color = Color.white;
							Utilities.magiaBarSummer += Utilities.magiaBarSummer * 15f / 100f;
							Destroy(self, 2.0f);
						}
					}
				}
			}
		}
	}
}
