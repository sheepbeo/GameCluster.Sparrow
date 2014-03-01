using UnityEngine;
using System.Collections;

public class CameraPauseGUI : MonoBehaviour {

	public Texture gameLogo;
	public GUIStyle buttonStyle;

	private GameManager gameManger;

	// Use this for initialization
	void Start () {
		gameManger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}

	void OnGUI() {
		if (GUI.Button(new Rect(Screen.width / 2 -100, Screen.height / 2 - 25, 200,50),"Play",buttonStyle)) {
			gameManger.SwitchStatePause();
		}

		GUI.DrawTexture(new Rect(Screen.width / 2 -300, Screen.height / 2 - 200, 600,150), gameLogo);
	}
}
