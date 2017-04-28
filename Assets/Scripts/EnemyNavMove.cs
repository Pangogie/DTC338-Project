using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavMove : MonoBehaviour {

	public Transform goal;

	// Use this for initialization
	void Start () {
		UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		agent.destination = goal.position;
	}
	
	// Update is called once per frame
	void Update () {
		UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		agent.destination = goal.position;
	}

	void OnEnable() {
		UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		agent.destination = goal.position;
	}
}
