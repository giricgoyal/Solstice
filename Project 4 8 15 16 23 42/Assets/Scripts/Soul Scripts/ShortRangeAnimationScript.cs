using UnityEngine;
using System.Collections;

public class ShortRangeAnimationScript : MonoBehaviour {
	
//	public AnimationClip walkAnimation;
//	public AnimationClip takeDamageAnimation;
//	public AnimationClip attackAnimation;
//	public AnimationClip shoutAndAttackAnimation;
//	public AnimationClip meleeAttackAnimation;
//	public AnimationClip crouchAnimation;
//	public AnimationClip scareAnimation;
//	public AnimationClip idleAnimation;
//	
//	private bool _walkAnimation = true;
//	private bool _takeDamageAnimation = true;
//	private bool _attackAnimation = true;
//	private bool _shoutAndAttackAnimation = true;
//	private bool _meleeAttackAnimation = true;
//	private bool _crouchAnimation = true;
//	private bool _scareAnimation = true;
//	private bool _idleAnimation = true;
//	
	private bool isActive = true;
	private bool isWalking = false;
	private bool isIdle = true;
	private bool isAttacking = false;
	private bool isTakeingHit = false;
	
	//private Animation _animation;
	
	// Use this for initialization
	void Start ()
	{
//		if (walkAnimation == null) {
//			_walkAnimation = false;
//		}
//		if (takeDamageAnimation == null) {
//			_takeDamageAnimation = false;
//		}
//		if (attackAnimation == null) {
//			_attackAnimation = false;
//		}
//		if (shoutAndAttackAnimation == null) {
//			_shoutAndAttackAnimation = false;
//		}
//		if (meleeAttackAnimation == null) {
//			_meleeAttackAnimation = false;
//		}
//		if (crouchAnimation == null) {
//			_crouchAnimation = false;
//		}
//		if (scareAnimation == null) {
//			_scareAnimation = false;
//		}
//		if (idleAnimation == null) {
//			_idleAnimation = false;
//		}
//		_animation = GetComponent<Animation>();
		}
	
	// Update is called once per frame
	void Update () {
		if (Utilities.state == Utilities.stateMainGame) {
			updateBooleanValuesForSoul();
			animate();
		}
	}
	
	void updateBooleanValuesForSoul() {
		isActive = GetComponent<ShortRangeEnemyScript>().isActive;
		isWalking = GetComponent<ShortRangeEnemyScript>().isWalking;
		isAttacking = GetComponent<ShortRangeEnemyScript>().isAttacking;
		isTakeingHit = GetComponent<ShortRangeEnemyScript>().isAttacked;
		isIdle = GetComponent<ShortRangeEnemyScript>().isIdle;
	}
	
	void animate() 
	{
		if (isActive) {
			if (isIdle)
			{
				animation["idle"].wrapMode=WrapMode.Loop;
				animation.CrossFade("idle");
	//			Debug.Log("idle animation on");
	//			if (_idleAnimation) {
	//				//_animation[idleAnimation.name].wrapMode = WrapMode.ClampForever;
	//				_animation.CrossFade(idleAnimation.name);
	//			}
			}
			else if (isWalking)
			{
				animation["walkforward"].wrapMode=WrapMode.Loop;
				animation.CrossFade("walkforward");
		//		Debug.Log("walk animation on");
			}	
			else if (isAttacking)
			{
				animation["attack"].wrapMode=WrapMode.Once;
				animation.CrossFade("attack");
		//		Debug.Log("attack animation on");
			}
	//			if (_walkAnimation) {
	//				//_animation[walkAnimation.name].wrapMode = WrapMode.ClampForever;
	//				_animation.CrossFade(walkAnimation.name);
	//				//_animation.Play(walkAnimation.name);
	//				print(walkAnimation.name);
	//			}
			
		}
		if (isTakeingHit) {
				animation["destroy"].wrapMode = WrapMode.Once;
				animation.CrossFade("destroy");
		//		Debug.Log("destroy animation on");
		}
	}
}

