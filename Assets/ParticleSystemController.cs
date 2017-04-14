using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TriggerParticles()
	{
		var systems = GetComponentsInChildren<ParticleSystem>();
		foreach (ParticleSystem system in systems) {
			system.Play ();
		}
	}
}
