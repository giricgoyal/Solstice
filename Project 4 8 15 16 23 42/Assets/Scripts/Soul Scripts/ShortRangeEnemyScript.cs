using UnityEngine;
using System.Collections;

public class ShortRangeEnemyScript : MonoBehaviour {
	
	float dist;
	public GameObject target;
	public GameObject self;
	public GameObject attackEffect;
	public float lookAtDistance = 35.0f;
	public float chargeRange = 35.0f;
	public float moveSpeed = 3.0f;
	public float closeRange = 5.0f;
	public float damping = 6.0f;
	private bool isItAttacking = false;
	public bool isIdle = true;
	public bool isActive = true;
	public bool isWalking = false;
	public bool isAttacking = false;
	public bool isAttacked = false;
	public bool isDestroying = false;
	public bool isAboutToDestroy = false;
	public int seasonType;
	
	public Material winter;
	public Material summer;
	public Material spring;
	public Material fall;
	
	public GameObject fireOnSoul;
	public GameObject iceOnSoul;
	public GameObject flowerOnSoul;
	public GameObject leafOnSoul;
	
	public GameObject die;
	
	public bool walk = true;
	int whatAttacked = -1;
	float startTime;
	
	GameObject fire;
	GameObject ice;
	GameObject flower;
	GameObject leaf;
	GameObject dieEffect;
	
	public void setDieEffect() {
		dieEffect = Instantiate(die, transform.position, new Quaternion(3f,5f,66f,0.7f)) as GameObject;
		dieEffect.particleSystem.enableEmission = true;
		/*
		while (effect.particleSystem.startSize >= 0) {
			effect.particleSystem.startSize -= Time.deltaTime;
		}*/
		//Destroy(dieEffect, 2);
	}
	
	public void setFire(GameObject fireOnSoul) {
		this.fireOnSoul = fireOnSoul;
		walk = false;
		whatAttacked = Utilities.summer;
		startTime = Utilities.offensiveSpellTime;
	}
	
	public void setIce(GameObject iceOnSoul) {
		this.iceOnSoul = iceOnSoul;
		walk = false;
		whatAttacked = Utilities.winter;
		startTime = Utilities.offensiveSpellTime;
	}
	
	public void setLeaf(GameObject leafOnSoul) {
		this.leafOnSoul = leafOnSoul;
		walk = false;
		whatAttacked = Utilities.fall;
		startTime = Utilities.offensiveSpellTime;
	}
	
	public void setFlower(GameObject flowerOnSoul) {
		this.flowerOnSoul = flowerOnSoul;
		walk = false;
		whatAttacked = Utilities.spring;
		startTime = Utilities.offensiveSpellTime;
	}
	
	// Use this for initialization
	void Start () {
		if (Utilities.state == Utilities.stateMainGame) {
			lookAtDistance = 35.0f;
			chargeRange = 35.0f;
			closeRange = 5.0f;
			moveSpeed = 3.0f;
			damping = 6.0f;
			isItAttacking = false;
			self = GameObject.Find(name)as GameObject;
			//print(self.name);
			isActive = true;
			walk = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Utilities.state == Utilities.stateMainGame) {
			selectTarget();
			
			if (whatAttacked == Utilities.winter) {
				if (iceOnSoul != null) 
					iceOnSoul.transform.position = transform.position;
				startTime -= Time.deltaTime;
				if (startTime < 0) {
					walk = true;
					whatAttacked = -1;
				} 
			}
			else if (whatAttacked == Utilities.summer) {
				if (fireOnSoul != null)
					fireOnSoul.transform.position = transform.position;
				startTime -= Time.deltaTime;
				if (startTime < 0) {
					walk = true;
					whatAttacked = -1;
				}
			}
			else if (whatAttacked == Utilities.spring) {
				if (flowerOnSoul != null)
					flowerOnSoul.transform.position = transform.position;
				startTime -= Time.deltaTime;
				if (startTime < 0) {
					walk = true;
					whatAttacked = -1;
				}
			}
			else if (whatAttacked == Utilities.fall) {
				if (leafOnSoul != null)
					leafOnSoul.transform.position = transform.position;
				startTime -= Time.deltaTime;
				if (startTime < 0) {
					walk = true;
					whatAttacked = -1;
				}
			}
			
			if (isActive) {
				if (this != null && target != null) { 
					dist = Vector3.Distance(target.transform.position, transform.position);
					if (dist < lookAtDistance) {
						isItAttacking = false;
						//renderer.material.color = Color.yellow;
						lookAt();
					}
					if (dist > lookAtDistance) {
						isItAttacking = false;
						//renderer.material.color = Color.green;
					}
					if (dist < chargeRange) {
						if (walk) {
							charge();
						}
					}
					if (dist < closeRange) {
						if (target.Equals(GameObject.FindGameObjectWithTag("Player")) && !Utilities.defensiveSpell) {
							print ("1");
							attack ();
							destroySelf(0);
							walk = false;
						}
						else if (target.Equals(GameObject.FindGameObjectWithTag("Player")) && Utilities.defensiveSpell) {
							print ("2");
							isAttacked = true;
							isItAttacking = false;
							destroySelf(4);
							walk = false;
							isWalking = false;
							isAboutToDestroy = true;
						}
						else if (!target.Equals(GameObject.FindGameObjectWithTag("Player"))) {
							//destroySelf(4);
							print ("3");
							walk = false;
						}
					}
					
					if (isItAttacking) {
						//renderer.material.color = Color.red;
					}
					if (target.CompareTag("Player") && !walk && whatAttacked == -1) {
						walk = true;
					}
					//nullify();
					destroyEachOther();
				}
			}
			if (dieEffect != null) {
				if (dieEffect.particleSystem.enableEmission) {
					while (dieEffect.particleSystem.startSize <= 10) {
						dieEffect.particleSystem.startSize += Time.deltaTime * 2;
					}
				}
			}
		}	
	}
	
