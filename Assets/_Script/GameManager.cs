using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Transform birdTransform;

	protected BirdManager birdManager;

	// Use this for initialization
	void Start () {
		birdManager = birdTransform.GetComponent<BirdManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// TODO put this in GUI Manager
	void OnGUI() {
		GUI.Label(new Rect(16,15,100,100), "Score: " + birdManager.Score);
	}
}
