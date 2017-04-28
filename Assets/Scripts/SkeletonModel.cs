using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonModel : MonoBehaviour {
    public bool onPatrol;
    public int health;
    public int attackDamage;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (health <= 0)
			Die ();

	}

	void Die() {
		GameObject system = GameObject.Find ("ExplosionMobile");
		GameObject newsystem = Instantiate (system);
		newsystem.transform.position = this.transform.position;
		newsystem.transform.position += new Vector3 (0, 1.5f, 0);
		newsystem.GetComponent<ParticleSystemController> ().TriggerParticles();
		Destroy (gameObject);
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Projectile")
            this.health--;
    }
}
