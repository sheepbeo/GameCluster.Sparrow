using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(SwallowGroup))]
public class SwallowGroupCustomInspector : Editor 
{
	private const int MAX_INSTANCES = 100;
	
	public override void OnInspectorGUI () 
	{ 
		SwallowGroup prefab = target as SwallowGroup;
		
		prefab.instances = (int)EditorGUILayout.Slider ("Instances", prefab.instances, 0, MAX_INSTANCES);
		prefab.heightVariation =  EditorGUILayout.FloatField ("Height variation", prefab.heightVariation);
		prefab.radius =  EditorGUILayout.FloatField ("Radius", prefab.radius);
		prefab.forceLowPoly = EditorGUILayout.Toggle ("Force low poly", prefab.forceLowPoly);
	}
}
