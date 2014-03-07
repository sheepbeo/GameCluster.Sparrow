using UnityEngine;
using System.Collections;
using System;

public class BirdMovement : MonoBehaviour {

	// Move-view variables
	public float sensitivityX = 5f;
	public float sensitivityY = 5f;
	public float minRotationY = -90f;
	public float maxRotationY = 90f;
	
	private float rotationX = 0.0f;
	private float rotationY = 0.0f;
	
	// Move variables
	public float normalSpeed = 15.0f;
	public float ActiveDashSpeedFactor = 5.0f;
	public float ActiveTrapSpeedFactor = 0.02f;

	private float dashSpeedFactor = 1f;
	private float trapSpeedFactor = 1f;

	// Private variables
	private bool isMoving;
	private bool isDashing;
	private bool isCaughtInTrap = false;
	private float speed;
	private BirdTrail[] emitters;

	public bool IsDashing {
		get {
			return isDashing;
		}
	}

	public bool IsCaughtInTrap {
		get {
			return isCaughtInTrap;
		}
		set {
			isCaughtInTrap = value;
		}
	}

	// Use this for initialization
	void Start () {
		this.speed = normalSpeed;
		this.emitters = transform.GetComponentsInChildren<BirdTrail>(true);
	}
	
	void Update() {
		updateBirdAnimationAndSpeedFactors();
	}
	
	public void MoveView(float verInput, float horInput) {
		rotationX = transform.localEulerAngles.y + horInput * sensitivityX;
		rotationY += verInput * sensitivityY;
		rotationY = Mathf.Clamp(rotationY, minRotationY, maxRotationY);
		
		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
	}
	
	public void Move(float moveInput) {
		rigidbody.velocity = speed * moveInput * transform.TransformDirection(Vector3.forward)
			* dashSpeedFactor * trapSpeedFactor;
		if (moveInput != 0) {
			isMoving = true;
		} else {
			isMoving = false;
		}
	}
	
	public void Dash(float dashInput) {
		if (dashInput != 0.0f) {
			isDashing = true;
		} else {
			isDashing = false;
		}
	}

	public void Fall() {
		this.isMoving = false;
		this.isDashing = false;
		this.setDashEffect(false);
		this.glide();
	}
	
	private void updateBirdAnimationAndSpeedFactors() {
		//stopRenderTrail();
		if (!isMoving) {
			flap();
		}

		if (isMoving) {
			checkLookDirectionAndAnimate();
		}

		if (isDashing) {
			this.dashSpeedFactor = ActiveDashSpeedFactor;
			setDashEffect(true);
		} else {
			this.dashSpeedFactor = 1.0f;
			setDashEffect(false);
		}

		if (isCaughtInTrap) {
			this.trapSpeedFactor = ActiveTrapSpeedFactor;
		} else {
			this.trapSpeedFactor = 1.0f;
		}
	}
	
	private void checkLookDirectionAndAnimate() {
		if (transform.localEulerAngles.x >= 180 || transform.localEulerAngles.x == 0) { 
			// if bird is looking up or straight ahead, flap!...
			flap();
		} else { // else ... glide!
			glide();
		}
	}

	#region toggle functions:
	
	// change animation to gliding
	private void glide() {
		animation.CrossFade("swallowGliding");
	}
	
	// change animation to flapping (flying)
	private void flap() {
		animation.CrossFade("swallowFlying");
	}

	private void setDashEffect(bool state) {
		foreach (BirdTrail e in this.emitters) {
			e.gameObject.SetActive(state);
		}
	}

	#endregion
}