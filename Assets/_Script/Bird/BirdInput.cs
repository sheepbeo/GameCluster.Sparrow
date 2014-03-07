using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BirdManager))]
public class BirdInput : MonoBehaviour {
	protected BirdManager manager;
	
	protected float verInput;
	protected float horInput;
	protected float moveInput;
	protected float dashInput;
	
	// Use this for initialization
	void Start () {
		manager = GetComponent<BirdManager>();
	}
	
	public void CheckAndProcessInput() {
		// check input:
		verInput = Input.GetAxis("Mouse Y");
		horInput = Input.GetAxis("Mouse X");
		moveInput = Input.GetAxis("Vertical");

		dashInput = (Input.GetKey(KeyCode.Space)) ? 1.0f : 0.0f;
		
		// handle input:
		if (manager != null) {
			manager.MoveView(verInput,horInput);
			manager.Move(moveInput);
			manager.Dash(dashInput);
		} else {
			Debug.Log("null BirdManager Instance!");
		}


	}
}
