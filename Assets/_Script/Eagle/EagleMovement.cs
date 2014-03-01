using UnityEngine;
using System.Collections;

public class EagleMovement : MonoBehaviour {


	public Vector3 Destination {
		get {
			return destination;
		}
		set {
			destination = value;
		}
	}

	public float speed = 15f;
	public float proximityDistance = 0.5f;
	private Vector3 destination;
	private Vector3 nextPos;

	// Use this for initialization
	void Start () {
		this.destination = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		if (this.ReachedDestination()) {
			this.rigidbody.velocity = Vector3.zero;
		} else {
			this.rigidbody.velocity = this.speed * (destination - this.transform.position).normalized;
		}
	}

	public bool ReachedDestination() {
		return (Vector3.Distance(this.transform.position, destination) < Mathf.Pow(proximityDistance, 2f));
	}
}