	GameObject getNearestFire() {
		GameObject[] fires = GameObject.FindGameObjectsWithTag("attractSummer");
		GameObject nearest;
		if (fires.Length != 0) {
			nearest = fires[0];
			float distance = float.MaxValue;
			foreach (GameObject g in fires) {
				if (Vector3.Distance(g.transform.position, transform.position) < distance) {
					distance = Vector3.Distance(g.transform.position, transform.position);
					nearest = g;
				}
			}
			return nearest;
		}
		return target;
	}
	
	GameObject getNearestIce() {
		GameObject[] ice = GameObject.FindGameObjectsWithTag("attractWinter");
		GameObject nearest;
		if (ice.Length != 0) {
			nearest = ice[0];
			float distance = float.MaxValue;
			foreach (GameObject g in ice) {
				if (Vector3.Distance(g.transform.position, transform.position) < distance) {
					distance = Vector3.Distance(g.transform.position, transform.position);
					nearest = g;
				}
			}
			return  nearest;
		}
		return target;
	}
	
	GameObject getNearestFlower() {
		GameObject[] flowers = GameObject.FindGameObjectsWithTag("attractSpring");
		GameObject nearest;
		if (flowers.Length  != 0) {
			nearest = flowers[0];
			float distance = float.MaxValue;
			foreach (GameObject g in flowers) {
				if (Vector3.Distance(g.transform.position, transform.position) < distance) {
					distance = Vector3.Distance(g.transform.position, transform.position);
					nearest = g;
				}
			}
			return  nearest;
		}
		return target;
	}
	
