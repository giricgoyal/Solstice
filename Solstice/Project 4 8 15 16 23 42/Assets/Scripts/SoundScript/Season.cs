using UnityEngine;
using System.Collections;

public class Season : MonoBehaviour {
	public GameObject sun;
	public GameObject thunder;
	public GameObject birds;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {	
		if(Input.GetKey("1") || Input.GetKey("2") || Input.GetKey("3") || Input.GetKey("4")){
			sun.audio.Play();
		}
		if(Utilities.currentSeason==Utilities.winter){
			thunder.audio.mute = false;
		}else{
			thunder.audio.mute = true;
		}
		if(Utilities.currentSeason == Utilities.spring){
			birds.audio.mute = false;
		}else{
			birds.audio.mute = true;
		}
	}
}
