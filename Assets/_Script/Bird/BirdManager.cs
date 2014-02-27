using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BirdMovement))]
[RequireComponent(typeof(BirdInput))]
[RequireComponent(typeof(Energy))]
public class BirdManager : MonoBehaviour {

	protected BirdMovement movement;
	protected BirdInput input;
	protected Energy energy;

	protected int score;

	public int Score {
		get { return score; } 
		set { score = value; }
	}

	// Use this for initialization
	void Start () {
		input = GetComponent<BirdInput>();
		movement = GetComponent<BirdMovement>();
		energy = GetComponent<Energy>();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		input.CheckAndProcessInput();
	}

	public void MoveView(float verInput, float horInput)
	{
		movement.MoveView(verInput, horInput);
	}

	public void Move(float moveInput) {
		movement.Move(moveInput);
	}

	public void Dash(float dashInput) {
		movement.Dash(dashInput);
	}

	public void ReplenishHunger(float amount) {
		this.energy.ReplenishHunger(amount);
	}

	public void ReplenishThirst(float amount) {
		this.energy.ReplenishThirst(amount);
	}


}
