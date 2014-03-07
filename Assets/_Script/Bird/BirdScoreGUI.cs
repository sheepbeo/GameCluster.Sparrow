using UnityEngine;
using System.Collections;

public class BirdScoreGUI : MonoBehaviour {
	protected BirdManager manager;

	// Use this for initialization
	void Start () {
		manager = GetComponent<BirdManager>();
	}
	
	void OnGUI() {
		GUI.Label(new Rect(16,15,100,100), "Score: " + manager.Score);
	}
}
