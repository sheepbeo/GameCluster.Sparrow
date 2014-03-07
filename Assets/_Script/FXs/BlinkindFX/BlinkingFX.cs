using UnityEngine;
using System.Collections;

public class BlinkingFX : MonoBehaviour {
	public Texture fxTexture;
	public Color textureColor = Color.white;

	private Color transparentColor = new Color(1,1,1,0);
	private Color defaultColor = Color.white;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		setGUIDepth();
		renderEffect();
	}

	protected virtual void setGUIDepth() {

	}

	protected void renderEffect() {
		// blinking effect:
		GUI.color = Color.Lerp(textureColor, transparentColor, Time.time - (int)Time.time);
		
		// texture effect:
		if (fxTexture != null) {
			GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), fxTexture);
		}
		
		GUI.color = defaultColor;
	}
}
