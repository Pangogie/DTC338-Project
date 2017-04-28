using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyController : MonoBehaviour {

	public int turnspeed = 3;
	public int speed = 4;
	private Animator animator;
	public Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");


		animator.SetFloat("VSpeed", Input.GetAxis("Vertical"));
		animator.SetFloat("HSpeed", Input.GetAxis("Horizontal"));


		if(Input.GetAxis("Mouse X") < 0)
			transform.Rotate(Vector3.up * -turnspeed);
		if(Input.GetAxis("Mouse X") > 0)
			transform.Rotate(Vector3.up * turnspeed);

		if (v > 0) {
			transform.position += transform.forward * speed * Time.deltaTime;
		} else if (v < 0) {
			transform.position -= transform.forward * speed * Time.deltaTime;
		}

		if (h > 0) {
			transform.position += transform.right * speed * Time.deltaTime;
		} else if (h < 0) {
			transform.position -= transform.right * speed * Time.deltaTime;
		}
	}

//<<<<<<< HEAD
//=======
	void OnCollisionEnter(Collision col) {

	}
//>>>> origin/master

}
