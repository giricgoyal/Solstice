using UnityEngine;
using System.Collections;

public class Walking : MonoBehaviour {
	public GameObject walk;
	public GameObject run;
	public GameObject player;
	bool resetWalk;
	bool resetRun;
	// Use this for initialization
	void Start () {
	resetWalk = false;
	resetRun = false;	
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController cc = player.GetComponent<CharacterController>();
		if(Input.GetKey("w") && Input.GetKey(KeyCode.LeftShift) && cc.enabled){
			if(!resetRun){
				run.audio.Play();					
			}
			resetRun = true;
		}else if(resetRun){	
			resetRun = false;			
			run.audio.Stop();				
		}
		
		if(Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift) && cc.enabled){
			if(!resetWalk){
				walk.audio.Play();					
			}
			resetWalk = true;
		}else if(resetWalk){
			resetWalk = false;
			walk.audio.Stop();				
		}
	}
}
