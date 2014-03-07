using UnityEngine;
using System.Collections;

public class CameraGameOverGUI : MonoBehaviour {
	public GUIStyle labelStyle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Return)) {
			GameManager.SetStateTriggerEvent(GameState.RESET);
		}
	}

	void OnGUI() {
		GUI.Label(new Rect(0,0, Screen.width, Screen.height), "Game Over. Press \"Enter\" to reset", labelStyle);
	}
}