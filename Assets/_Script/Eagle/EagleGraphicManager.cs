using UnityEngine;
using System.Collections;

public class EagleGraphicManager : MonoBehaviour {
	public Transform physicTransform;
	public float maxVerticalChangeAngle = 30f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		updateGraphicByVelocity();

		// update position
		transform.position = physicTransform.position;
	}

	private void updateGraphicByVelocity() {
		// update Vertical rotation
		Vector3 localEulerAngles = physicTransform.localEulerAngles;
		localEulerAngles.x = -physicTransform.rigidbody.velocity.normalized.y * maxVerticalChangeAngle;
		transform.localEulerAngles = localEulerAngles;
	}
}
