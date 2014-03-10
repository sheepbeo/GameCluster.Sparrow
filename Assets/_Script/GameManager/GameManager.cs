using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	// Game events:
	public delegate void GameEvent();
	public static event GameEvent GameReset = delegate() {}, 
		GamePaused = delegate() {}, 
		GameRunning = delegate() {}, 
		GameWin = delegate() {}, 
		GameLose = delegate() {},
		GameEnd = delegate() {};

	public Transform runningGameObjectsWrapper;
	
	protected static GameState state;

	// Use this for initialization
	void Start () {
		this.SetStateTriggerEvent(GameState.RESET);
	}
	
	// Update is called once per frame
	void Update () {
		// check pause input:
		if (Input.GetKey(KeyCode.P)) {
			SetStateTriggerEvent(GameState.PAUSED);
		}


	}

	public static void SetStateTriggerEvent(GameState newState) {
		if (state != newState) {
			state = newState;

			if (newState == GameState.RESET) {
				GameReset();
				SetStateTriggerEvent(GameState.PAUSED);
			}
			if (newState == GameState.PAUSED) {
				GamePaused();
			} 
			if (newState == GameState.RUNNING) {
				GameRunning();
			}
			if (newState == GameState.WIN) {
				GameWin();
				SetStateTriggerEvent(GameState.END);
			}
			if (newState == GameState.LOSE) {
				GameLose();
				SetStateTriggerEvent(GameState.END);
			}
			if (newState == GameState.END) {
				GameEnd();
			}
		}
	}
}
