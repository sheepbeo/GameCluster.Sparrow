using UnityEngine;
using System.Collections;

public class BirdPreySensor : MonoBehaviour {
	public float DeadTime = 3.0f;

	private bool isCaughtByEagle = false;
	private Transform originParent;

	// Use this for initialization
	void Start () {
		originParent = transform.parent;

		GameManager.GameReset += gameResetEventHandler;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionExit(Collision collision) {
		if (collision.gameObject.CompareTag("Eagle") && !isCaughtByEagle) {
			//startEagleCaughtEffect(collision.gameObject.transform);

			isCaughtByEagle = true;
			transform.parent = collision.transform;
			rigidbody.isKinematic = true;

			GetComponent<BirdMovement>().enabled = false;
			GameManager.SetStateTriggerEvent(GameState.LOSE);
		}
	}

	private void gameResetEventHandler() {
		isCaughtByEagle = false;
		transform.parent = originParent;
		rigidbody.isKinematic = false;
		
		GetComponent<BirdMovement>().enabled = true;
	}
}
	