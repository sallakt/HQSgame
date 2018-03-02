using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapController : MonoBehaviour {

	//player - trap interaction
	public LevelManager levelManager;
	// Use this for initialization
	void Start () {
		//player - trap interaction
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//player - trap interaction
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			levelManager.respawnPlayer ();
		}
	}
}
