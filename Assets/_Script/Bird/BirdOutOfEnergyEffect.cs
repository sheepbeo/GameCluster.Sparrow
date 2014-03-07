using UnityEngine;
using System.Collections;

public class BirdOutOfEnergyEffect : MonoBehaviour {
	public float DeadTime = 3.0f;
	public float velocityDivideFactor = 10.0f;

	// Register Event handlers:
	void Awake () {
		GameManager.GameLose += gameLoseEventHandler;
		GameManager.GameReset += gameResetEventHandler;
	}

	private void gameLoseEventHandler() {
		this.rigidbody.velocity /= velocityDivideFactor;
		this.rigidbody.useGravity = true;
		this.rigidbody.freezeRotation = false;
	}

	private void gameResetEventHandler() {
		this.rigidbody.freezeRotation = true;
		this.rigidbody.useGravity = false;
	}
}
