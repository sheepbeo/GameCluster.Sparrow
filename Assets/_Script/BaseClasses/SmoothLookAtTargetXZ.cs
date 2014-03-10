using UnityEngine;
using System.Collections;

public class SmoothLookAtTargetXZ : MonoBehaviour {
	public Transform target;
	public float smoothFactor = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			Vector3 targetDirection = (new Vector3(target.position.x, transform.position.y, target.position.z) - transform.position).normalized;
			Vector3 nextDirection = Vector3.Lerp(transform.forward, targetDirection, Time.deltaTime * smoothFactor);

			transform.rotation = Quaternion.FromToRotation(Vector3.forward, nextDirection);
		}
	}
}
