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
        {
            if (other.GetComponent<PlayerModel>().chests == 12)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Scene2");
                Application.Quit();
            }
        }

	}
}
