using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float turnSpeed = 0.4f;
	public Transform Player;

	public float height = 1f;
	public float distance = 2f;
	private Vector3 offsetX;



	// Use this for initialization
	void Start () {
		offsetX = new Vector3 (0, height, distance);


	}
	
	// Update is called once per frame
	void LateUpdate () {
		offsetX = Quaternion.AngleAxis (Input.GetAxis("Horizontal") * turnSpeed, Vector3.up) * offsetX;
		transform.position = Player.position + offsetX;
		transform.LookAt (Player.position);
	}
}
