using UnityEngine;
using System.Collections;

public class RandomBugMovement : MonoBehaviour {
	
	public float nextChangeMin = 0.5f;
	public float nextChangeMax = 2.0f;
	public float baseSpeed = 1.0f;
	public float turnAngle = 30f;
	
	private Vector3 direction = Vector3.zero;
	private float timeCounter;
	private float nextChange;

	// Use this for initialization
	void Start () {
		this.direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
	}
	
	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime;
		if (timeCounter > nextChange) {
			nextChange = Random.Range(nextChangeMin, nextChangeMax);
			timeCounter = 0;
			RandomizeDirection();
		}
	}

	void FixedUpdate() {
		rigidbody.velocity = direction.normalized * baseSpeed;
	}

	void OnTriggerEnter(Collider other) {
	}

	private void RandomizeDirection() {
		Vector3 randomAxis = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));

		Quaternion rotationQuat = Quaternion.AngleAxis(turnAngle, randomAxis);
		this.direction = rotationQuat * this.direction;
	}
}
