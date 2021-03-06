﻿using UnityEngine;
using System.Collections;

public class BugManager : MonoBehaviour {
	protected BugPoolManager poolManager;

	// Use this for initialization
	void Start () {
		poolManager = transform.root.GetComponentInChildren<BugPoolManager>();

		if (poolManager == null) {
			poolManager = GameObject.FindGameObjectWithTag("BugPool").GetComponent<BugPoolManager>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("BirdBeak")) {
			poolManager.Recycle(this.transform);
		}
	}
}
