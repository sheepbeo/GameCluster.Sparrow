using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {
	private GameManager gameManger;

	void Awake() {
		gameManger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		gameManger.GameRunning += GameRunningEventHandler;
		gameManger.GamePaused += GamePausedEventHandler;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		switch(gameManger.State) {
		case GameState.RUNNING:

			break;
		case GameState.PAUSED:

			break;
		}
	}

	private void GameRunningEventHandler() {
		this.GetComponent<CameraFollowTarget>().enabled = true;
		this.GetComponent<CameraRotateAroundTarget>().enabled = false;
		this.GetComponent<CameraRotateAroundTarget>().OnDisable();
		this.GetComponent<CameraPauseGUI>().enabled = false;
	}

	private void GamePausedEventHandler() {
		this.GetComponent<CameraFollowTarget>().enabled = false;
		this.GetComponent<CameraRotateAroundTarget>().enabled = true;
		this.GetComponent<CameraRotateAroundTarget>().OnEnable();
		this.GetComponent<CameraPauseGUI>().enabled = true;
	}
}
