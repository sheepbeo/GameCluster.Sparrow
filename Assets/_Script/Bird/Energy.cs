using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {
	// Hunger variables
	public float startingHunger;
	public float warningHungerLevel;

	// Hunger bar GUI variables:
	public Texture innerHungerTexture;
	public Texture baseHungerTexture;
	private float innerHungerTextureLength;
	private float maxInnerHungerTextureLength;

	// Thirst variables
	public float startingThirst;
	public float warningThirstLevel;
	
	// Thirst bar GUI variables:
	public Texture innerThirstTexture;
	public Texture baseThirstTexture;
	private float innerThirstTextureLength;
	private float maxInnerThirstTextureLength;

	// Movement script
	private BirdMovement movement;

	// Decrease Rate:
	public float decreaseRateNormal = 1.0f;  // per second
	public float decreaseRateDashing = 5.0f;  // per second
	private float decreaseRate;    // per second
	
	private float hunger;
	private float thirst;

	// Use this for initialization
	void Start () {
		this.hunger = startingHunger;
		maxInnerHungerTextureLength = 252;
		innerHungerTextureLength = maxInnerHungerTextureLength;

		this.thirst = startingThirst;
		maxInnerThirstTextureLength = 252;
		innerThirstTextureLength = maxInnerThirstTextureLength;

		this.decreaseRate = decreaseRateNormal;
		movement = this.GetComponent<BirdMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		checkDecreaseRate();

		// decrease energy continuously
		ReplenishHunger(-decreaseRate * Time.deltaTime);
		ReplenishThirst(-decreaseRate * Time.deltaTime);
		this.innerHungerTextureLength = maxInnerHungerTextureLength * this.hunger / startingHunger;
		this.innerThirstTextureLength = maxInnerThirstTextureLength * this.thirst / startingThirst;
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(10,10,256,32), baseHungerTexture);
		GUI.DrawTexture(new Rect(12,12,innerHungerTextureLength,28), innerHungerTexture);

		GUI.DrawTexture(new Rect(10,45,256,32), baseThirstTexture);
		GUI.DrawTexture(new Rect(12,47,innerThirstTextureLength,28), innerThirstTexture);
	}

	private void checkDecreaseRate() {
		if (movement != null && movement.IsDashing) {
			this.decreaseRate = decreaseRateDashing;
		} else {
			this.decreaseRate = decreaseRateNormal;
		}
	}

	public void ReplenishHunger(float amount) {
		this.hunger = Mathf.Clamp(this.hunger + amount, 0, this.startingHunger);
	}

	public void ReplenishThirst(float amount) {
		this.thirst = Mathf.Clamp(this.thirst + amount, 0, this.startingThirst);
	}
}
