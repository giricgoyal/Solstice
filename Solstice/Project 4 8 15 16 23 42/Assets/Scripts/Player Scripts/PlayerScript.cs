using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	public GameObject shortRangeParticleSystem;
	public GameObject longRangeParticleSystem;
	public GameObject calumityParticleSystem;
	public GameObject player;
	public GameObject water;
	PlayerController playerController;
	
	// Use this for initialization
	void Start () {
		playerController = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void FixedUpdate() {
		if (Utilities.state == Utilities.stateMainGame) {
			
			shortRangeParticleSystem.transform.position = player.transform.position;
			
			if (Utilities.isShortRangeAttacking == true && Utilities.defensiveSpell == false) {
				shortRangeParticleSystem.particleSystem.enableEmission = true;
				playerController.walkSpeed = 1.5f;
				playerController.runSpeed = 3.0f;
				playerController.trotSpeed = 2.5f;
				if ((int)Time.time - (int)Utilities.attackTimeShort > 3) {
					playerController.walkSpeed = 3.0f;
					playerController.runSpeed = 6.0f;
					playerController.trotSpeed = 5.0f;
					Utilities.isShortRangeAttacking = false;
					shortRangeParticleSystem.particleSystem.enableEmission = false;
				}
			}
			
		}
	}
	
}
