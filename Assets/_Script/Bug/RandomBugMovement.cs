using UnityEngine;
using System.Collections;

public class RandomBugMovement : MonoBehaviour {

	public float randomness = 0.1f;
	public float baseSpeed = 1.0f;

	public Transform Prefab;

	public float minAxisDistance = 1.0f;
	public float maxAxisDistance = 2.0f;

	[SerializeField]
	private Vector3 velocity = Vector3.zero;
	[SerializeField]
	private Transform nextTarget;

	// Use this for initialization
	void Start () {
		print("random movement");
		nextTarget = (Transform) Instantiate(Prefab, transform.position, Quaternion.identity);
		print(Prefab.position);
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.velocity = (nextTarget.position - transform.position) * baseSpeed;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("BugRandomNextTarget")) {
			RandomizeNextTarget();
		}
	}

	private void RandomizeNextTarget() {
		Vector3 nextPos = nextTarget.position;
		nextPos.x += Random.Range(minAxisDistance, maxAxisDistance) * Random.Range(-1, 1);
		nextPos.y += Random.Range(minAxisDistance, maxAxisDistance) * Random.Range(-1, 1);
		nextPos.z += Random.Range(minAxisDistance, maxAxisDistance) * Random.Range(-1, 1);
		
		nextTarget.position = nextPos;
	}
}
