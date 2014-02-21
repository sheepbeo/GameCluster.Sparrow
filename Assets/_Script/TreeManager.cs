using UnityEngine;
using System.Collections;

public class TreeManager : MonoBehaviour {
	public Terrain terrain;
	public GameObject[] CollidersPrefab;

	private TreeInstance[] treeInstances;
	private TreePrototype[] treePrototypes;

	// Use this for initialization
	void Start () {
		treePrototypes = terrain.terrainData.treePrototypes;
		treeInstances = terrain.terrainData.treeInstances;

		foreach (TreeInstance treeInst in treeInstances) {
			foreach (GameObject colliPrefb in CollidersPrefab) {
				if (treePrototypes[treeInst.prototypeIndex].prefab.CompareTag(colliPrefb.tag)) {
					Vector3 colliderPos = treeInst.position;
					colliderPos.x *= terrain.terrainData.size.x;
					colliderPos.y *= terrain.terrainData.size.y;
					colliderPos.z *= terrain.terrainData.size.z;
					colliderPos += terrain.transform.position;

					Instantiate(colliPrefb, colliderPos, Quaternion.identity);
				}
			}
		}

	}
	
	// Update is called once per frame
	void Update () {

	}
}
