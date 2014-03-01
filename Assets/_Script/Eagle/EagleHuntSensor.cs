using UnityEngine;
using System.Collections;

public class EagleHuntSensor : MonoBehaviour {
	private Transform eagle;
	private EagleAI eagleAI;

	// Use this for initialization
	void Start () {
		eagleAI = this.transform.root.gameObject.GetComponentInChildren<EagleAI>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.CompareTag("BirdCollider")) {
			eagleAI.OnBirdSpottedInHuntArea(other);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag("BirdCollider")) {
			eagleAI.OnBirdLeftHuntArea(other);
		}
	}
}
