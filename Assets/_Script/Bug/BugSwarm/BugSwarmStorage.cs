using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BugSwarmStorage : MonoBehaviour {
	public Transform hungerBugPrefab;
	public Transform thirstBugPrefab;
	public int swarmSize = 3;

	protected BoxCollider bugSwarmBounds;
	protected List<Transform> bugs;
	protected float rangeX;
	protected float rangeY;
	protected float rangeZ;

	// Use this for initialization
	void Start () {
		bugSwarmBounds = GetComponent<BoxCollider>();
		
		rangeX = bugSwarmBounds.size.x/2;
		rangeY = bugSwarmBounds.size.y/2;
		rangeZ = bugSwarmBounds.size.z/2;
		
		bugs = new List<Transform>();
		for (int i = 0; i < swarmSize; i++) {
			Transform bugTransform = createRandomBug();
			initiateBugIntoSwarm(bugTransform);
			bugs.Add(bugTransform);
			Load(bugTransform);
		}
	}

	private Transform createRandomBug() {
		if (UnityEngine.Random.Range(0.0f,1.0f) < 0.5f) {
			return (Transform) Instantiate(hungerBugPrefab, transform.position, Quaternion.identity);
		} else {
			return (Transform) Instantiate(thirstBugPrefab, transform.position, Quaternion.identity);
		}
	}

	private void initiateBugIntoSwarm(Transform bugTransform) {
		bugTransform.parent = this.transform;
		checkAndRemoveComponent<BugManager>(bugTransform);
		checkAndRemoveComponent<RandomBugMovement>(bugTransform);
		if (bugTransform.rigidbody != null) {
			bugTransform.rigidbody.isKinematic = true;
		}

		bugTransform.gameObject.AddComponent<BugEatenInSwarmSensor>();
	}

	private void checkAndRemoveComponent<Comp>(Transform t) where Comp:MonoBehaviour {
		Comp comp = t.GetComponent<Comp>();
		if (comp != null) {
			Destroy(comp);
		}
	}

	public bool IsAllBugEaten() {
		foreach (Transform bugTransform in bugs) {
			if (bugTransform.gameObject.activeSelf)
				return false;
		}

		return true;
	}

	public void Load(Transform t) {
		randomizePositionWithinRange(t, this.transform, rangeX, rangeY, rangeZ);
		t.gameObject.SetActive(true);
	}

	private void randomizePositionWithinRange(Transform t, Transform originTransform, float range_X, float range_Y, float range_Z) {
		Vector3 nextPos = originTransform.position;
		
		nextPos.x += Random.Range(-range_X, range_X);
		nextPos.y += Random.Range(-range_Y, range_Y);
		nextPos.z += Random.Range(-range_Z, range_Z);
		
		t.position = nextPos;
	}

	public void Store(Transform t) {
		t.gameObject.SetActive(false);
	}

	public void LoadAll() {
		foreach(Transform bugTransform in bugs) {
			Load(bugTransform);
		}
	}
}
