using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavPatrol : MonoBehaviour {

	public Transform[] points;
    public bool onPatrol;
	private int destPoint = 0;
	private UnityEngine.AI.NavMeshAgent agent;


	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		agent.autoBraking = false;
        if (points.Length > 0)
            onPatrol = true;

		GotoNextPoint ();
	}
	
	// Update is called once per frame
	void Update () {
        if (agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
	}

	void GotoNextPoint() {
		if (points.Length == 0)
			return;

        ExecuteAfterTime(3);
        agent.destination = points [destPoint].position;
		destPoint = (destPoint + 1) % points.Length;
	}

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
