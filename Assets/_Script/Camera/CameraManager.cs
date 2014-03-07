using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CameraFollowTarget))]
[RequireComponent(typeof(CameraRotateAroundTarget))]
[RequireComponent(typeof(CameraPauseGUI))]
[RequireComponent(typeof(CameraGameOverGUI))]
[RequireComponent(typeof(CameraDeadEffect))]

public class CameraManager : MonoBehaviour {
	private CameraFollowTarget followTarget;
	private CameraRotateAroundTarget rotateAroundTarget;
	private CameraPauseGUI pauseGUI;
	private CameraGameOverGUI gameoverGUI;
	private CameraDeadEffect deadEffect;


	void Awake() {
		GameManager.GameRunning += gameRunningEventHandler;
		GameManager.GamePaused += gamePausedEventHandler;
		GameManager.GameLose += gameLoseEventHandler;

		this.followTarget = this.GetComponent<CameraFollowTarget>();
		this.rotateAroundTarget = this.GetComponent<CameraRotateAroundTarget>();
		this.pauseGUI = this.GetComponent<CameraPauseGUI>();
		this.gameoverGUI = this.GetComponent<CameraGameOverGUI>();
		this.deadEffect = this.GetComponent<CameraDeadEffect>();
	}

	void Update() {

	}

	private void gameRunningEventHandler() {
		disableAll();

		followTarget.enabled = true;
	}

	private void gamePausedEventHandler() {
		disableAll();

		rotateAroundTarget.enabled = true;
		rotateAroundTarget.OnEnable();
		pauseGUI.enabled = true;
	}

	private void gameLoseEventHandler() {
		disableAll();

		gameoverGUI.enabled = true;
		deadEffect.enabled = true;
	}

	private void disableAll() {
		followTarget.enabled = false;
		rotateAroundTarget.enabled = false;
		rotateAroundTarget.OnDisable();
		pauseGUI.enabled = false;
		deadEffect.enabled = false;
		gameoverGUI.enabled = false;
	}
}
