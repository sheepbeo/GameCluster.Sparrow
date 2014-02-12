using UnityEngine;
using System.Collections;

public class SwallowDemo : MonoBehaviour 
{
	private const string ANIMATION_FLYING = "swallowFlying";
	private const string ANIMATION_GLIDING = "swallowGliding";

	public GameObject swallow;
	public GameObject swallowLowPoly;
	private GameObject currentModel;

	private string currentAnimation = ANIMATION_GLIDING;
	private float animationSpeed = 1.0f;

	void Start () 
	{
		currentModel = swallow;
	}
	
	void Update () 
	{
	}

	void OnGUI ()
	{
		if (GUI.Button (new Rect(10, 10, 100, 30), "Flying"))
			ChangeAnimation (ANIMATION_FLYING);
		else if (GUI.Button (new Rect(10, 50, 100, 30), "Gliding"))
			ChangeAnimation (ANIMATION_GLIDING);

		GUI.Label (new Rect (10, 90, 120, 20), "Animation Speed:");

		float oldAnimationSpeed = animationSpeed;
		animationSpeed = GUI.HorizontalSlider (new Rect(10, 110, 100, 30), animationSpeed, 0.1f, 3.0f);

		if (animationSpeed != oldAnimationSpeed)
			ChangeAnimation (currentAnimation, 0.0f);

		if (GUI.Button (new Rect(10, 170, 100, 30), "Normal"))
			ChangeModel (swallow);
		else if (GUI.Button (new Rect(10, 210, 100, 30), "Low Poly"))
			ChangeModel (swallowLowPoly);
	}

	private void ChangeAnimation (string newAnimation, float duration = 1.0f)
	{
		currentModel.animation.CrossFade (newAnimation, duration, PlayMode.StopAll);
		currentModel.animation[newAnimation].speed = animationSpeed;
		currentAnimation = newAnimation;
	}

	private void ChangeModel (GameObject newModel)
	{
		currentModel = newModel;

		swallow.SetActive (false);
		swallowLowPoly.SetActive (false);
		currentModel.SetActive (true);

		ChangeAnimation (currentAnimation, 0.0f);
	}
}
