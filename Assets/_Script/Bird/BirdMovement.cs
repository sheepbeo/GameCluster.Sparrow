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
	public float normalSpeed = 5.0f;
	public float dashSpeed = 50.0f;

	// Private variables
	private bool isMoving;
	private bool isDashing;
	private float speed;
	private BirdTrail[] emitters;

	public bool IsDashing {
		get {
			return isDashing;
		}
	}

	// Use this for initialization
	void Start () {
		this.speed = normalSpeed;
		this.emitters = transform.GetComponentsInChildren<BirdTrail>(true);
	}
	
	void Update() {
		updateBirdAnimation();
	}
	
	public void MoveView(float verInput, float horInput) {
		rotationX = transform.localEulerAngles.y + horInput * sensitivityX;
		rotationY += verInput * sensitivityY;
		rotationY = Mathf.Clamp(rotationY, minRotationY, maxRotationY);
		
		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
	}
	
	public void Move(float moveInput) {
		rigidbody.velocity = speed * moveInput * transform.TransformDirection(Vector3.forward);
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
	
	private void updateBirdAnimation() {
		//stopRenderTrail();
		if (!isMoving) {
			flap();
		}

		if (isMoving) {
			checkLookDirectionAndAnimate();
		}

		if (isDashing) {
			this.speed = dashSpeed;
			setDashEffect(true);
		} else {
			this.speed = normalSpeed;
			setDashEffect(false);
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

#region Complicated system of Multi-state

/*
public class BirdMovement : MonoBehaviour {
	[Flags]
	public enum BirdState {
		DEFAULT = 1,
		MOVE = 2,
		DASH = 4
	}

	public void addState(BirdState state) {
		this.birdState |= state;
	}

	public void removeState(BirdState state) {
		this.birdState &= ~state;
	}

	// Move view variables
	public float sensitivityX = 5f;
	public float sensitivityY = 5f;
	public float minRotationY = -90f;
	public float maxRotationY = 90f;

	private float rotationX = 0.0f;
	private float rotationY = 0.0f;

	// Move variables
	public float speed = 1.0f;
	public float dashSpeed = 10.0f;

	// Private variables
	private BirdState birdState = BirdState.DEFAULT;

	// Use this for initialization
	void Start () {
	}

	void Update() {
		updateBirdAnimation();
	}

	public void MoveView(float verInput, float horInput) {
		rotationX = transform.localEulerAngles.y + horInput * sensitivityX;
		rotationY += verInput * sensitivityY;
		rotationY = Mathf.Clamp(rotationY, minRotationY, maxRotationY);

		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
	}

	public void Move(float moveInput) {
		rigidbody.velocity = speed * moveInput * transform.TransformDirection(Vector3.forward);
		if (moveInput != 0) {
			birdState = BirdState.MOVE;
		} else {
			birdState = BirdState.DEFAULT;
		}
	}

	public void Dash(float dashInput) {
		if (dashInput == 0.0f) {
			removeState(BirdState.DASH);
		} else {
			addState(BirdState.DASH);
		}

		print(birdState);
	}

	private void updateBirdAnimation() {
		//stopRenderTrail();
		switch (birdState) {
			case BirdState.DEFAULT:
				flap();
				break;
			case BirdState.MOVE:
				checkLookDirectionAndAnimate();
				break;
			case BirdState.DASH | BirdState.MOVE:
				checkLookDirectionAndAnimate();
				//renderTrail();
				break;
			default:
				break;
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

	// change animation to gliding
	private void glide() {
		animation.CrossFade("swallowGliding");
	}

	// change animation to flapping (flying)
	private void flap() {
		animation.CrossFade("swallowFlying");
	}
}
*/

#endregion
