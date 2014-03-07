using UnityEngine;
using System.Collections;

public class Destination : MonoBehaviour {
	public Transform birdTransform;
	public GUIStyle destinationTextStyle;

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
			GUI.Label(new Rect(Screen.width/2 - 150,80,300,200), "You Win!" , destinationTextStyle);
			GUI.Label(new Rect(Screen.width/2 - 150,200,300,200), "Score: " + birdManager.Score, destinationTextStyle);
		}
	}
}
