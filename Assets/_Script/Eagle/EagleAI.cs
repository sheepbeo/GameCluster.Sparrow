using UnityEngine;
using System.Collections;

public class EagleAI : MonoBehaviour {
	public Transform[] wayPoints;

	private EagleMovement movement;
	private bool isPatrolling;
	private int nextWayPointIndex;

	private Vector3 originLocalPosition;
	private Quaternion originRotation;

	private bool caughtBird = false;

	void Awake() {
		GameManager.GameReset += gameResetEventHandler;
	}

	// Use this for initialization
	void Start () {
		this.movement = GetComponent<EagleMovement>();
		this.isPatrolling = true;
		this.nextWayPointIndex = 0;

		this.originLocalPosition = transform.localPosition;
		this.originRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isPatrolling) {
			this.movement.Destination = wayPoints[nextWayPointIndex].position;
			if (this.movement.ReachedDestination()) {
				incrementNextWayPointIndex();
			}
		}
	}

	public void OnBirdSpottedInHuntArea(Collider other) {
		if (!caughtBird) {
			this.isPatrolling = false;
			this.movement.Destination = other.transform.position;
		}
	}

	public void OnBirdLeftHuntArea(Collider other) {
		this.isPatrolling = true;
	}

	public void OnBirdCaught() {
		this.isPatrolling = true;
		this.caughtBird = true;
	}

	private void incrementNextWayPointIndex() {
		nextWayPointIndex = (nextWayPointIndex+1) % wayPoints.Length;
	}

	private void gameResetEventHandler() {
		transform.localPosition = originLocalPosition;
		transform.rotation = originRotation;

		this.isPatrolling = true;
		this.caughtBird = false;
		this.nextWayPointIndex = 0;
	}
}
