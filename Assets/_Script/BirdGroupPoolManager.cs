using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BirdGroupPoolManager : MonoBehaviour {
	public Transform origin;
	public Transform destination;

	public Transform prefab;

	public int poolSize = 3;
	public float spawnInterval = 10.0f;
	
	private Queue<Transform> deactivatedBirdGroups = new Queue<Transform>();

	private float spawnIntervalTimer;

	// Use this for initialization
	void Start () {
		spawnIntervalTimer = spawnInterval;

		for (int i=0; i<poolSize; i++) {
			initializeOneGroupBird();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (origin && destination) {
			if (spawnIntervalTimer >= spawnInterval) {
				spawnIntervalTimer = 0;
				this.Load();
			} else {
				spawnIntervalTimer += Time.deltaTime;
			}
		}
	}

	private void initializeOneGroupBird() {
		Transform groupBirdTransform = (Transform) Instantiate(prefab, this.origin.position, Quaternion.identity);
		groupBirdTransform.parent = this.transform;

		BirdGroupManager groupBirdManager = groupBirdTransform.GetComponent<BirdGroupManager>();
		if (groupBirdManager) {
			groupBirdManager.finalDestination = this.destination;
		}

		Store(groupBirdTransform);
	}

	public void Store(Transform t) {
		t.gameObject.SetActive(false);
		deactivatedBirdGroups.Enqueue(t);
	}

	public void Load() {
		if (deactivatedBirdGroups.Count > 0) {
			Transform t = deactivatedBirdGroups.Dequeue();
			Recycle(t);
			t.gameObject.SetActive(true);
		}
	}

	public void Recycle(Transform t) {
		t.position = this.origin.position;
	}
}
