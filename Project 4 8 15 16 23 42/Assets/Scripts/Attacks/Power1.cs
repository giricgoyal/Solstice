using UnityEngine;
using System.Collections;

public class Power1 : MonoBehaviour {
	
	public GameObject player;
	public GameObject spell;
	public GameObject heal;
	public GameObject rippleAudio;
	
	RaycastHit hit;
	GameObject newOffensiveEffect;
	float startTime;
	
	float selectedBarValue;
	
	GameObject fire;
	GameObject ice;
	GameObject leaf;
	GameObject flower;
	
	public GameObject winterDefenseEffect;
	public GameObject springDefenseEffect;
	public GameObject summerDefenseEffect;
	public GameObject fallDefenseEffect;
	
	public GameObject fireOnTerrain;
	public GameObject iceOnTerrain;
	public GameObject leafOnTerrain;
	public GameObject flowerOnTerrain;
	
	public GameObject fireOnSoul;
	public GameObject iceOnSoul;
	public GameObject flowerOnSoul;
	public GameObject leafOnSoul;
	
	int healthPieces = 0;
	bool healthPieceWinter = false;
	bool healthPieceSummer = false;
	bool healthPieceSpring = false;
	bool healthPieceFall = false;
	bool healthPieceComplete = false;
	string hpWinter = "healthPieceWinter#$#$";
	string hpSummer = "healthPieceSummer@#@#";
	string hpSpring = "healthPieceSpring&%&%";
	string hpFall = "healthPieceFall@&@&";
	string php = "playerHealthPiece";
	
	
	int winterDefenseCount = 0;
	int springDefenseCount = 0;
	int summerDefenseCount = 0;
	int fallDefenseCount = 0;
	int ultimateDefenseCount = 0;
	bool winterDefense = false;
	bool summerDefense = false;
	bool springDefense = false;
	bool fallDefense = false;
	bool ultimateDefense = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	bool isBarEmpty() {
		if (selectedBarValue < 2.0f) {
			return true;
		}
		return false;
	}
	
