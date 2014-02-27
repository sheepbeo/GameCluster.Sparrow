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
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag("BirdCollider")) {
			other.transform.root.GetComponentInChildren<BirdManager>().ReleaseFromTrap();
		}
	}
}
