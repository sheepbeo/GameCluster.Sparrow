using UnityEngine;
using System.Collections;

public class CameraFollowTarget : MonoBehaviour {
	public Transform target;
	public float cameraDistance;
	public float cameraAngle;
	public float targetForwardOffset;

	private Vector3 nextPos;

	// Use this for initialization
	void Start () {
		cameraAngle = cameraAngle * Mathf.Deg2Rad;
	}
	
	// Update is called once per frame
	void Update () {
		// Calculate next Postition
		float horizontalDistance = cameraDistance * Mathf.Cos(cameraAngle);
		float verticalDistance = cameraDistance * Mathf.Sin(cameraAngle);
		this.nextPos = target.position - target.forward * horizontalDistance + target.up * verticalDistance;

		this.transform.position = nextPos;
		this.transform.LookAt(target.position + target.forward * targetForwardOffset, target.up);
	}
}