	// Update is called once per frame
	void Update () {
		// Update spell effect based on current season
		if (Utilities.state == Utilities.stateMainGame) {
			if (Utilities.currentSeason == Utilities.winter) {
				spell = GameObject.Find("SpellWinterOffensive");
				selectedBarValue = Utilities.magiaBarWinter;
			}
			else if (Utilities.currentSeason == Utilities.spring) {
				spell = GameObject.Find("SpellSpringOffensive");
				selectedBarValue = Utilities.magiaBarSpring;
			}
			else if (Utilities.currentSeason == Utilities.summer) {
				spell = GameObject.Find("SpellSummerOffensive");
				selectedBarValue = Utilities.magiaBarSummer;
			}
			else if (Utilities.currentSeason == Utilities.fall) {
				spell = GameObject.Find("SpellFallOffensive");
				selectedBarValue = Utilities.magiaBarFall;
			}
			if (!Utilities.offensiveSpell) {
				// check for input "offensive"
				if (Input.GetButtonUp("power1")) {
					if (!Utilities.calumitySpell && !Utilities.defensiveSpell && !Utilities.calumitySpell) {
						Vector3 forward = player.transform.TransformDirection(Vector3.forward);
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						if (Physics.Raycast(ray, out hit, 500.0f)) {
							if (!isBarEmpty()) {
								//if (Physics.Raycast(transform.position, forward, out hit, 500.0f, 1)) {
								print(hit.collider.name);
								
								if (hit.collider.CompareTag(player.tag)) {
									startTime = Utilities.offensiveSpellTime;
									newOffensiveEffect = Instantiate(spell, hit.point,  new Quaternion(0f,0f,0f,0f)) as GameObject;
									newOffensiveEffect.particleSystem.enableEmission = true;
									if (Utilities.currentSeason == Utilities.winter) {
										Utilities.offensiveSpell = true;
										newOffensiveEffect.GetComponent<ParticleSystem>().startColor = Utilities.winterColorOffensive;
										newOffensiveEffect.tag = php;
										newOffensiveEffect.name = hpWinter;
										Utilities.magiaBarWinter -= 1;
									}
									if (Utilities.currentSeason == Utilities.spring) {
										Utilities.offensiveSpell = true;
										newOffensiveEffect.GetComponent<ParticleSystem>().startColor = Utilities.springColorOffensive;
										newOffensiveEffect.tag = php;
										newOffensiveEffect.name = hpSpring;
										Utilities.magiaBarSpring -= 1;
									}
									if (Utilities.currentSeason == Utilities.summer) {
										Utilities.offensiveSpell = true;
										newOffensiveEffect.GetComponent<ParticleSystem>().startColor = Utilities.summerColorOffensive;
										newOffensiveEffect.tag = php;
										newOffensiveEffect.name = hpSummer;
										Utilities.magiaBarSummer -= 1;
									}
									if (Utilities.currentSeason == Utilities.fall) {
										Utilities.offensiveSpell = true;
										newOffensiveEffect.GetComponent<ParticleSystem>().startColor = Utilities.fallColorOffensive;
										newOffensiveEffect.tag = php;
										newOffensiveEffect.name = hpFall;
										Utilities.magiaBarFall -= 1;
									}
								}
								
								
								
								// for the particle effects
								if (Utilities.currentSeason == Utilities.summer) {
									if (hit.collider.CompareTag("terrain")) {
										startTime = Utilities.offensiveSpellTime;
										Utilities.magiaBarSummer -= 1;
										Utilities.offensiveSpell = true;
										Utilities.attractSummer = true;
										fire = Instantiate(fireOnTerrain, hit.point,  new Quaternion(0f,0f,0f,0f)) as GameObject;
										//fire = Instantiate(spell, hit.point, new Quaternion(0f,0f,0f,0f)) as GameObject;
										//fire.GetComponent<ParticleSystem>().enableEmission = true;
										//fire.GetComponent<ParticleSystem>().startColor = Utilities.summerColorOffensive;
										fire.tag = "attractSummer";
									}
									
									else if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("collider")) { }
									
									else if (hit.collider.CompareTag("shortWinter") || hit.collider.CompareTag("shortFall") || hit.collider.CompareTag("shortSummer") || hit.collider.CompareTag("shortSpring")) {
										startTime = Utilities.offensiveSpellTime;
										if (!hit.collider.CompareTag("shortSummer")) {
											startTime = Utilities.offensiveSpellTime;
											Utilities.magiaBarSummer -= 1;
											Utilities.offensiveSpell = true;
											Utilities.attractSummer = true;	
											burn (hit);
										}
									}
								}
								
								if (Utilities.currentSeason == Utilities.winter) {
									if (hit.collider.CompareTag("terrain")) {
										startTime = Utilities.offensiveSpellTime;
										Utilities.magiaBarWinter -= 1;
										Utilities.offensiveSpell = true;
										Utilities.attractWinter = true;
										// chamge with particle effect
										newOffensiveEffect = Instantiate(iceOnTerrain, hit.point,  new Quaternion(0f,0f,0f,0f)) as GameObject;
										//newOffensiveEffect.particleSystem.enableEmission = true;
										newOffensiveEffect.tag = "attractWinter";
										//newOffensiveEffect.GetComponent<ParticleSystem>().startColor = Utilities.winterColorOffensive;
									}
									
									else if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("collider")) { }
									
									else if (hit.collider.CompareTag("shortWinter") || hit.collider.CompareTag("shortFall") || hit.collider.CompareTag("shortSummer") || hit.collider.CompareTag("shortSpring")) {
										startTime = Utilities.offensiveSpellTime;
										if (!hit.collider.CompareTag("shortWinter")) {
											startTime = Utilities.offensiveSpellTime;
											Utilities.magiaBarWinter -= 1;
											Utilities.offensiveSpell = true;
											Utilities.attractWinter = true;
											freeze (hit);
										}
									}
								}
								
								if (Utilities.currentSeason == Utilities.spring) {
									if (hit.collider.CompareTag("terrain")) {
										startTime = Utilities.offensiveSpellTime;
										Utilities.magiaBarSpring -= 1;
										Utilities.offensiveSpell = true;
										Utilities.attractSpring = true;
										// change with particle effect
										newOffensiveEffect = Instantiate(flowerOnTerrain, hit.point,  new Quaternion(0f,0f,0f,0f)) as GameObject;
										//newOffensiveEffect.particleSystem.enableEmission = true;
										newOffensiveEffect.tag = "attractSpring";
										//newOffensiveEffect.GetComponent<ParticleSystem>().startColor = Utilities.springColorOffensive;
										
									}
									
									else if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("collider")) { }
									
									else if (hit.collider.CompareTag("shortWinter") || hit.collider.CompareTag("shortFall") || hit.collider.CompareTag("shortSummer") || hit.collider.CompareTag("shortSpring")) {
										startTime = Utilities.offensiveSpellTime;
										if (!hit.collider.CompareTag("shortSpring")) {
											startTime = Utilities.offensiveSpellTime;
											Utilities.magiaBarSpring -= 1;
											Utilities.offensiveSpell = true;
											Utilities.attractSpring = true;
											blossom (hit);
										}
									}
								}
								
								if (Utilities.currentSeason == Utilities.fall) {
									if (hit.collider.CompareTag("terrain")) {
										startTime = Utilities.offensiveSpellTime;
										Utilities.magiaBarFall -= 1;
										Utilities.offensiveSpell = true;
										Utilities.attractFall = true;
										// change with particle effect
										newOffensiveEffect = Instantiate(leafOnTerrain, hit.point,  new Quaternion(0f,0f,0f,0f)) as GameObject;
										//newOffensiveEffect.particleSystem.enableEmission = true;
										newOffensiveEffect.tag = "attractFall";
										//newOffensiveEffect.GetComponent<ParticleSystem>().startColor = Utilities.fallColorOffensive;
										
									}
									
									else if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("collider")) { }
									
									else if (hit.collider.CompareTag("shortWinter") || hit.collider.CompareTag("shortFall") || hit.collider.CompareTag("shortSummer") || hit.collider.CompareTag("shortSpring")) {
										startTime = Utilities.offensiveSpellTime;
										if (!hit.collider.CompareTag("shortFall")) {
											startTime = Utilities.offensiveSpellTime;
											Utilities.magiaBarFall -= 1;
											Utilities.offensiveSpell = true;
											Utilities.attractFall = true;
											melancholy (hit);
										}
									}
								}
								
								
								
								
								Destroy(newOffensiveEffect, Utilities.offensiveSpellTime);
								Destroy(fire, Utilities.offensiveSpellTime);
								Destroy(ice, Utilities.offensiveSpellTime);
								Destroy(leaf, Utilities.offensiveSpellTime);
								Destroy(flower, Utilities.offensiveSpellTime);
								
								Utilities.offensiveSpell = false;
							}							
						}
					}
				}
			}
			
			GameObject[] g = GameObject.FindGameObjectsWithTag("attractWinter");
			if (g.Length == 0) {
				Utilities.attractWinter = false;
			}
			g = GameObject.FindGameObjectsWithTag("attractSummer");
			if (g.Length == 0) {
				Utilities.attractSummer = false;
			}
			g = GameObject.FindGameObjectsWithTag("attractSpring");
			if (g.Length == 0) {
				Utilities.attractSpring = false;
			}
			g = GameObject.FindGameObjectsWithTag("attractFall");
			if (g.Length == 0) {
				Utilities.attractFall = false;
			}
			
			g = GameObject.FindGameObjectsWithTag(php);
			healthPieces = g.Length;
			bool tempBoolWinter = false;
			bool tempBoolSummer = false;
			bool tempBoolSpring = false;
			bool tempBoolFall = false;
			
			winterDefenseCount = summerDefenseCount = springDefenseCount = fallDefenseCount = 0;
			
			if (g.Length > 0) {
				foreach (GameObject temp in g) {
					tempBoolWinter = tempBoolWinter || temp.name.Equals(hpWinter);
					tempBoolSpring = tempBoolSpring || temp.name.Equals(hpSpring);
					tempBoolSummer = tempBoolSummer || temp.name.Equals(hpSummer);
					tempBoolFall = tempBoolFall || temp.name.Equals(hpFall);
					
					if (temp.name.Equals(hpWinter)) {
						winterDefenseCount++;
					}
					else if (temp.name.Equals(hpSummer)) {
						summerDefenseCount++;
					}
					else if (temp.name.Equals(hpSpring)) {
						springDefenseCount++;
					}
					else if (temp.name.Equals(hpFall)) {
						fallDefenseCount++;
					}
					
				}
			}
			
			healthPieceWinter = tempBoolWinter;
			healthPieceSpring = tempBoolSpring;
			healthPieceSummer = tempBoolSummer;
			healthPieceFall = tempBoolFall;
			healthPieceComplete = healthPieceWinter && healthPieceSpring && healthPieceSummer && healthPieceFall;
			if (healthPieceComplete) {
				if (Utilities.saludBar < 100) {
					Utilities.saludBar += Utilities.saludBar * 5 * Time.deltaTime / 100;
						if (g.Length > 0) {
					foreach (GameObject temp in g) {
						temp.audio.Stop ();	
					}
				}
											print ("Healing");

					if(!heal.audio.isPlaying) {
						heal.audio.Play();
					}									
				}
				
			}
			
			winterDefense = (winterDefenseCount >= 5)?true:false;
			summerDefense = (summerDefenseCount >= 5)?true:false;
			springDefense = (springDefenseCount >= 5)?true:false;
			fallDefense = (fallDefenseCount >= 5)?true:false;
			
			winterDefenseEffect.particleSystem.startColor = Utilities.winterColorOffensive;
			summerDefenseEffect.particleSystem.startColor = Utilities.summerColorOffensive;
			springDefenseEffect.particleSystem.startColor = Utilities.springColorOffensive;
			fallDefenseEffect.particleSystem.startColor = Utilities.fallColorOffensive;
			
			if (winterDefense) {
				winterDefenseEffect.particleSystem.enableEmission = true;
				if (winterDefenseEffect.transform.localScale.x < 1) {
					winterDefenseEffect.transform.localScale = new Vector3(
						winterDefenseEffect.transform.localScale.x + 1.2f * Time.deltaTime,
						winterDefenseEffect.transform.localScale.y + 1.2f * Time.deltaTime,
						winterDefenseEffect.transform.localScale.z + 1.2f * Time.deltaTime);
					
				}
				else {
					winterDefenseEffect.transform.localScale = new Vector3(0f,0f,0f);
				}
				if(!rippleAudio.audio.isPlaying){
					rippleAudio.audio.Play();
				}
			}
			else if (!winterDefense) {
				winterDefenseEffect.particleSystem.enableEmission = false;
				winterDefenseEffect.transform.localScale = new Vector3(0f,0f,0f);
			}
			
			if (summerDefense)  {
				summerDefenseEffect.particleSystem.enableEmission = true;
				if (summerDefenseEffect.transform.localScale.x < 1) {
					summerDefenseEffect.transform.localScale = new Vector3(
						summerDefenseEffect.transform.localScale.x + 1.2f * Time.deltaTime,
						summerDefenseEffect.transform.localScale.y + 1.2f * Time.deltaTime,
						summerDefenseEffect.transform.localScale.z + 1.2f * Time.deltaTime);
					
				}
				else {
					summerDefenseEffect.transform.localScale = new Vector3(0f,0f,0f);
				}
				if(!rippleAudio.audio.isPlaying){
					rippleAudio.audio.Play();
				}
			}
			else if (!summerDefense) {
				summerDefenseEffect.particleSystem.enableEmission = false;
				summerDefenseEffect.transform.localScale = new Vector3(0f,0f,0f);
			}
			
			if (springDefense) {
				springDefenseEffect.particleSystem.enableEmission = true;
				if (springDefenseEffect.transform.localScale.x < 1) {
					springDefenseEffect.transform.localScale = new Vector3(
						springDefenseEffect.transform.localScale.x + 1.2f * Time.deltaTime,
						springDefenseEffect.transform.localScale.y + 1.2f * Time.deltaTime,
						springDefenseEffect.transform.localScale.z + 1.2f * Time.deltaTime);
					
				}
				else {
					springDefenseEffect.transform.localScale = new Vector3(0f,0f,0f);
				}
				if(!rippleAudio.audio.isPlaying){
					rippleAudio.audio.Play();
				}
			}
			else if (!springDefense) {
				springDefenseEffect.particleSystem.enableEmission = false;
				springDefenseEffect.transform.localScale = new Vector3(0f,0f,0f);
			}
			
			if (fallDefense) {
				fallDefenseEffect.particleSystem.enableEmission = true;
				if (fallDefenseEffect.transform.localScale.x < 1) {
					fallDefenseEffect.transform.localScale = new Vector3(
						fallDefenseEffect.transform.localScale.x + 1.2f * Time.deltaTime,
						fallDefenseEffect.transform.localScale.y + 1.2f * Time.deltaTime,
						fallDefenseEffect.transform.localScale.z + 1.2f * Time.deltaTime);
					
				}
				else {
					fallDefenseEffect.transform.localScale = new Vector3(0f,0f,0f);
				}
				if(!rippleAudio.audio.isPlaying){
					rippleAudio.audio.Play();
				}
			}
			else if (!fallDefense) {
				fallDefenseEffect.particleSystem.enableEmission = false;
				fallDefenseEffect.transform.localScale = new Vector3(0f,0f,0f);
			}
			
			ultimateDefense = winterDefense && springDefense && summerDefense && fallDefense;
			if (ultimateDefense) {
			}
			else if (!ultimateDefense) {
			}	
			
			if (winterDefense || springDefense || summerDefense || fallDefense) {
				Utilities.defensiveSpell = true;
			}
			else {
				Utilities.defensiveSpell = false;
			}
		}
	}
	
	void freeze(RaycastHit hit) {
		//ice = Instantiate(iceOnSoul, hit.point, new Quaternion(0f,0f,0f,0f)) as GameObject;
		ice = Instantiate(iceOnSoul, hit.point, new Quaternion(0f,0f,0f,0f)) as GameObject;
		//ice.GetComponent<ParticleSystem>().enableEmission = true;
		//ice.GetComponent<ParticleSystem>().startColor = Utilities.winterColorOffensive;
		ice.tag = "attractWinter";
		ice.transform.position = hit.collider.transform.position;
		hit.collider.GetComponent<ShortRangeEnemyScript>().setIce(ice);
	}
	
	void burn(RaycastHit hit) {
		//fire = Instantiate(fireOnSoul, hit.point, new Quaternion(0f,0f,0f,0f)) as GameObject;
		fire = Instantiate (fireOnSoul, hit.point, new Quaternion(0f,0f,0f,0f)) as GameObject;
		//fire.GetComponent<ParticleSystem>().enableEmission = true;
		//fire.GetComponent<ParticleSystem>().startColor = Utilities.summerColorOffensive;
		fire.tag = "attractSummer";
		fire.transform.position = hit.collider.transform.position;
		hit.collider.GetComponent<ShortRangeEnemyScript>().setFire(fire);
	}
	
	void blossom(RaycastHit hit) {
		//flower = Instantiate(flowerOnSoul, hit.point, new Quaternion(0f,0f,0f,0f)) as GameObject;
		flower = Instantiate(flowerOnSoul, hit.point, new Quaternion(0f,0f,0f,0f)) as GameObject;
		//flower.GetComponent<ParticleSystem>().enableEmission = true;
		//flower.GetComponent<ParticleSystem>().startColor = Utilities.springColorOffensive;
		flower.tag = "attractSpring";
		flower.transform.position = hit.collider.transform.position;
		hit.collider.GetComponent<ShortRangeEnemyScript>().setFlower(flower);
	}
	
	void melancholy(RaycastHit hit) {
		//leaf = Instantiate(leafOnSoul, hit.point, new Quaternion(0f,0f,0f,0f)) as GameObject;
		leaf = Instantiate (leafOnSoul, hit.point, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
		//leaf.GetComponent<ParticleSystem>().enableEmission = true;
		//leaf.GetComponent<ParticleSystem>().startColor = Utilities.fallColorOffensive;
		leaf.tag = "attractFall";
		leaf.transform.position = hit.collider.transform.position;
		hit.collider.GetComponent<ShortRangeEnemyScript>().setLeaf(leaf);
	}
}
