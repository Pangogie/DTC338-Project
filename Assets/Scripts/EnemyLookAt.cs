﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAt : MonoBehaviour {
	public Transform head = null;
	public Vector3 lookAtTargetPosition;
	public float lookAtCoolTime = 0.2f;
	public float lookAtHeatTime = 0.2f;
	public bool looking = true;

	private Vector3 lookAtPosition;
	private Animator animator;
	private float lookAtWeight = 0.0f;

	// Use this for initialization
	void Start () {
		if (!head) {
			Debug.LogError ("No head transform. EnemyLookAt disabled.");
			enabled = false;
			return;
		}

		animator = GetComponent<Animator> ();
		lookAtTargetPosition = head.position + transform.forward;
		lookAtPosition = lookAtTargetPosition;
	}
	
	// Update is called once per frame
	void OnAminatorIK() {
		lookAtTargetPosition.y = head.position.y;
		float lookAtTargetWeight = looking ? 1.0f : 0.0f;

		Vector3 curDir = lookAtPosition - head.position;
		Vector3 futDir = lookAtTargetPosition - head.position;

		curDir = Vector3.RotateTowards (curDir, futDir, 6.28f * Time.deltaTime, float.PositiveInfinity);
		lookAtPosition = head.position + curDir;

		float blendTime = lookAtTargetWeight > lookAtWeight ? lookAtHeatTime : lookAtCoolTime;
		lookAtWeight = Mathf.MoveTowards (lookAtWeight, lookAtTargetWeight, Time.deltaTime / blendTime);
		animator.SetLookAtWeight (lookAtWeight, 0.2f, 0.f, 0.7f, 0.5f);
		animator.SetLookAtPosition (lookAtPosition);
	}
}
