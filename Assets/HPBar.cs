using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour {
    public GameObject player;
    public int hp;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        hp = player.GetComponent<PlayerModel>().health;
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, hp);
	}
}
