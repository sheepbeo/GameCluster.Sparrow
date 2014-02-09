using UnityEngine;
using System.Collections;

public class TrailEmiitter : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.parent.rigidbody.velocity.magnitude < 0.1f) {
			particleSystem.emissionRate = 0;
		} else {
			particleSystem.emissionRate = 100;
		}
	}
}
