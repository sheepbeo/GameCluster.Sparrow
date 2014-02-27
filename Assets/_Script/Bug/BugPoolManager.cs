using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BugPoolManager : MonoBehaviour, IPool {
	public float PoolSize;
	public Transform Prefab;
	public Transform poolBounds;
	public Transform bugsContainer;

	protected List<Transform> bugs;
	protected float rangeX;
	protected float rangeY;
	protected float rangeZ;

	// Use this for initialization
	void Start () {
		BoxCollider poolBoundCollider = poolBounds.GetComponent<BoxCollider>();

		rangeX = poolBoundCollider.size.x/2;
		rangeY = poolBoundCollider.size.y/2;
		rangeZ = poolBoundCollider.size.z/2;

		bugs = new List<Transform>();
		for (int i = 0; i < PoolSize; i++) {
			Transform t = (Transform) Instantiate(Prefab, transform.position, Quaternion.identity);
			t.parent = bugsContainer;
			Recycle(t);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Recycle() {

	}

	public void Recycle(Transform wastedTransform) {
		Vector3 nextPos = this.transform.position;

		nextPos.x += Random.Range(-rangeX, rangeX);
		nextPos.y += Random.Range(-rangeY, rangeY);
		nextPos.z += Random.Range(-rangeZ, rangeZ);

		wastedTransform.position = nextPos;
	}
}
