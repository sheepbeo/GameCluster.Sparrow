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
	public float poisonedFactor = 3.0f;

	private bool isPoisoned = false;
	private float decreaseRate;    // per second

	// Bug icons
	public Texture hungerBugIcon;
	public Texture thirstBugIcon;
	
	private float hunger;
	private float thirst;

	private bool isDead = false;

	// register Event handlers
	void Awake() {
		BirdPoisonSensor birdPoisonSensor = GetComponent<BirdPoisonSensor>();
		if (birdPoisonSensor) {
			birdPoisonSensor.BirdStartPoisoned += BirdStartPoisonedEventHandler;
			birdPoisonSensor.BirdStopPoisoned += BirdStopPoisonedEventHandler;
		}

		GameManager.GameReset += GameResetEventHandler;
	}

	// Use this for initialization
	void Start () {
		// initialize hunger bar:
		this.hunger = startingHunger;
		maxInnerHungerTextureLength = 252;
		innerHungerTextureLength = maxInnerHungerTextureLength;

		// initialize thirst bar:
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

		if (IsOneEmpty() && !isDead) {
			GameManager.SetStateTriggerEvent(GameState.LOSE);
			isDead = true;
		}
	}

	void OnGUI() {
		setGUIDepth();

		// Draw bug icons:
		GUI.DrawTexture(new Rect(10,10,32,32), hungerBugIcon);
		GUI.DrawTexture(new Rect(10,45,32,32), thirstBugIcon);

		// Draw bars:
		GUI.DrawTexture(new Rect(52,10,256,32), baseHungerTexture);
		GUI.DrawTexture(new Rect(54,12,innerHungerTextureLength,28), innerHungerTexture);
		GUI.DrawTexture(new Rect(52,45,256,32), baseThirstTexture);
		GUI.DrawTexture(new Rect(54,47,innerThirstTextureLength,28), innerThirstTexture);
	}

	protected void setGUIDepth() {
		GUI.depth = GUIDepths.ENERGY_BARS_LAYER;
	}

	private void checkDecreaseRate() {
		if (movement != null && movement.IsDashing) {
			this.decreaseRate = decreaseRateDashing;
		} else {
			this.decreaseRate = decreaseRateNormal;
		}

		if (this.isPoisoned) {
			this.decreaseRate *= poisonedFactor;
		}
	}

	public void ReplenishHunger(float amount) {
		this.hunger = Mathf.Clamp(this.hunger + amount, 0, this.startingHunger);
	}

	public void ReplenishThirst(float amount) {
		this.thirst = Mathf.Clamp(this.thirst + amount, 0, this.startingThirst);
	}

	public bool IsOneEmpty() {
		return (this.hunger <= 0 || this.thirst <=0);
	}

	public void Reset() {
		this.hunger = startingHunger;
		this.thirst = startingThirst;
	}

	public void BirdStartPoisonedEventHandler() {
		this.isPoisoned = true;
	}

	public void BirdStopPoisonedEventHandler() {
		this.isPoisoned = false;
	}

	private void GameResetEventHandler() {
		this.isDead = false;
	}
}

