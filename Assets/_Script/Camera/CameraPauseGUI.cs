using UnityEngine;
using System.Collections;

public class CameraPauseGUI : MonoBehaviour {

	public Texture gameLogo;
	public GUIStyle buttonStyle;

	// Use this for initialization
	void Start () {
	}

	void OnGUI() {
		if (GUI.Button(new Rect(Screen.width / 2 -100, Screen.height / 2 - 25, 200,50),"Play",buttonStyle)) {
			GameManager.SetStateTriggerEvent(GameState.RUNNING);
		}

		GUI.DrawTexture(new Rect(Screen.width / 2 -300, Screen.height / 2 - 200, 600,150), gameLogo);
	}
}