	GameObject getNearestLeaf() {
		GameObject[] leaves = GameObject.FindGameObjectsWithTag("attractFall");
		GameObject nearest;
		if (leaves.Length != 0) {
			nearest = leaves[0];
			float distance = float.MaxValue;
			foreach (GameObject g in leaves) {
				if (Vector3.Distance(g.transform.position, transform.position) < distance) {
					distance = Vector3.Distance(g.transform.position, transform.position);
					nearest = g;
				}
			}
			return  nearest;
		}
		return target;
	}
	
	
	
	
	void destroyEachOther() {
		// opposite souls first
		// spell on souls first
		if (whatAttacked == Utilities.summer) {
			if (seasonType == Utilities.winter) {
				GameObject[] array = GameObject.FindGameObjectsWithTag("shortSummer");
				if (array != null) {
					foreach (GameObject g in array) {
						float distance = Vector3.Distance(g.transform.position, transform.position);
						if (distance < Utilities.minDistBwSouls) {
							isAttacked = true;
							walk = false;
							isWalking = false;
							g.GetComponent<ShortRangeEnemyScript>().isWalking = false;
							g.GetComponent<ShortRangeEnemyScript>().walk = false;
							g.GetComponent<ShortRangeEnemyScript>().isAttacked = true;
							g.GetComponent<ShortRangeEnemyScript>().destroySelf(4);
							destroySelf(4);
							//Destroy(g, 4);
							//Destroy(GameObject.Find(name), 4);
							Destroy(fireOnSoul, 4);
							break;
						}
					}
				}
			}
		}
		
		if (whatAttacked == Utilities.winter) {
			if (seasonType == Utilities.summer) {
				GameObject[] array = GameObject.FindGameObjectsWithTag("shortWinter");
				if (array != null) {
					foreach (GameObject g in array) {
						float distance = Vector3.Distance(g.transform.position, transform.position);
						if (distance < Utilities.minDistBwSouls) {
							isAttacked = true;
							walk = false;
							isWalking = false;
							g.GetComponent<ShortRangeEnemyScript>().isWalking = false;
							g.GetComponent<ShortRangeEnemyScript>().walk = false;
							g.GetComponent<ShortRangeEnemyScript>().isAttacked = true;
							g.GetComponent<ShortRangeEnemyScript>().destroySelf(4);
							destroySelf(4);
							//Destroy(g, 4);
							//Destroy(GameObject.Find(name), 4);
							Destroy(iceOnSoul , 4);
							break;
						}
					}
				}
			}
		}
		
		if (whatAttacked == Utilities.spring) {
			if (seasonType == Utilities.fall) {
				GameObject[] array = GameObject.FindGameObjectsWithTag("shortSpring");
				if (array != null) {
					foreach (GameObject g in array) {
						float distance = Vector3.Distance(g.transform.position, transform.position);
						if (distance < Utilities.minDistBwSouls) {
							isAttacked = true;
							walk = false;
							isWalking = false;
							g.GetComponent<ShortRangeEnemyScript>().isWalking = false;
							g.GetComponent<ShortRangeEnemyScript>().walk = false;
							g.GetComponent<ShortRangeEnemyScript>().isAttacked = true;
							g.GetComponent<ShortRangeEnemyScript>().destroySelf(4);
							destroySelf(4);
							//Destroy(g, 4);
							//Destroy(GameObject.Find(name), 4);
							Destroy(flowerOnSoul, 4);
							break;
						}
					}
				}
			}
		}
		
		if (whatAttacked == Utilities.fall) {
			if (seasonType == Utilities.spring) {
				GameObject[] array = GameObject.FindGameObjectsWithTag("shortFall");
				if (array != null) {
					foreach (GameObject g in array) {
						float distance = Vector3.Distance(g.transform.position, transform.position);
						if (distance < Utilities.minDistBwSouls) {
							isAttacked = true;
							walk = false;
							isWalking = false;
							g.GetComponent<ShortRangeEnemyScript>().isWalking = false;
							g.GetComponent<ShortRangeEnemyScript>().walk = false;
							g.GetComponent<ShortRangeEnemyScript>().isAttacked = true;
							g.GetComponent<ShortRangeEnemyScript>().destroySelf(4);
							destroySelf(4);
							//Destroy(g, 4);
							//Destroy(GameObject.Find(name), 4);
							Destroy(leafOnSoul, 4);
							break;
						}
					}
				}
			}
		}
		
		// spell on terrain now
		if (whatAttacked == -1) {
			if (seasonType == Utilities.summer) {
				GameObject[] arr = GameObject.FindGameObjectsWithTag("attractSummer");
				if (arr != null) {
					foreach (GameObject g in arr) {
						float distance1 = Vector3.Distance(g.transform.position, transform.position);
						if (distance1 < 3.0f) {
							GameObject[] array = GameObject.FindGameObjectsWithTag("shortWinter");
							if (array != null) {
								foreach (GameObject o in array) {
									float distance2 = Vector3.Distance(o.transform.position, transform.position);
									if (distance2 < 2.0f) {
										isAttacked = true;
										walk = false;
										isWalking = false;
										o.GetComponent<ShortRangeEnemyScript>().isWalking = false;
										o.GetComponent<ShortRangeEnemyScript>().walk = false;
										o.GetComponent<ShortRangeEnemyScript>().isAttacked = true;
										o.GetComponent<ShortRangeEnemyScript>().destroySelf(4);
										destroySelf(4);
										Destroy(g, 4);
										//Destroy(GameObject.Find(name), 4);
										//Destroy(o, 4);
										break;
									}
								}
							}
						}
					}
				}
			}

			if (seasonType == Utilities.winter) {
				GameObject[] arr = GameObject.FindGameObjectsWithTag("attractWinter");
				if (arr != null) {
					foreach (GameObject g in arr) {
						float distance1 = Vector3.Distance(g.transform.position, transform.position);
						if (distance1 < 3.0f) {
							GameObject[] array = GameObject.FindGameObjectsWithTag("shortSummer");
							if (array != null) {
								foreach (GameObject o in array) {
									float distance2 = Vector3.Distance(o.transform.position, transform.position);
									if (distance2 < 2.0f) {
										isAttacked = true;
										walk = false;
										isWalking = false;
										o.GetComponent<ShortRangeEnemyScript>().isWalking = false;
										o.GetComponent<ShortRangeEnemyScript>().walk = false;
										o.GetComponent<ShortRangeEnemyScript>().isAttacked = true;
										o.GetComponent<ShortRangeEnemyScript>().destroySelf(4);
										destroySelf(4);
										Destroy(g, 4);
										//Destroy(GameObject.Find(name), 4);
										//Destroy(o, 4);
										break;
									}
								}
							}
						}
					}
				}
			}
			
			if (seasonType == Utilities.spring) {
				GameObject[] arr = GameObject.FindGameObjectsWithTag("attractSpring");
				if (arr != null) {
					foreach (GameObject g in arr) {
						float distance1 = Vector3.Distance(g.transform.position, transform.position);
						if (distance1 < 3.0f) {
							GameObject[] array = GameObject.FindGameObjectsWithTag("shortFall");
							if (array != null) {
								foreach (GameObject o in array) {
									float distance2 = Vector3.Distance(o.transform.position, transform.position);
									if (distance2 < 2.0f) {
										print ("testing");
										isAttacked = true;
										walk = false;
										isWalking = false;
										o.GetComponent<ShortRangeEnemyScript>().isWalking = false;
										o.GetComponent<ShortRangeEnemyScript>().walk = false;
										o.GetComponent<ShortRangeEnemyScript>().isAttacked = true;
										o.GetComponent<ShortRangeEnemyScript>().destroySelf(4);
										destroySelf(4);
										Destroy(g, 4);
										//Destroy(GameObject.Find(name), 4);
										//Destroy(o, 4);
										break;
									}
								}
							}
						}
					}
				}
			}
			
			if (seasonType == Utilities.fall) {
				GameObject[] arr = GameObject.FindGameObjectsWithTag("attractFall");
				if (arr != null) {
					foreach (GameObject g in arr) {
						float distance1 = Vector3.Distance(g.transform.position, transform.position);
						if (distance1 < 3.0f) {
							GameObject[] array = GameObject.FindGameObjectsWithTag("shortSpring");
							if (array != null) {
								foreach (GameObject o in array) {
									float distance2 = Vector3.Distance(o.transform.position, transform.position);
									if (distance2 < 2.0f) {
										print ("testing");
										isAttacked = true;
										walk = false;
										isWalking = false;
										o.GetComponent<ShortRangeEnemyScript>().isWalking = false;
										o.GetComponent<ShortRangeEnemyScript>().walk = false;
										o.GetComponent<ShortRangeEnemyScript>().isAttacked = true;
										o.GetComponent<ShortRangeEnemyScript>().destroySelf(4);
										destroySelf(4);
										Destroy(g, 4);
										//Destroy(GameObject.Find(name), 4);
										//Destroy(o, 4);
										break;
									}
								}
							}
						}
					}
				}
			}
			
		}
	}
	
	
	
