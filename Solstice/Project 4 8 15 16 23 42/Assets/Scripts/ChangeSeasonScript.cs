using UnityEngine;
using System.Collections;
public class ChangeSeasonScript : MonoBehaviour {

public Material skyboxWinter;
public Material skyboxSpring;
public Material skyboxSummer;
public Material skyboxFall;
public GameObject snow;
public GameObject sun;
public GameObject player;
Vector4 winterTint;
Vector4 summerTint;
Vector4 fallTint;
Vector4 springTint;


// Use this for initialization
void Start () {
		if (Utilities.state == Utilities.stateMainGame) {
			snow = GameObject.Find("FX_Snow");
			winterTint = skyboxWinter.GetColor("_Tint");
			summerTint = skyboxSummer.GetColor("_Tint");
			fallTint = skyboxFall.GetColor("_Tint");
			springTint = skyboxSpring.GetColor("_Tint");
		}
}

// Update is called once per frame
void Update () {
if (Utilities.state == Utilities.stateMainGame) {
//if (!Utilities.defensiveSpell && !Utilities.offensiveSpell && !Utilities.calumitySpell) {
if (Input.GetButton("winter")) {
if (Utilities.currentSeason != Utilities.winter) {
Utilities.changedSeason = Utilities.currentSeason;
Utilities.currentSeason = Utilities.winter;
Utilities.seasonCounter = Utilities.seasonCounterMax;
Utilities.seasonChanged = true;
}

}
if (Input.GetButton("summer")) {
if (Utilities.currentSeason != Utilities.summer) {
Utilities.changedSeason = Utilities.currentSeason;
Utilities.currentSeason = Utilities.summer;
Utilities.seasonCounter = Utilities.seasonCounterMax;
Utilities.seasonChanged = true;
}
}
if (Input.GetButton("spring")) {
if (Utilities.currentSeason != Utilities.spring) {
Utilities.changedSeason = Utilities.currentSeason;
Utilities.currentSeason = Utilities.spring;
Utilities.seasonCounter = Utilities.seasonCounterMax;
Utilities.seasonChanged = true;
}
}
if (Input.GetButton("fall")) {
if (Utilities.currentSeason != Utilities.fall) {
Utilities.changedSeason = Utilities.currentSeason;
Utilities.currentSeason = Utilities.fall;
Utilities.seasonCounter = Utilities.seasonCounterMax;
Utilities.seasonChanged = true;
}
}
//}	


if (Utilities.seasonChanged) {
Utilities.seasonCounter -= Time.deltaTime;
if (Utilities.seasonCounter < 0) {
Utilities.seasonChanged = false;
Utilities.currentSeason = Utilities.changedSeason;
}
if (Utilities.seasonCounter < 10) {
if (Utilities.currentSeason == Utilities.winter) {
snow.particleEmitter.emit = false;
}
}
}




if (Utilities.currentSeason == Utilities.winter) {
enableWinter();
}
else if (Utilities.currentSeason == Utilities.spring) {
enableSpring();
}
else if (Utilities.currentSeason == Utilities.summer) {
enableSummer();
}
else if (Utilities.currentSeason == Utilities.fall) {
enableFall();
}


}	
}

// enable seasons
public void enableWinter() {	
//	 RenderSettings.skybox = skyboxWinter;
Vector4 color = tintColorChange(RenderSettings.skybox.GetColor("_Tint"),winterTint);
RenderSettings.skybox.SetColor("_Tint",color);
setFog();	
//	 print (skyboxWinter.GetColor("_Tint"));
RenderSettings.ambientLight = new Color32(44,44,44,255);	
if(sun.light.intensity < 0.531f){
sun.light.intensity += 0.001f;
}else if(sun.light.intensity > 0.533f){
sun.light.intensity -= 0.001f;
}else{
//sun.light.intensity = 0.53f;
}
snow.transform.position = player.transform.position;
snow.particleEmitter.emit = true;
snow.particleEmitter.maxSize = Random.Range(0.5f, 2.0f);
snow.particleEmitter.worldVelocity = new Vector3(0.0f ,Random.Range(-1.0f, -2.5f), 0.0f);
if(snow.particleEmitter.minEmission<664.7){
snow.particleEmitter.minEmission += 1;	
}
}

public void enableSpring() {
//skyboxSpring.SetColor("_Tint",RenderSettings.skybox.GetColor("_Tint"));

Vector4 color = tintColorChange(RenderSettings.skybox.GetColor("_Tint"),springTint);
RenderSettings.skybox.SetColor("_Tint",color);
resetFog();
RenderSettings.ambientLight = new Color32(147, 145, 126, 255);
/*	 float r = RenderSettings.ambientLight.r;
float g = RenderSettings.ambientLight.g;
float b = RenderSettings.ambientLight.b;
//
if(r < 0.147){	
r += 0.001f;
//	 RenderSettings.ambientLight.r = r;
}else if(r>0.148){
//RenderSettings.ambientLight = new Color32(147, 145, 126, 255);
r -= 0.001f;
//	 RenderSettings.ambientLight.r = r;
}
print(r);
if(g < 0.144){
g += 0.001f;
}else if(g>0.145){
g -= 0.001f;
}
print(r);
if(b < 0.126){
b += 0.001f;
}else if(b > 0.127){
b -= 0.001f;
}
print(b);
RenderSettings.ambientLight =new Color(r,g,b,1);
*/	
if(sun.light.intensity < 0.651f){
sun.light.intensity += 0.001f;
}else if(sun.light.intensity > 0.653f){
sun.light.intensity -= 0.001f;
}else{
//sun.light.intensity = 0.65f;
}
snow.particleEmitter.emit = false;
snow.particleEmitter.minEmission = 0f;

}

public void enableSummer() {
//	 RenderSettings.skybox = skyboxSummer;
Vector4 color = tintColorChange(RenderSettings.skybox.GetColor("_Tint"),summerTint);
RenderSettings.skybox.SetColor("_Tint",color);
resetFog();
RenderSettings.ambientLight = new Color32(211, 211, 211, 255);
if(sun.light.intensity < 0.801f){
sun.light.intensity += 0.001f;
}else if(sun.light.intensity > 0.803f){
sun.light.intensity -= 0.001f;
}else{
//sun.light.intensity = 0.80f;;
}	

snow.particleEmitter.emit = false;

}

public void enableFall() {
//	 RenderSettings.skybox = skyboxFall;
Vector4 color = tintColorChange(RenderSettings.skybox.GetColor("_Tint"),fallTint);
RenderSettings.skybox.SetColor("_Tint",color);
resetFog();
RenderSettings.ambientLight = new Color32(42, 26, 0, 255);
if(sun.light.intensity < 0.711f){
sun.light.intensity += 0.001f;
}else if(sun.light.intensity > 0.713f){
sun.light.intensity -= 0.001f;
}else{
//sun.light.intensity = 0.71f;
}	
snow.particleEmitter.emit = false;

}

// setter and resetter fog functions
void setFog() {
RenderSettings.fog = true;
if(RenderSettings.fogDensity<=0.1){
RenderSettings.fogDensity += 0.005f;
}
}

void resetFog() {
if(RenderSettings.fogDensity > 0.0){
RenderSettings.fogDensity -= 0.005f;
}
}

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