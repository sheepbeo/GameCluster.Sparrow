using UnityEngine;
using System.Collections;

public class BeakSensor : MonoBehaviour {
	protected BirdManager manager;

	// Use this for initialization
	void Start () {
		manager = transform.parent.GetComponent<BirdManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Bug")) { // check if sensor hits bug
			manager.Score++;
		}
	}
}
