using UnityEngine;
using System.Collections;

public class Utilities : MonoBehaviour {
	
	public static bool isWall = true;
	public static float scaleFactor;
	
	// season variables. 
	// each object in the environment will have their own script. 
	// And how that object behaves will depend on the season. 
	// So each script will make a reference to these variables
	// and check for the currentSeason's value.
	
	// Add all the variables in this utilities.cs file so that everyone can refer to them easily
	// NOTE: Don't forget to make them "public" and "static".
	
	public static int none = 0;
	
	public static int summer = 1;
	public static int fall = 2;
	public static int winter = 3;
	public static int spring = 4;
	public static int currentSeason = fall;
	public static int changedSeason;
	public static bool seasonChanged = false;
	public static float seasonCounter = 0.0f;
	public static float seasonCounterMax = 20.0f;
	
	
	// please in every script you write for the main game
	// first check if the state is equal to stateMainGame
	// because we want the scripts to work only when  we are 
	// stateMainGame state.
	//
	// if (utilities.state == Utilities.stateMainGame) {
			// do all your processing in this block
	// }
	public static int state; 
	public static int stateStartGame = 1; 	// for the main screen/ welcome screen
	public static int stateMainGame = 2; 	// for the main game
	public static int stateEndGame = 3;		// for the end game screen
	
	
	// what is attcking
	public static int shortRangeSoul = 1;
	public static int longRangeSoul = 2;
	public static int calumitySoul = 3;
	public static float attackTimeShort;
	public static float attackTimeLong;
	public static float attackTimeCalumity;
	public static bool isShortRangeAttacking = false;
	public static bool isLongRangeAttacking = false;
	public static bool isCalumityAttacking = false;
	
	
	// player attack variables
	public static bool defensiveSpell = false;
	public static bool offensiveSpell = false;
	public static bool calumitySpell = false;
	public static float defensiveSpellTime = 3;
	public static float offensiveSpellTime = 5;
	public static float calumitySpellTime = 20;
	public static float defensiveAttackDistance = 5;
	public static float calamityAttackRadius = 30;
	
	// player attributes
	public static float saludBar = 100;
	public static float magiaBarWinter = 100;
	public static float magiaBarSummer = 100;
	public static float magiaBarSpring = 100;
	public static float magiaBarFall = 100;
	
	// world attributes
	public static bool isWaterFrozen = false;
	public static float freezeTimer = 0.0f;
	public static float steamTimer= 0.0f;
	public static float maxFreezeTimer = seasonCounterMax;
	
	// attributes for power1 attraction
	public static bool attractWinter = false;
	public static bool attractSpring = false;
	public static bool attractSummer = false;
	public static bool attractFall = false;
	
	
	
	// attribute for offensive (power1) colors
	public static Color32 winterColorOffensive = new Color32(12, 56, 74, 14);
	public static Color32 summerColorOffensive = new Color32(99, 89, 18, 14);
	public static Color32 springColorOffensive = new Color32(11, 59, 3, 14);
	public static Color32 fallColorOffensive = new Color32(53, 17, 3, 14);
	public static Color32 winterFrozenColor = new Color32(12, 56, 74, 255);
	public static Color32 summerBurnColor = new Color32(99, 89, 18, 255);
	public static Color32 springBlossomColor = new Color32(11, 59, 3, 255);
	public static Color32 fallMelancholyColor = new Color32(53, 17, 3, 255);
	
	public static float griffonTimer = 0f;
	
	public static float minDistBwSouls = 6.0f;
	
	
	
	// Use this for initialization
	void Start () {
		state = stateMainGame;
		/*
		if (isWall) {
			scaleFactor = 1920.0f/1366.0f;
			Screen.SetResolution(1920,1080,false);
		}
		else {
			scaleFactor = 1;
		}
		//Screen.SetResolution((int)(1366*scaleFactor), (int)(768*scaleFactor), false);
		*/
	}
	
	// Update is called once per frame
	void Update () {		
		if (state == stateMainGame) {
			/*
			GameObject.Find("SaludBarValue").GetComponent<TextMesh>().text = saludBar.ToString();
			GameObject.Find("WinterMagiaBarValue").GetComponent<TextMesh>().text = magiaBarWinter.ToString();
			GameObject.Find("SummerMagiaBarValue").GetComponent<TextMesh>().text = magiaBarSummer.ToString();
			GameObject.Find("SpringMagiaBarValue").GetComponent<TextMesh>().text = magiaBarSpring.ToString();
			GameObject.Find("FallMagiaBarValue").GetComponent<TextMesh>().text = magiaBarFall.ToString();
			*/
			// for short range souls
			GameObject[] array = GameObject.FindGameObjectsWithTag("shortSummer");
			if (array != null) {
				foreach (GameObject g in array) {
					if (g.GetComponent<ShortRangeEnemyScript>().isActive)
						g.GetComponent<ShortRangeEnemyScript>().seasonType = Utilities.summer;
				}
			}
			array = GameObject.FindGameObjectsWithTag("shortWinter");
			if (array != null) {
				foreach (GameObject g in array) {
					if (g.GetComponent<ShortRangeEnemyScript>().isActive)
						g.GetComponent<ShortRangeEnemyScript>().seasonType = Utilities.winter;
				}
			}
			array = GameObject.FindGameObjectsWithTag("shortFall");
			if (array != null) {
				foreach (GameObject g in array) {
					if (g.GetComponent<ShortRangeEnemyScript>().isActive)
						g.GetComponent<ShortRangeEnemyScript>().seasonType = Utilities.fall;
				}
			}
			array = GameObject.FindGameObjectsWithTag("shortSpring");
			if (array != null) {
				foreach (GameObject g in array) {
					if (g.GetComponent<ShortRangeEnemyScript>().isActive)	
						g.GetComponent<ShortRangeEnemyScript>().seasonType = Utilities.spring;
				}
			}
			
			regenerateMagia();
			
			if (saludBar <= 0) {
				Application.LoadLevel("levelGameOver");
			}
		}
	}
	
	void regenerateMagia() {
		if (currentSeason == winter) {
			if (magiaBarWinter < 100.0f) {
				magiaBarWinter += Time.deltaTime / 3f;
			}
		}
		if (currentSeason == summer) {
			if (magiaBarSummer < 100.0f) {
				magiaBarSummer += Time.deltaTime / 3f;
			}
		}
		if (currentSeason == spring) {
			if (magiaBarSpring < 100.0f) {
				magiaBarSpring += Time.deltaTime / 3f;
			}
		}
		if (currentSeason == fall) {
			if (magiaBarFall < 100.0f) {
				magiaBarFall += Time.deltaTime / 3f;
			}
		}
	}
}
