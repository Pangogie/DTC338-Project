using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SkeletonModel : MonoBehaviour {
    public bool onPatrol;
    public int health;
    public int attackDamage;
    public AudioSource audio;
    private bool dead;

    // Use this for initialization
    void Start () {
        audio = gameObject.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
        if (health <= 0 && !dead)
			Die ();

	}

	void Die() {
        dead = true;
		GameObject system = GameObject.Find ("ExplosionMobile");
		GameObject newsystem = Instantiate (system);
		newsystem.transform.position = this.transform.position;
		newsystem.transform.position += new Vector3 (0, 1.5f, 0);
		newsystem.GetComponent<ParticleSystemController> ().TriggerParticles();
        audio.PlayOneShot(audio.clip, 0.7f);
        Destroy (gameObject, audio.clip.length);
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Projectile")
            this.health--;
    }
}
