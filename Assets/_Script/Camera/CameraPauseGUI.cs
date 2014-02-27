using UnityEngine;
using System.Collections;

public class CameraPauseGUI : MonoBehaviour {

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


	}
}
