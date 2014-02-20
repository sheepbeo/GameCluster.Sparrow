using UnityEngine;
using System.Collections;

public class Particle_Emitter : MonoBehaviour {
	public float speedThreshold = 0.1f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		// check the ROOT parent's rigidbody if it's moving
		if (transform.root.rigidbody.velocity.magnitude < speedThreshold) {
			particleSystem.emissionRate = 0;
		} else {
			particleSystem.emissionRate = 100;
		}
	}
}
