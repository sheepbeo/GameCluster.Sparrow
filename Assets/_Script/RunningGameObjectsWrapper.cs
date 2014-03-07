using UnityEngine;
using System.Collections;

public class RunningGameObjectsWrapper : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		GameManager.GameRunning += OnGameRunningEventHandler;
		GameManager.GamePaused += OnGamePausedEventHandler;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnGameRunningEventHandler() {
		this.gameObject.SetActive(true);
	}

	private void OnGamePausedEventHandler() {
		this.gameObject.SetActive(false);
	}
}
