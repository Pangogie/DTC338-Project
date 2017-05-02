using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float turnSpeed = 0.4f;
	public Transform Player;

	public float height = 1f;
	public float distance = 2f;
	private Vector3 offset;
	private Vector3 offsetforward;



	// Use this for initialization
	void Start () {
		offset = new Vector3 (0, height, distance);
		offsetforward = new Vector3 (0, 4, 0);
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		//transform.position = Player.position + offset;
		//transform.LookAt (Player.position + offsetforward);
	}
    
    void Update()
    {
        if(Input.GetButtonDown("Escape"))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else if (Cursor.lockState == CursorLockMode.None)
                Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
