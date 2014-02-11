using UnityEngine;
using System.Collections;

public class SoundTrackControler : MonoBehaviour {
	GameObject[] souls;
	public GameObject player;
	public GameObject gameScore;
	public GameObject defaultTrack;
	public GameObject[] tracks;
	public static int track;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {		
		defaultTrack = tracks[track];		
		float closest = 99999f;
		souls = GameObject.FindGameObjectsWithTag("shortSummer");
		foreach(GameObject g in souls){
			float distanceOfSoul = Vector3.Distance(player.transform.position,g.transform.position);
			if(closest > distanceOfSoul){
				closest = distanceOfSoul;				
			}			
		}
		souls = GameObject.FindGameObjectsWithTag("shortWinter");
		foreach(GameObject g in souls){
			float distanceOfSoul = Vector3.Distance(player.transform.position,g.transform.position);
			if(closest > distanceOfSoul){
				closest = distanceOfSoul;				
			}			
		}
		souls = GameObject.FindGameObjectsWithTag("shortFall");
		foreach(GameObject g in souls){
			float distanceOfSoul = Vector3.Distance(player.transform.position,g.transform.position);
			if(closest > distanceOfSoul){
				closest = distanceOfSoul;				
			}			
		}
		souls = GameObject.FindGameObjectsWithTag("shortSpring");
		foreach(GameObject g in souls){
			float distanceOfSoul = Vector3.Distance(player.transform.position,g.transform.position);
			if(closest > distanceOfSoul){
				closest = distanceOfSoul;				
			}			
		}
		if(closest<20f)
		{				
			player.audio.mute = true;
			float volume = player.audio.volume;	
			if(volume > 0f){
			volume -= 0.01f;
			}
			player.audio.volume = volume;
			if(!defaultTrack.audio.isPlaying){
				defaultTrack.audio.Play();
				defaultTrack.audio.volume = 0.83f;
			}
			
		}else if(closest>50f){
			player.audio.mute = false;
			float volume = player.audio.volume;
			if(volume < 0.84f){
				volume += 0.01f;
			}
			player.audio.volume = volume;			
			foreach(GameObject g in tracks){
				if(g.audio.isPlaying){
					float volumeFight = g.audio.volume;
					while(volumeFight >= 0){
					g.audio.volume = volumeFight;
					volumeFight -= 0.01f;
					}
					if(volumeFight <=0f){
						g.audio.Stop();	
					}
				}
			}				
			}
		}		
	}

