using UnityEngine;
using System.Collections;

public class walkcycle : MonoBehaviour
{
	void Start ()
	{
	}
	
	void Update ()
	{
		CharacterController controller = GetComponent<CharacterController>();
		GameObject playeranimation = GameObject.Find("Player");
        PlayerController playercontroller = playeranimation.GetComponent<PlayerController>();
	
		if(Input.GetButtonUp("power1"))
		{
			animation["soloAttack"].wrapMode=WrapMode.Once;
			animation.Play("soloAttack");
		}   
		
		else if(Utilities.currentSeason==Utilities.spring && Input.GetButton("power3"))
			{  
			   
			animation["startcrouch"].wrapMode=WrapMode.Once;	
			animation.CrossFade("startcrouch");
			animation["crouch"].wrapMode=WrapMode.Loop;
			animation.CrossFade("crouch");
			
				
			}
		else if(controller.velocity.sqrMagnitude < 0.1f && !(Input.GetButtonDown("power3") && (Utilities.currentSeason==Utilities.spring))) 
		{    
			 animation["waiting"].wrapMode=WrapMode.Loop;	
             animation.CrossFade("waiting");
        }
      else if(playercontroller._characterState == PlayerController.CharacterState.Running && !(Input.GetButtonDown("power3") && (Utilities.currentSeason==Utilities.spring)) )	
		{
			animation["startrun"].wrapMode=WrapMode.Once;	
			animation.CrossFade("startrun");
			animation["loopRun"].wrapMode=WrapMode.Loop;
			animation.CrossFade("loopRun");
			
		}
		
		else if(playercontroller._characterState == PlayerController.CharacterState.Walking && !(Input.GetButtonDown("power3") && (Utilities.currentSeason==Utilities.spring)))
		{ 
			animation["walkCycle"].wrapMode=WrapMode.Loop;
			animation.CrossFade("walkCycle");
		}
		
		else if(playercontroller._characterState == PlayerController.CharacterState.Jumping && !(Input.GetButtonDown("power3") && (Utilities.currentSeason==Utilities.spring)))
		{ 
			animation["Jump"].wrapMode=WrapMode.Once;
			animation.CrossFade("Jump");
		} 
		}
	}
	
//}
