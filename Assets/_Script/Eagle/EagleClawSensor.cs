using UnityEngine;
using System.Collections;

public class EagleClawSensor : MonoBehaviour {

	private EagleAI eagleAI;

	// Use this for initialization
	void Start () {
		eagleAI = GetComponent<EagleAI>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Bird")) {
			eagleAI.OnBirdCaught();
		}
	}
}
