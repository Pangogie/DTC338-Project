using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyController : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");


		animator.SetFloat("VSpeed",Input.GetAxis("Vertical"));
		animator.SetFloat("HSpeed",Input.GetAxis("Horizontal"));

	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.CompareTag(""))
		{
			animator.SetTrigger("");
		}
	}
}
