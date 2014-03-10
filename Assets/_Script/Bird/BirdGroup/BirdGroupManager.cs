using UnityEngine;
using System.Collections;

[RequireComponent(typeof(VelocityChangingTargetedMovement))]
public class BirdGroupManager : MonoBehaviour {
	public Transform finalDestination;

	private VelocityChangingTargetedMovement movement;
	private SmoothLookAtTargetXZ smoothLook;
	private BirdGroupPoolManager poolManager;

	private Vector3 finalDestinationPosition;

	// Use this for initialization
	void Start () {
		movement = GetComponent<VelocityChangingTargetedMovement>();
		smoothLook = GetComponent<SmoothLookAtTargetXZ>();
		poolManager = transform.parent.GetComponent<BirdGroupPoolManager>();

		if (finalDestination != null)
			setTargetDestination(finalDestination);
	}
	
	// Update is called once per frame
	void Update () {
		if (movement.ReachedDestination() && poolManager) {
			poolManager.Store(transform);
		}
	}

	private void setTargetDestination(Transform destination) {
		// change the height level of finalDestinationPosition so that birds fly in same height
		finalDestinationPosition = destination.position;
		finalDestinationPosition.y = transform.position.y;
		
		// set target destination for movement;
		movement.Destination = finalDestinationPosition;

		// set target for smooth look
		smoothLook.target = destination;
	}
}
