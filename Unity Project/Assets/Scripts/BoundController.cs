using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundController : MonoBehaviour {

	public reloadBoundOfMap levelManager;

	void Start()
	{
		levelManager = FindObjectOfType<reloadBoundOfMap>();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player") {
			levelManager.respawnPlayer ();
		}
	}
}
