using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {
	// Energy variables
	public float startingEnergy;
	public float warningEnergyLevel;
	public float decreaseRate;  // per second

	// Energy bar GUI variables:
	public Texture innerEnergyTexture;
	public Texture baseEnergyTexture;
	private float innerEnergyTextureLength;
	private float maxInnerEnergyTextureLength;

	[SerializeField]
	private float energy;


	// Use this for initialization
	void Start () {
		this.energy = startingEnergy;
		maxInnerEnergyTextureLength = 252;
		innerEnergyTextureLength = maxInnerEnergyTextureLength;
	}
	
	// Update is called once per frame
	void Update () {
		// decrease energy continuously
		Replenish(-decreaseRate * Time.deltaTime);
		this.innerEnergyTextureLength = maxInnerEnergyTextureLength * this.energy / startingEnergy;
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(10,10,256,32), baseEnergyTexture);
		GUI.DrawTexture(new Rect(12,12,innerEnergyTextureLength,28), innerEnergyTexture);
	}

	public void Replenish(float amount) {
		this.energy = Mathf.Clamp(this.energy + amount, 0, this.startingEnergy);
	}
}
