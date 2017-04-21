using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player")
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Scene2");
	}
}
