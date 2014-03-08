using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BugSwarmStorage))]
public class BugSwarmManager : MonoBehaviour {
	BugSwarmStorage storage;
	BugPoolManager poolManager;

	// Use this for initialization
	void Start () {
		storage = GetComponent<BugSwarmStorage>();

		poolManager = transform.parent.GetComponent<BugPoolManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnBugEaten(Transform bugTransform) {
		storage.Store(bugTransform);

		if (storage.IsAllBugEaten()) {
			poolManager.Recycle(this.transform);
			storage.LoadAll();
		}
	}
}
