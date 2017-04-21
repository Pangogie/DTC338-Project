using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		StartCoroutine(HandleEnd(other));
	}

	IEnumerator HandleEnd(Collider other)
	{
		yield return new WaitForSeconds(3);

		if (other.tag == "Player")
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Scene2");
	}
}
