using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroTrigger : MonoBehaviour {
	EnemyNavMove enemyAI;
	EnemyNavPatrol enemyPatrol;
	Transform player;

	void Start() {
		enemyAI = transform.parent.GetComponent<EnemyNavMove> ();
		enemyPatrol = transform.parent.GetComponent<EnemyNavPatrol> ();
		player = GameObject.FindWithTag ("Player").transform;
	}

	void OnTriggerEnter(Collider other) {
		enemyPatrol.enabled = false;
		enemyAI.enabled = true;
		enemyAI.goal = player;
	}

	void OnTriggerStay(Collider other) {
		
	}

	void OnTriggerExit(Collider other) {
		enemyAI.enabled = false;
		enemyPatrol.enabled = true;
	}
}
