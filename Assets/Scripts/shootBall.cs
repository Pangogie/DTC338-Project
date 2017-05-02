using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class shootBall : MonoBehaviour {

    public GameObject projectile;
    public float speed = 1000;
    private GameObject clone;
    public AudioSource audio;

    void Start()
    {
        audio.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            clone = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;
            clone.AddComponent<DestroyBall>();

            clone.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            audio.PlayOneShot(audio.clip, 0.7f);
        }
	}
}
