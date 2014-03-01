using UnityEngine;
using System.Collections;

public class EagleAI : MonoBehaviour {
	public Transform[] wayPoints;

	private EagleMovement movement;
	private bool isPatrolling;
	private int nextWayPointIndex;

	// Use this for initialization
	void Start () {
		this.movement = GetComponent<EagleMovement>();
		this.isPatrolling = true;
		this.nextWayPointIndex = 0;
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
		this.isPatrolling = false;
		this.movement.Destination = other.transform.position;
	}

	public void OnBirdLeftHuntArea(Collider other) {
		this.isPatrolling = true;
		this.movement.Destination = wayPoints[nextWayPointIndex].position;
	}

	private void incrementNextWayPointIndex() {
		nextWayPointIndex = (nextWayPointIndex+1) % wayPoints.Length;
		print("hello");
	}
}
