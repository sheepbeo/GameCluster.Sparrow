using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Camera))]
public class MinimapCamera : MonoBehaviour {

	public Transform target;
	public Terrain terrain;

	private float[] camLimits = new float[] {0,0,0,0}; // minX - maxX - minZ - maxZ
	
	// Use this for initialization
	void Start () {
		initializeTerrainLimits();
		followTargetWithLimit();
	}
	
	// Update is called once per frame
	void Update () {
		followTargetWithLimit();
	}

	// set the limit so that the Minimap camera does view outside of the terrain
	private void initializeTerrainLimits() {
		if (terrain != null) {
			Vector3 terrainPos = terrain.transform.position;
			float camOthSize = camera.orthographicSize;
			float terrainSizeX = terrain.terrainData.size.x;
			float terrainSizeZ = terrain.terrainData.size.z;

			camLimits[0] = terrainPos.x + Mathf.Min(camOthSize, terrainSizeX/2);
			camLimits[1] = terrainPos.x + terrainSizeX - Mathf.Min(camOthSize, terrainSizeX/2);
			camLimits[2] = terrainPos.z + Mathf.Min(camOthSize, terrainSizeZ/2);
			camLimits[3] = terrainPos.z + terrainSizeZ - Mathf.Min(camOthSize, terrainSizeZ/2);
		}
	}
	
	private void followTargetWithLimit() {
		Vector3 nextPosition = target.position;
		nextPosition.y = transform.position.y;

		// Clamp X and Z by the limits:
		nextPosition.x = Mathf.Clamp(nextPosition.x, camLimits[0], camLimits[1]);
		nextPosition.z = Mathf.Clamp(nextPosition.z, camLimits[2], camLimits[3]);
		
		this.transform.position = nextPosition;
	}
}
