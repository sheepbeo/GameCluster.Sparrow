using UnityEngine;
using System.Collections;

public class FollowTargetXZ : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
		followTarget();
	}
	
	// Update is called once per frame
	void Update () {
		followTarget();
	}

	private void followTarget() {
		Vector3 nextPosition = target.position;
		nextPosition.y = transform.position.y;

		this.transform.position = nextPosition;
	}
}
