using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnitySteer;

public class Swallow : MonoBehaviour 
{
	private const string ANIMATION_GLIDING = "swallowGliding";
	private const string ANIMATION_FLYING = "swallowFlying";
	private const float ANIMATION_TRANSITION_DURATION = 1.0f;
	private const float MIN_ANIMATION_SPEED = 3.0f;
	private const float MAX_ANIMATION_SPEED = 5.0f;
	
	private const float RAD_TO_DEG = 180.0f / Mathf.PI;
	
	private float radius;
	private float heightVariation;
	
	private string currentAnimation = ANIMATION_GLIDING;
	
	private Transform normalPoly;
	private Transform lowPoly;
	
	private AutonomousVehicle vehicle;
	private SteerForPoint steer;
	
	public void Setup (float radius, float heightVariation)
	{
		this.radius = radius;
		this.heightVariation = heightVariation;
		
		float animationRandomPosition = Random.value;
		
		normalPoly = transform.FindChild ("Swallow");
		lowPoly = transform.FindChild ("SwallowLowPoly");
		
		if (normalPoly != null)
		{
			normalPoly.animation[ANIMATION_GLIDING].normalizedTime = animationRandomPosition;
			lowPoly.animation[ANIMATION_GLIDING].normalizedTime = animationRandomPosition;
			normalPoly.animation[ANIMATION_FLYING].normalizedTime = animationRandomPosition;
			lowPoly.animation[ANIMATION_FLYING].normalizedTime = animationRandomPosition;
		}
		else
		{
			animation[ANIMATION_GLIDING].normalizedTime = animationRandomPosition;
			animation[ANIMATION_FLYING].normalizedTime = animationRandomPosition;
		}

		vehicle = gameObject.GetComponent<AutonomousVehicle> ();
		steer = gameObject.GetComponent<SteerForPoint> ();
		
		steer.OnArrival = OnArrival;
		
		transform.position = new Vector3 (Random.value * radius - Random.value * radius, Random.value * heightVariation / 2.0f - Random.value * heightVariation / 2.0f , Random.value * radius - Random.value * radius);
		
		CalculateNewTargetPosition ();
	}
	
	private void ChangeAnimation (string newAnimation)
	{
		if (newAnimation == currentAnimation)
			return;
		
		currentAnimation = newAnimation;
		
		if (normalPoly != null)
		{
			normalPoly.animation.CrossFade (newAnimation, ANIMATION_TRANSITION_DURATION, PlayMode.StopAll);
			lowPoly.animation.CrossFade (newAnimation, ANIMATION_TRANSITION_DURATION, PlayMode.StopAll);
		}
		else
			animation.CrossFade (newAnimation, ANIMATION_TRANSITION_DURATION, PlayMode.StopAll);
	}
	
	private void CalculateNewTargetPosition ()
	{
		steer = gameObject.GetComponent<SteerForPoint> ();
		steer.TargetPoint = new Vector3 (Random.value * radius - Random.value * radius, Random.value * heightVariation / 2.0f - Random.value * heightVariation / 2.0f , Random.value * radius - Random.value * radius);
		steer.enabled = true;
	}
	
	void Start () 
	{
	}
	
	private void OnArrival (object o)
	{
		CalculateNewTargetPosition ();
	}
	
	void Update () 
	{
		if (Random.value < 0.005f)
		{
			CalculateNewTargetPosition ();
		}

		//Debug.Log (vehicle.Velocity.y);

		if (vehicle.Velocity.y > -0.5f)
		{
			ChangeAnimation (ANIMATION_FLYING);
			
			float velY = Mathf.Abs (vehicle.Velocity.y / 5.0f);
			
			if (velY > MAX_ANIMATION_SPEED)
				velY = MAX_ANIMATION_SPEED;
			else if (velY < MIN_ANIMATION_SPEED)
				velY = MIN_ANIMATION_SPEED;
			
			if (normalPoly != null)
			{
				normalPoly.animation[ANIMATION_FLYING].speed = velY;
				lowPoly.animation[ANIMATION_FLYING].speed = velY;
			}
			else
				animation[ANIMATION_FLYING].speed = velY;
		}
		else
			ChangeAnimation (ANIMATION_GLIDING);
	}
}
