using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BirdMovement))]
[RequireComponent(typeof(BirdInput))]
[RequireComponent(typeof(Energy))]
[RequireComponent(typeof(BirdOutOfEnergyEffect))]
[RequireComponent(typeof(BirdScoreGUI))]
public class BirdManager : MonoBehaviour {
	protected BirdMovement movement;
	protected BirdInput input;
	protected Energy energy;
	protected BirdOutOfEnergyEffect deadEffect;
	protected BirdScoreGUI scoreGUI;

	protected Vector3 startingPosition;
	protected Quaternion startingRotation;

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
		scoreGUI = GetComponent<BirdScoreGUI>();

		this.startingPosition = transform.position;
		this.startingRotation = transform.rotation;

		score = 0;
		registerEventHandlers();
	}
	
	// Update is called once per frame
	void Update () {
		input.CheckAndProcessInput();
	}

	private void registerEventHandlers() {
		GameManager.GameRunning += gameRunningEventHandler;
		GameManager.GameLose += gameLoseEventHandler;
		GameManager.GameReset += gameResetEventHandler;
	}

	#region public methods to be called in other classes

	public void MoveView(float verInput, float horInput)
	{
		if (this.movement.enabled)
			movement.MoveView(verInput, horInput);
	}

	public void Move(float moveInput) {
		if (this.movement.enabled)
			movement.Move(moveInput);
	}

	public void Dash(float dashInput) {
		if (this.movement.enabled)
			movement.Dash(dashInput);
	}

	public void ReplenishHunger(float amount) {
		this.energy.ReplenishHunger(amount);
	}

	public void ReplenishThirst(float amount) {
		this.energy.ReplenishThirst(amount);
	}

	public void CaughtInTrap() {
		movement.IsCaughtInTrap = true;
	}

	public void ReleaseFromTrap() {
		movement.IsCaughtInTrap = false;
	}

	#endregion

	#region Event Handler:

	private void gameRunningEventHandler() {
		this.movement.enabled = true;
	}

	private void gameLoseEventHandler() {
		this.movement.Fall();
		this.movement.enabled = false;
	}

	private void gameResetEventHandler() {
		transform.position = startingPosition;
		transform.rotation = startingRotation;
		energy.Reset();
	}

	#endregion
}
