using UnityEngine;
using System.Collections;

public class LookAtXZ : MonoBehaviour {
	public Transform target;

	void LateUpdate() {
		if (target) {

			// only appliable to Quad!!!
			transform.rotation = Quaternion.FromToRotation(Vector3.up, (new Vector3(target.position.x, transform.position.y, target.position.z) - transform.position).normalized);
		}
	}
}
