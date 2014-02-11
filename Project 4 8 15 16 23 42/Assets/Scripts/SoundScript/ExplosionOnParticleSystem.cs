using UnityEngine;
using System.Collections;

public class ExplosionOnParticleSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.particleSystem.enableEmission){
			if(!gameObject.audio.isPlaying){
				gameObject.audio.Play();
			}
		}
	}
}
