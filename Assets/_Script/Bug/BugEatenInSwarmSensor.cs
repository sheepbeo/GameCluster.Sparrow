using UnityEngine;
using System.Collections;

public class BugEatenInSwarmSensor : MonoBehaviour {
	public BugSwarmManager swarmManager;

	// Use this for initialization
	void Start () {
		swarmManager = transform.parent.GetComponent<BugSwarmManager>();
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("BirdBeak")) {
			swarmManager.OnBugEaten(this.transform);
		}
	}
}
