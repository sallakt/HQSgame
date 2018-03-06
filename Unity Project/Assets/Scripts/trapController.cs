using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapController : MonoBehaviour {

	//player - trap interaction
	public reloadTrap levelManager;
	// Use this for initialization
	void Start () {
		//player - trap interaction
		levelManager = FindObjectOfType<reloadTrap>();
	}

	//player - trap interaction
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			levelManager.respawnPlayer ();
		}
	}
}
