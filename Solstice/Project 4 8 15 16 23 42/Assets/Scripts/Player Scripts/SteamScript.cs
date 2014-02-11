using UnityEngine;
using System.Collections;

public class SteamScript : MonoBehaviour {
	float x;
	float y;
	float z;
	float initialx;
	float initialy;
	float initialz;
	public static bool steamUp;
	GameObject[] steam;
	Vector3[] position;
	Vector3 waterPosition;
	public GameObject water;
	// Use this for initialization
	void Start () {
		if (Utilities.state == Utilities.stateMainGame) {
			x = 1500f;
			y = 1500f;
			z = 1500f;
			steam = GameObject.FindGameObjectsWithTag("steam1");
			position = new Vector3[steam.Length];
			for(int i = 0 ; i < steam.Length ; i++){
				position[i] = steam[i].transform.position;		
			}
			waterPosition = water.transform.position;
			steam = GameObject.FindGameObjectsWithTag("steam1");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Utilities.state == Utilities.stateMainGame) {
			/*	if(x==1500.0f && z==1500.0f){
					x=0f;			
					z=0f;
					transform.position =new Vector3(initialx,transform.position.y,initialz);
				}
				if(z==1500f){
					x = x+200f;
					z = 0f;
				}
				z = z + 100;		
				transform.position =new Vector3(initialx+x,transform.position.y,initialz+z);							
			
			*/
			if(steamUp){	
				if(y == 800f){
					y = 0f;
				}
				y=y+10f;
				for(int i = 0; i<steam.Length ; i++){
					GameObject localSteam = steam[i];
					if(localSteam.transform.position.y < 100){
						localSteam.transform.Translate(Vector3.up*0.8f);
					}
					if(steam[i].audio != null && !steam[i].audio.isPlaying){
						steam[i].audio.Play();
					}
				}
				water.transform.Translate(Vector3.down*0.05f);
				Utilities.steamTimer -= Time.deltaTime/2;
				print(Utilities.steamTimer);
				if (Utilities.steamTimer < 0) {
					steamUp = false;				
				}											
			}else{
				for(int i = 0; i<steam.Length ; i++){
					GameObject localSteam = steam[i];
					localSteam.transform.position =new Vector3(position[i].x,position[i].y,position[i].z);
					if(steam[i].audio != null && steam[i].audio.isPlaying){
						steam[i].audio.Stop();
					}
				}		
				if(water.transform.position.y < waterPosition.y){
					water.transform.Translate(Vector3.up * 0.2f);		
				}
			}
		}
	}
}