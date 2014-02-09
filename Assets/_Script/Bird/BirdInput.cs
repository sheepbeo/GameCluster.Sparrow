using UnityEngine;
using System.Collections;

public class BirdInput : MonoBehaviour {
	protected BirdManager manager;
	
	protected float verInput;
	protected float horInput;
	protected float moveInput;
	protected bool chargeInput;
	
	// Use this for initialization
	void Start () {
		manager = GetComponent<BirdManager>();
	}
	
	public void CheckAndProcessInput() {
		// check input:
		verInput = Input.GetAxis("Mouse Y");
		horInput = Input.GetAxis("Mouse X");
		moveInput = Input.GetAxis("Vertical");

		chargeInput = Input.GetKeyDown(KeyCode.Space);
		
		// handle input:
		manager.MoveView(verInput,horInput);
		manager.Move(moveInput);
		if (chargeInput) manager.Charge();
	}
}