	void nullify() {
		//if (Utilities.offensiveSpell) {
			if (seasonType == Utilities.winter) {
				GameObject[] array = GameObject.FindGameObjectsWithTag("shortSummer");
				if (array != null) {
					foreach (GameObject g in array) {
						float distance = Vector3.Distance(g.transform.position, transform.position);
						if (distance < Utilities.minDistBwSouls) {
							isActive = false;
							g.GetComponent<ShortRangeEnemyScript>().isActive = false;
							renderer.material.color = Color.white;
							g.renderer.material.color = Color.white;
						}
					}
				}
			}
			
			if (seasonType == Utilities.spring) {
				GameObject[] array = GameObject.FindGameObjectsWithTag("shortFall");
				if (array != null) {
					foreach (GameObject g in array) {
						float distance = Vector3.Distance(g.transform.position, transform.position);
						if (distance < Utilities.minDistBwSouls) {
							isActive = false;
							g.GetComponent<ShortRangeEnemyScript>().isActive = false;
							renderer.material.color = Color.white;
							g.renderer.material.color = Color.white;
						}
					}
				}
			}
			
			if (seasonType == Utilities.summer) {
				GameObject[] array = GameObject.FindGameObjectsWithTag("shortWinter");
				if (array != null) {
					foreach (GameObject g in array) {
						float distance = Vector3.Distance(g.transform.position, transform.position);
						if (distance < Utilities.minDistBwSouls) {
							isActive = false;
							g.GetComponent<ShortRangeEnemyScript>().isActive = false;
							renderer.material.color = Color.white;
							g.renderer.material.color = Color.white;
						}
					}
				}
			}
			
			if (seasonType == Utilities.fall) {
				GameObject[] array = GameObject.FindGameObjectsWithTag("shortSpring");
				if (array != null) {
					foreach (GameObject g in array) {
						float distance = Vector3.Distance(g.transform.position, transform.position);
						if (distance < Utilities.minDistBwSouls) {
							isActive = false;
							g.GetComponent<ShortRangeEnemyScript>().isActive = false;
							renderer.material.color = Color.white;
							g.renderer.material.color = Color.white;
						}
					}
				}
			}
		//}
	}

	
	void selectTarget() {
		if (isActive) {
			if (seasonType == Utilities.winter) {
			//	renderer.material.color = Utilities.winterColorOffensive;
				if (Utilities.attractWinter) {
					target = getNearestIce();
				} 
				else {
					target = GameObject.FindGameObjectWithTag("Player");
				}
			}
			if (seasonType == Utilities.summer) {
			//	renderer.material.color = Utilities.summerColorOffensive;
				if (Utilities.attractSummer) {
					target = getNearestFire();
				}
				else {
					target = GameObject.FindGameObjectWithTag("Player");
				}
			}
			if (seasonType == Utilities.spring) {
			//	renderer.material.color = Utilities.springColorOffensive;
				if (Utilities.attractSpring) {
					target = getNearestFlower();
				}
				else {
					target = GameObject.FindGameObjectWithTag("Player");
				}
			}
			if (seasonType == Utilities.fall) {
			//	renderer.material.color = Utilities.fallColorOffensive;
				if (Utilities.attractFall) {
					target = getNearestLeaf();
				}
				else {
					target = GameObject.FindGameObjectWithTag("Player");
				}
			}
		}
	}
	
