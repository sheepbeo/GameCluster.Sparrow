using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	// Game events:
	public delegate void GameEvent();
	public event GameEvent GamePaused, GameRunning;

	public GameState State { get { return state; }}
	public Transform runningGameObjectsWrapper;

	protected BirdManager birdManager;
	protected GameState state;

	// Use this for initialization
	void Start () {
		birdManager = runningGameObjectsWrapper.GetComponentInChildren<BirdManager>();
		this.state = GameState.RUNNING;
		SwitchStatePause();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P)) {
			SwitchStatePause();
		}
	}

	// TODO put this in GUI Manager
	void OnGUI() {
		GUI.Label(new Rect(16,15,100,100), "Score: " + birdManager.Score);
	}

	public void SwitchStatePause() {
		if (this.state == GameState.PAUSED) {
			this.state = GameState.RUNNING;
			this.runningGameObjectsWrapper.gameObject.SetActive(true);
			GameRunning();
		}
		else if (this.state == GameState.RUNNING) {
			this.state = GameState.PAUSED;
			this.runningGameObjectsWrapper.gameObject.SetActive(false);
			GamePaused();
		}
	}
}
