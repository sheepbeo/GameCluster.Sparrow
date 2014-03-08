using UnityEngine;
using System.Collections;

public class FollowPositionDirectionXZ : MonoBehaviour {
	public Transform target;

	// Use this for initialization
	void Start () {
		followTargetPositionAndDirectionXZ();
	}
	
	// Update is called once per frame
	void Update () {
		followTargetPositionAndDirectionXZ();
	}
	
	private void followTargetPositionAndDirectionXZ() {
		Vector3 nextPosition = target.position;
		nextPosition.y = transform.position.y;
		
		this.transform.position = nextPosition;
		this.transform.rotation = Quaternion.Euler(90, target.eulerAngles.y, 0);
	}
}
