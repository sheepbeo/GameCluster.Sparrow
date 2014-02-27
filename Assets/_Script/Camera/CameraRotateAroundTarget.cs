using UnityEngine;
using System.Collections;

public class CameraRotateAroundTarget : MonoBehaviour {
	public Transform target;
	public Transform BlurTransparentEffect;

	public float radius;
	public float heightOffset;
	public float rotationSpeed = 10.0f; // Degree per second

	// Use this for initialization
	void Start () {

	}

	public void OnEnable() {
		resetPosition();
		BlurTransparentEffect.gameObject.SetActive(true);
	}

	public void OnDisable() {
		BlurTransparentEffect.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.RotateAround(target.position + Vector3.up * heightOffset,
		                            Vector3.up,
		                            rotationSpeed * Time.deltaTime);
		this.transform.LookAt(target.position);
//		print("update" + Time.deltaTime);
	}

	private void resetPosition() {
		this.transform.position = target.position + Vector3.up * heightOffset - Vector3.forward * radius;
		this.transform.LookAt(target.position);
	}
}
