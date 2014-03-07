using UnityEngine;
using System.Collections;

public class BirdPoisonSensor : MonoBehaviour {
	public delegate void BirdPoisonSensorEvent();
	public event BirdPoisonSensorEvent BirdStartPoisoned, BirdStopPoisoned;

	public float poisonDuration = 3.0f;

	private float poisonCountDownTimer = 3.0f;
	private bool isPoisoned = false;
	private bool inPoisonedWater = false;

	void Awake() {
		GameManager.GameReset += GameResetEventHandler;
	}

	// Use this for initialization
	void Start () {
		poisonCountDownTimer = poisonDuration;
	}
	
	// Update is called once per frame
	void Update () {
		if (inPoisonedWater) {
			poisonCountDownTimer = poisonDuration;
			this.isPoisoned = true;
		} else {
			poisonCountDownTimer -= Time.deltaTime;
			if (poisonCountDownTimer <= 0.0f && this.isPoisoned) {
				this.isPoisoned = false;
				BirdStopPoisoned();
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Water")) {
			this.inPoisonedWater = true;
			if (!this.isPoisoned) {
				BirdStartPoisoned();
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag("Water")) {
			this.inPoisonedWater = false;	
		}
	}

	private void GameResetEventHandler() {
		BirdStopPoisoned();
	}
}
