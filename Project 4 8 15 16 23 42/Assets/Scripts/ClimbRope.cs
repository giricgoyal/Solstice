using UnityEngine;
using System.Collections;

public class ClimbRope : MonoBehaviour {
	bool resetWinter;
	public GameObject player;
	public Vector3 targetPositionClimb;
	float step;
	bool isClimbing = false ;
	// Use this for initialization
	void Start () {
		
		resetWinter=false;		
	}
	
	// Update is called once per frame
	void Update () {
		if (Utilities.state == Utilities.stateMainGame) {
			CharacterController c = player.GetComponent<CharacterController>();
			if (Utilities.currentSeason == Utilities.winter) {
				step = 10f * Time.deltaTime;
			}
			else if (Utilities.currentSeason == Utilities.spring) {
				step = 10f * Time.deltaTime;
			}
			else if (Utilities.currentSeason == Utilities.summer) {
				step = 10f * Time.deltaTime;
			}
			else if (Utilities.currentSeason == Utilities.fall) {
				step = 10f * Time.deltaTime;
			}
			if(((785-2 < transform.position.x) && (transform.position.x< 785+2)) && ((23-2 < transform.position.y)&&(transform.position.y < 23+2)) && ((694-2 < transform.position.z) &&(transform.position.z < 694+2)) ){
					targetPositionClimb.x = 769;
					targetPositionClimb.y = 85;
					targetPositionClimb.z = 671;			
				}else if(((619-10 < transform.position.x) && (transform.position.x< 619+10)) && ((99-10 < transform.position.y)&&(transform.position.y < 99+10)) && ((664-10 < transform.position.z) &&(transform.position.z < 664+10))){
					targetPositionClimb.x = 483.3115f;
					targetPositionClimb.y = 46;
					targetPositionClimb.z = 665;			
				}else if(((717-10 < transform.position.x) && (transform.position.x< 717+10)) && ((23-10 < transform.position.y)&&(transform.position.y < 23+10)) && ((161-10 < transform.position.z) &&(transform.position.z < 161+10))){
					targetPositionClimb.x = 732.9384f;
					targetPositionClimb.y = 73.59484f;
					targetPositionClimb.z = 160.7811f;			
				}else if(((202-10 < transform.position.x) && (transform.position.x< 202+10)) && ((17-10 < transform.position.y)&&(transform.position.y < 17+10)) && ((433-10 < transform.position.z) &&(transform.position.z < 433+10))){
					targetPositionClimb.x = 184.9228f;
					targetPositionClimb.y = 74.43449f;
					targetPositionClimb.z = 382.2241f;			
				}else{
					if(!resetWinter){
					targetPositionClimb.x = 0;
					targetPositionClimb.y = 0;
					targetPositionClimb.z = 0;
					}
				}
				resetWinter = true;							
				if(targetPositionClimb.x != 0 && targetPositionClimb.y != 0 && targetPositionClimb.z != 0 && Input.GetKey(KeyCode.E)){
					if(Utilities.currentSeason != Utilities.winter){
						c.enabled = false;
					}
				float step = 10f * Time.deltaTime;	
				transform.position = Vector3.MoveTowards(transform.position, targetPositionClimb, step);
				isClimbing=true;
				}else{
				if(isClimbing){
				c.enabled = true;
				targetPositionClimb.x = 0;
				targetPositionClimb.y = 0;
				targetPositionClimb.z = 0;	
				}
				
			}
		}
	
	}
}
