using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	// Move view variables
	public float sensitivityX = 5f;
	public float sensitivityY = 5f;
	public float minRotationY = -90f;
	public float maxRotationY = 90f;

	private float rotationX = 0.0f;
	private float rotationY = 0.0f;

	// Move variables
	public float speed = 1.0f;

	// Use this for initialization
	void Start () {

	}

	public void MoveView(float verInput, float horInput) {
		rotationX = transform.localEulerAngles.y + horInput * sensitivityX;
		rotationY += verInput * sensitivityY;
		rotationY = Mathf.Clamp(rotationY, minRotationY, maxRotationY);

		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
	}

	public void Move(float moveInput) {
		rigidbody.velocity = speed * moveInput * transform.TransformDirection(Vector3.forward);
	}
}
