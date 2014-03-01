using UnityEngine;
using System.Collections;

public class TrapNet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("BirdCollider")) {
			other.transform.root.GetComponentInChildren<BirdManager>().CaughtInTrap();
			other.attachedRigidbody.velocity = Vector3.zero;
			//print ("trigger enter: ");
			//print (other.transform.position);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag("BirdCollider")) {
			other.transform.root.GetComponentInChildren<BirdManager>().ReleaseFromTrap();
			this.transform.collider.isTrigger = false;
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Bird")) {
			collision.transform.root.GetComponentInChildren<BirdManager>().CaughtInTrap();
			this.collider.isTrigger = true;
			//print("Collision enter:");
			//print(collision.transform.position);
		}
	}
}
