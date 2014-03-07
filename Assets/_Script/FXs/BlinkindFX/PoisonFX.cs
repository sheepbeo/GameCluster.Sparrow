using UnityEngine;
using System.Collections;

public class PoisonFX : BlinkingFX {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected override void setGUIDepth() {
		GUI.depth = GUIDepths.POISON_FX_LAYER;
	}
}
