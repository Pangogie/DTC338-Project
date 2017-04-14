using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent (typeof(Animator))]

public class EnemyLocomotionAgent : MonoBehaviour {
	Animator anim;
	UnityEngine.AI.NavMeshAgent agent;
	Vector2 smoothDeltaPosition = Vector2.zero;
	Vector2 velocity = Vector2.zero;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		//Don't update position automatically.
		agent.updatePosition = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 worldDeltaPosition = agent.nextPosition - transform.position;

		//Map 'worldDeltaPosition' to local space.
		float dx = Vector3.Dot(transform.right, worldDeltaPosition);
		float dy = Vector3.Dot (transform.forward, worldDeltaPosition);
		Vector2 deltaPosition = new Vector2 (dx, dy);

		//Low-pass filter the deltaMove.
		float smooth = Mathf.Min(1.0f, Time.deltaTime/0.15f);
		smoothDeltaPosition = Vector2.Lerp (smoothDeltaPosition, deltaPosition, smooth);

		//Update velocity on tick.
		if (Time.deltaTime > 1e-5f)
			velocity = smoothDeltaPosition / Time.deltaTime;

		bool shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;

        if (GetComponent<EnemyNavPatrol>().onPatrol)
            shouldMove = true;

		//Update animation parameters.
		anim.SetBool("move", shouldMove);
		anim.SetFloat ("velx", velocity.x);
		anim.SetFloat ("vely", velocity.y);

		GetComponent<EnemyLookAt> ().lookAtTargetPosition = agent.steeringTarget + transform.forward;

		EnemyLookAt lookAt = GetComponent<EnemyLookAt> ();
		if (lookAt)
			lookAt.lookAtTargetPosition = agent.steeringTarget + transform.forward;

		//Pull character towards agent.
		if (worldDeltaPosition.magnitude > agent.radius)
			transform.position = agent.nextPosition - 0.99f * worldDeltaPosition;

		//Pull agent towards character.
		//if (worldDeltaPosition.magnitude > agent.radius)
		//	agent.nextPosition = transform.position + 0.5f * worldDeltaPosition;
	}

	void OnAnimatorMove() {
		//Update position based on animation movement using NavMesh.
		//Vector3 position = anim.rootPosition;
		//position.y = agent.nextPosition.y;
		//transform.position = position;
	}
}
