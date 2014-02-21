using UnityEngine;
using System.Collections;

public class Destination : MonoBehaviour {
	public Transform birdTransform;

	private bool isDestinationReached = false;
	private BirdManager birdManager;

	// Use this for initialization
	void Start () {
		birdManager = birdTransform.GetComponent<BirdManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("BirdCollider")) {
			isDestinationReached = true;
		}
	}

	void OnGUI() {
		if (isDestinationReached) {
			GUI.Label(new Rect(100,80,100,100), "You Win!");
			GUI.Label(new Rect(100,100,100,100), "Score: " + birdManager.Score);
		}
	}
}
