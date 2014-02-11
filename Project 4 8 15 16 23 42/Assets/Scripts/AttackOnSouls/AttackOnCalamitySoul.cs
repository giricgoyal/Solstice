using UnityEngine;
using System.Collections;

public class AttackOnCalamitySoul : MonoBehaviour {
	
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
			
			// effect of defensive spell
			if (Utilities.defensiveSpell == true) {
				distance = Vector3.Distance(target.transform.position, transform.position);
				// this is what will kill them if player casts spell
				// will depend on the season and the soul effected also the spell casted
				if (distance < Utilities.defensiveAttackDistance) {
					if (self.GetComponent<LongRangeEnemyScript>().seasonType == Utilities.winter) {
						if (Utilities.currentSeason != Utilities.winter) {
							self.GetComponent<CalamitySoulScript>().isActive = false;
							self.renderer.material.color = Color.white;
							Utilities.magiaBarWinter += Utilities.magiaBarWinter * 3.5f / 100f;
							Utilities.magiaBarWinter += Utilities.magiaBarWinter * 3.5f / 100f;
							Destroy(self, 2.0f);
						}
					}
				}
			}
			
			
			// effect of offensive spell
			// this part is in OffensiveAttack.cs file
			// skipped from this file
			
			
			// effect of calamity spell
			if (Utilities.calumitySpell == true) {
				distance = Vector3.Distance(target.transform.position, transform.position);
				if (distance < Utilities.calamityAttackRadius) {
					if (self.GetComponent<LongRangeEnemyScript>().seasonType == Utilities.winter) {
						if (Utilities.currentSeason == Utilities.winter) {
							self.GetComponent<CalamitySoulScript>().isActive = false;
							self.renderer.material.color = Color.white;
							Utilities.magiaBarWinter += Utilities.magiaBarWinter * 3.5f / 100f;
							Destroy(self, 2.0f);
						}
					}
				}
			}
		}
	}
}