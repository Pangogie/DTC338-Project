using UnityEngine;
using System.Collections;

public class shootBall : MonoBehaviour {

    public GameObject projectile;
    public float speed = 1000;
    private GameObject clone;
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            clone = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;
            clone.AddComponent<DestroyBall>();

            clone.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        }
	}
}