	void lookAt() {
		Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
		isIdle = true;
	}
	
	void charge() {
		if (!isAboutToDestroy) {
			isItAttacking = true;
			//renderer.material.color = Color.red;
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
			isWalking = true;
			isIdle = false;
		}
	}
	
	void destroySelf(int time) {
	//	if (!Utilities.attractWinter && !Utilities.attractSummer && !Utilities.attractSpring && !Utilities.attractFall) {
			//setDieEffect();
		DestroyObject(GameObject.Find(name), time);
		if (tag.Equals("shortWinter") || Utilities.magiaBarWinter <= 100) {
			if (100 - Utilities.magiaBarWinter < 10) {
				Utilities.magiaBarWinter = 100;
			}
			else {
				Utilities.magiaBarWinter +=10;
			}
		}
		if (tag.Equals("shortSummer") || Utilities.magiaBarSummer <= 100) {
			if (100 - Utilities.magiaBarSummer < 10) {
				Utilities.magiaBarSummer = 100;
			}
			else {
				Utilities.magiaBarSummer += 10;
			}
		}
		if (tag.Equals("shortSpring") || Utilities.magiaBarSpring <= 100) {
			if (100 - Utilities.magiaBarSpring < 10) {
				Utilities.magiaBarSpring = 100;
			}
			else {
				Utilities.magiaBarSpring += 10;
			}
		}
		if (tag.Equals("shortFall") || Utilities.magiaBarFall <= 100) {
			if (100 - Utilities.magiaBarFall < 10) {
				Utilities.magiaBarFall = 100;
			}
			else {
				Utilities.magiaBarFall += 10;
			}
		}
	//	}
	}
	
	public void attack() {
		if (!isAboutToDestroy) {
			Utilities.saludBar -= Utilities.saludBar * 5.0f / 100f * Utilities.shortRangeSoul;
			Utilities.attackTimeShort = Time.time;
			Utilities.isShortRangeAttacking = true;
			isAttacking = true;
			isIdle = false;
		}
	}
	
}

