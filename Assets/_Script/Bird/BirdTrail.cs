using UnityEngine;
using System.Collections;

// Require trail renderer component in this game object
[RequireComponent (typeof(TrailRenderer))]

public class BirdTrail : MonoBehaviour {
	public float speedThreshold = 0.1f;

	//
	private TrailRenderer trailRenderer;

	// Use this for initialization
	void Start () {
		trailRenderer = GetComponent<TrailRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		// check the ROOT parent's rigidbody if it's moving
		if (transform.root.rigidbody.velocity.magnitude < speedThreshold) {
			trailRenderer.enabled = false;
		} else {
			trailRenderer.enabled = true;
		}
	}
}
