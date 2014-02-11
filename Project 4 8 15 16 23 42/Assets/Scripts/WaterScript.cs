using UnityEngine;
using System.Collections;
public class WaterScript : MonoBehaviour {

public GameObject player;
private Vector4 colorWater;
private Vector4 colorFrozenWater;
// Use this for initialization
void Start () {
colorWater = gameObject.renderer.material.GetColor("_horizonColor");	
print (colorWater);
colorFrozenWater = new Vector4(1.0f,1.0f,1.0f,0);
}

// Update is called once per frame
void Update () {
		if (Utilities.state == Utilities.stateMainGame) {
			if (Utilities.currentSeason == Utilities.winter) {
			if (!Utilities.isWaterFrozen) {
			GetComponent<MeshCollider>().isTrigger = true;
			
			}
			if (Utilities.isWaterFrozen) {
			GetComponent<MeshCollider>().isTrigger = false;
			Utilities.freezeTimer -= Time.deltaTime/2;
			print(Utilities.freezeTimer);
			if (Utilities.freezeTimer < 0) {
			Utilities.isWaterFrozen = false;	
			}	
			}
			}
			if (Utilities.currentSeason != Utilities.winter) {
			GetComponent<MeshCollider>().isTrigger = true;
			Utilities.isWaterFrozen = false;
			}
			else if (Utilities.currentSeason == Utilities.spring) {
			
			}
			else if (Utilities.currentSeason == Utilities.summer) {
			}
			else if (Utilities.currentSeason == Utilities.fall) {
			}
			if (Utilities.isWaterFrozen) {
			Vector4 color = tintColorChange(gameObject.renderer.material.GetColor("_horizonColor"),colorFrozenWater);	
			gameObject.renderer.material.SetColor("_horizonColor",color);	
			}else{
			Vector4 color = tintColorChange(gameObject.renderer.material.GetColor("_horizonColor"),colorWater);	
			gameObject.renderer.material.SetColor("_horizonColor",color);	
			}
		}
}

IEnumerator OnTriggerEnter(Collider collider) {
if (collider.gameObject.CompareTag("Player")) {
Destroy(player);
yield return new WaitForSeconds(2);
Application.LoadLevel("levelGameOver");
}
}

void OnCollisionEnter(Collision collision) {
if (collision.gameObject.Equals(player)) {
print (collision.gameObject.name);
player.GetComponent<PlayerController>().walkSpeed = 5.0f;
player.GetComponent<PlayerController>().trotSpeed = 7.0f;
player.GetComponent<PlayerController>().runSpeed = 8.0f;
}
}
/*
void OnCollisionExit(Collision collision) {
if (collision.gameObject.Equals(player)) {
player.GetComponent<PlayerController>().walkSpeed = 3.0f;
player.GetComponent<PlayerController>().trotSpeed = 5.0f;
player.GetComponent<PlayerController>().runSpeed = 6.0f;
}
}*/

Vector4 tintColorChange(Vector4 tint,Vector4 targetTint){	
if(tint.x < targetTint.x){	
tint.x += 0.01f;
}else if(tint.x>targetTint.x){
tint.x -= 0.01f;
}
if(tint.y < targetTint.y){
tint.y += 0.01f;
}else if(tint.y > targetTint.y){
tint.y -= 0.01f;
}
if(tint.z < targetTint.z){
tint.z += 0.01f;
}else if(tint.z > targetTint.z){
tint.z -= 0.01f;
}	
if(tint.w < targetTint.w){
tint.w += 0.01f;
}else if(tint.z > targetTint.w){
tint.w -= 0.01f;
}	
return tint;
}
}