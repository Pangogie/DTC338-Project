using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBar : MonoBehaviour {
    public GameObject player;
    public int chests;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        chests = player.GetComponent<PlayerModel>().chests;
        GetComponent<UnityEngine.UI.Text>().text = "Chests: " + chests.ToString() + "/12";
    }
}
