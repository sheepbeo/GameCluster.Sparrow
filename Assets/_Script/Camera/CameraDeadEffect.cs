using UnityEngine;
using System.Collections;

public class CameraDeadEffect : MonoBehaviour {
	public Transform target;
	public float heightOffset = 5.0f;
	public float radius = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		followTarget();
	}

	private void followTarget() {
		this.transform.position = target.position + Vector3.up * heightOffset - Vector3.forward * radius;
		this.transform.LookAt(target.position);
	}
}
