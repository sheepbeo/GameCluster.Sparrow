using UnityEngine;
using System.Collections;

public class PoisonFXEventHandler : MonoBehaviour {
	public Transform target;


	// Register Event handlers
	void Awake() {
		if (target != null) {
			BirdPoisonSensor poisonSensor = target.GetComponent<BirdPoisonSensor>();
			if (poisonSensor != null) {
				poisonSensor.BirdStartPoisoned += BirdStartPoisonedEventHandler;
				poisonSensor.BirdStopPoisoned += BirdStopPoisonedEventHandler;
			}
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void BirdStartPoisonedEventHandler() {
		this.gameObject.SetActive(true);
	}

	private void BirdStopPoisonedEventHandler() {
		this.gameObject.SetActive(false);
	}


}
