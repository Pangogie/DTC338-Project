using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNavPath : MonoBehaviour {

	private LineRenderer line;
	private Transform target;
	private UnityEngine.AI.NavMeshAgent agent;

	void Start() {
		line = GetComponent<LineRenderer>(); //get the line renderer
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>(); //get the agent
		GetPath();
	}

	void GetPath() {
		line.SetPosition(0, transform.position); //set the line's origin

		//agent.SetDestination(target.position); //create the path
		//yield WaitForEndOfFrame(); //wait for the path to generate

		DrawPath(agent.path);


		//agent.Stop();//add this if you don't want to move the agent
	}

	void DrawPath(UnityEngine.AI.NavMeshPath path) {
		if(path.corners.Length < 2) //if the path has 1 or no corners, there is no need
			return;

		line.SetVertexCount(path.corners.Length); //set the array of positions to the amount of corners

		for(var i = 1; i < path.corners.Length; i++){
			line.SetPosition(i, path.corners[i]); //go through each corner and set that to the line renderer's position
		}
	}
}
