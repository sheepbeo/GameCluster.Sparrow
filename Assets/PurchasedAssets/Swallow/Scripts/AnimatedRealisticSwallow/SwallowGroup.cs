using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class SwallowGroup : MonoBehaviour 
{
	[SerializeField]
	private int _instances = 10;
	
	[SerializeField]
	private float _heightVariation = 20.0f;
	
	[SerializeField]
	private float _radius = 200.0f;
	
	[SerializeField]
	private bool _forceLowPoly = false;
	
	public int instances
	{
		get
		{ 
			return _instances;  
		}
		set
		{ 
			if (value != _instances)
			{
				_instances = value; 
			}
		}
	}
	
	public float heightVariation
	{
		get
		{ 
			return _heightVariation;  
		}
		set
		{ 
			if (value != _heightVariation)
			{
				_heightVariation = value; 
			}
		}
	}
	
	public float radius
	{
		get
		{ 
			return _radius;  
		}
		set
		{ 
			if (value != _radius)
			{
				_radius = value; 
			}
		}
	}
	
	public bool forceLowPoly
	{
		get
		{ 
			return _forceLowPoly;  
		}
		set
		{ 
			if (value != _forceLowPoly)
			{
				_forceLowPoly = value; 
			}
		}
	}
	
	private const string BIRD_NAME = "Swallow";
	private const string PREFAB_BASE_PATH = "Prefabs/AnimatedRealisticSwallow/";
	
	private List<GameObject> birds;
	
	void Start () 
	{
		birds = new List<GameObject> ();
		
		for (int i = 0; i < _instances; i++)
		{
			GameObject bird = (GameObject) Instantiate (Resources.Load (PREFAB_BASE_PATH + (_forceLowPoly ? BIRD_NAME + "LowPoly" : BIRD_NAME + "LOD")));
			bird.name = BIRD_NAME + i;
			bird.transform.parent = transform;
			
			bird.GetComponent<Swallow> ().Setup (radius, _heightVariation);
			
			birds.Add (bird);
		}
	}
	
	void Update () 
	{
	}
	
	public void Destroy ()
	{
		if (birds != null)
		{
			int l = birds.Count;
			
			for (int i = 0; i < l; i++)
			{
				GameObject.Destroy (birds[i]);
			}
			
			birds = null;
		}
	}
}
