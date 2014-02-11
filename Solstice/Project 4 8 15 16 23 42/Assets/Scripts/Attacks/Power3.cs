using UnityEngine;
using System.Collections;
using System;
public class Power3 : MonoBehaviour {

public GameObject player;
public GameObject spell;
private float startTime;
private bool reset;
private bool resetWinter;
private bool resetSummer;
double x=0.1;
double y=0.1;
double xFall=0.0001;
double yFall=0.0001;
public Vector3 targetPosition;
public Vector3 targetPositionClimb;	
bool stopSpell;
private float regenerateSpells = 6f;
private int spellCount = 2;
float selectedBarValue;

// Use this for initialization
void Start () {
reset = false;
stopSpell = false;
resetWinter = false;
resetSummer = false;
}

bool isBarEmpty() {
if (selectedBarValue < 10.0f) {
return true;
}
return false;
}

// Update is called once per frame
void Update () {
		if (Utilities.state == Utilities.stateMainGame) {
			// Update spell effect based on current season
			if (Utilities.currentSeason == Utilities.winter) {
			spell = GameObject.Find("SpellWinterCalamity");
			selectedBarValue = Utilities.magiaBarWinter;
			}
			if (Utilities.currentSeason == Utilities.spring) {
			spell = GameObject.Find("SpellSpringCalamity");
			selectedBarValue = Utilities.magiaBarSpring;
			}
			if (Utilities.currentSeason == Utilities.summer) {
			spell = GameObject.Find("SpellSummerCalamity");
			selectedBarValue = Utilities.magiaBarSummer;
			}
			if (Utilities.currentSeason == Utilities.fall) {
			spell = GameObject.Find("SpellFallCalamity");
			selectedBarValue = Utilities.magiaBarFall;
			}
			
			
			// check for input "calamity"
			if (Input.GetButtonUp("power3")) {
			if (!Utilities.calumitySpell && !Utilities.calumitySpell && !Utilities.calumitySpell) {
			Utilities.calumitySpell = true;
			startTime = Utilities.calumitySpellTime;
			spell.particleEmitter.emit = true;
			}	
			if (Utilities.currentSeason == Utilities.winter) {
			Utilities.magiaBarWinter -= 40;
			}
			else if (Utilities.currentSeason == Utilities.spring) {
			Utilities.magiaBarSpring -= 40;
			}
			else if (Utilities.currentSeason == Utilities.summer) {
			Utilities.magiaBarSummer -= 40;
			}
			else if (Utilities.currentSeason == Utilities.fall) {
			Utilities.magiaBarFall -= 40;
			}
			}
			
			
			CharacterController c = player.GetComponent<CharacterController>();
			if(stopSpell && spellCount != 0){
			stopSpell = false;
			}
			if (Input.GetButton("power3") && !stopSpell && (Utilities.currentSeason != Utilities.winter & Utilities.currentSeason != Utilities.summer)) {
			if(!reset){
			Utilities.calumitySpell = true;
			startTime = Utilities.calumitySpellTime;
			}
			if (Utilities.calumitySpell) {
			//if (!Utilities.calumitySpell && !Utilities.calumitySpell && !Utilities.calumitySpell) {
			c.enabled = false;
			if(Utilities.currentSeason == Utilities.spring){
						if (!Griffin.griffonactive) {
							Utilities.griffonTimer = Utilities.maxFreezeTimer;
						}
						Griffin.griffonactive = true;
						
			if(Input.GetKey("w")){
			c.enabled = false;
			float xinc = float.Parse(x.ToString());
			transform.Translate(Vector3.forward * xinc * 0.1f);
			y = (1/(1+(Math.Pow(2.378,-x))));
			float yinc = float.Parse(y.ToString());
			transform.Translate(Vector3.up * yinc * 0.1f);
			x+=0.05;
			}else{
			transform.position =new Vector3(transform.position.x,transform.position.y+0.1f,transform.position.z);	
			}	
			}else if(Utilities.currentSeason == Utilities.fall){
			c.enabled = false;
			float xinc = float.Parse(xFall.ToString());
			transform.Translate(Vector3.forward * xinc * 0.1f);
			yFall = (1/(1+(Math.Pow(2.378,-xFall))));
			float yinc = float.Parse(yFall.ToString());
			transform.Translate(Vector3.down * (yinc * 0.1f));
			xFall+=0.05;
			}
			Utilities.calumitySpell = true;
			}	
			//	 spell.particleSystem.enableEmission = true;
			reset = true;
			}else if(reset){
			c.enabled = true;
			reset = false;
			x=0;
			y=0;
			xFall = 0;
			yFall = 0;
			}	
			
			if(Input.GetButton("power3") && (Utilities.currentSeason != Utilities.spring & Utilities.currentSeason != Utilities.fall)){
			bool ropePresent = false;
			if(Utilities.currentSeason == Utilities.winter){
			if(((785-2 < transform.position.x) && (transform.position.x< 785+2)) && ((23-2 < transform.position.y)&&(transform.position.y < 23+2)) && ((694-2 < transform.position.z) &&(transform.position.z < 694+2)) ){
			targetPositionClimb.x = 769;
			targetPositionClimb.y = 85;
			targetPositionClimb.z = 671;	
			ropePresent = true;
			}else if(((619-2 < transform.position.x) && (transform.position.x< 619+2)) && ((99-2 < transform.position.y)&&(transform.position.y < 99+2)) && ((664-2 < transform.position.z) &&(transform.position.z < 664+2))){
			targetPositionClimb.x = 483.3115f;
			targetPositionClimb.y = 46;
			targetPositionClimb.z = 665;	
			ropePresent = true;
			}else if(((717-2 < transform.position.x) && (transform.position.x< 717+2)) && ((23-2 < transform.position.y)&&(transform.position.y < 23+2)) && ((161-2 < transform.position.z) &&(transform.position.z < 161+2))){
			targetPositionClimb.x = 732.9384f;
			targetPositionClimb.y = 73.59484f;
			targetPositionClimb.z = 160.7811f;	
			ropePresent = true;
			}else if(((202-2 < transform.position.x) && (transform.position.x< 202+2)) && ((17-2 < transform.position.y)&&(transform.position.y < 17+2)) && ((433-2 < transform.position.z) &&(transform.position.z < 433+2))){
			targetPositionClimb.x = 184.9228f;
			targetPositionClimb.y = 74.43449f;
			targetPositionClimb.z = 382.2241f;	
			ropePresent = true;
			}else{
			if(!resetWinter){
			targetPositionClimb.x = 0;
			targetPositionClimb.y = 0;
			targetPositionClimb.z = 0;
			}
			}
			resetWinter = true;	
			if(targetPositionClimb.x != 0 && targetPositionClimb.y != 0 && targetPositionClimb.z != 0){
			c.enabled = false;
			float step = 10f * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, targetPositionClimb, step);
			}	
			Utilities.isWaterFrozen = true;
			Utilities.freezeTimer = Utilities.maxFreezeTimer;
			}else if(Utilities.currentSeason == Utilities.summer){
			if(((785-10 < transform.position.x) && (transform.position.x< 785+10)) && ((23-10 < transform.position.y)&&(transform.position.y < 23+10)) && ((694-10 < transform.position.z) &&(transform.position.z < 694+10)) ){
			targetPosition.x = 767;
			targetPosition.y = 90;
			targetPosition.z = 665;	
			ropePresent = true;
			}else if(((635-10 < transform.position.x) && (transform.position.x< 635+10)) && ((87-10 < transform.position.y)&&(transform.position.y < 87+10)) && ((673-10 < transform.position.z) &&(transform.position.z < 673+10))){
			targetPosition.x = 492;
			targetPosition.y = 45;
			targetPosition.z = 671;	
			ropePresent = true;
			}else if(((717-10 < transform.position.x) && (transform.position.x< 717+10)) && ((23-10 < transform.position.y)&&(transform.position.y < 23+10)) && ((161-10 < transform.position.z) &&(transform.position.z < 161+10))){
			targetPosition.x = 735;
			targetPosition.y = 76;
			targetPosition.z = 154;	
			ropePresent = true;
			}else if(((202-10 < transform.position.x) && (transform.position.x< 202+10)) && ((17-10 < transform.position.y)&&(transform.position.y < 17+10)) && ((433-10 < transform.position.z) &&(transform.position.z < 433+10))){
			targetPosition.x = 193;
			targetPosition.y = 80;
			targetPosition.z = 383;	
			ropePresent = true;
			}else{
			if(!resetSummer){
			targetPosition.x = 0;
			targetPosition.y = 0;
			targetPosition.z = 0;
			}
			}	
			resetSummer = true;
			c.enabled = false;
			if(targetPosition.x != 0 && targetPosition.y != 0 && targetPosition.z != 0){
			float step = 100f * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
			}	
			SteamScript.steamUp = true;
			Utilities.steamTimer = Utilities.maxFreezeTimer;
			}
			}else if(resetWinter){
			c.enabled = true;	
			resetWinter = false;	
			targetPositionClimb.x = 0;
			targetPositionClimb.y = 0;
			targetPositionClimb.z = 0;
			}else if(resetSummer){
			c.enabled = true;	
			resetSummer = false;
			targetPosition.x = 0;
			targetPosition.y = 0;
			targetPosition.z = 0;
			}
			// Counter for spell
			if (Utilities.calumitySpell) {
			//print("defensive : " + startTime);
			spell.transform.position = player.transform.position;
			startTime -= Time.deltaTime;
			if (startTime < 0) {
			//spell.particleSystem.enableEmission = false;
			Utilities.calumitySpell = false;
			spell.particleEmitter.emit = false;
			startTime = Utilities.calumitySpellTime;
			stopSpell = true;
			spellCount -= 1;
			print(Utilities.calumitySpell);
			c.enabled = true;
			x=0;
			y=0;
			xFall = 0;
			yFall = 0;
			}
			}
			if(stopSpell)
					{
			//print("regenerate : " + regenerateSpells);
			regenerateSpells -= Time.deltaTime;
			if (regenerateSpells < 0) {
			regenerateSpells = 6f;
			stopSpell = false;
			spellCount = 2;
			}
			}
		}
}
}