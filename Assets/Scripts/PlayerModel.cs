using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour {
    public int health = 10;
    public int attack;
    public int chests = 0;
    private TyController ty;


	// Use this for initialization
	void Start () {
        ty = GetComponent<TyController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
            Die();
        if (Input.GetKey(KeyCode.LeftShift))
            ty.speed = 8;
        else
            ty.speed = 4;
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Chest")
        {
            chests++;
        }

    }

    void OnCollisionStay(Collision other)
    {
        if (other.collider.tag == "Enemy")
            health--;
    }

    void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

}
