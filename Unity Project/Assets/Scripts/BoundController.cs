using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundController : MonoBehaviour {
	/// <summary>
	/// levelManager is an object of class reloadBoundOfMap (child of LevelManager)
	/// </summary>
	public reloadBoundOfMap levelManager;
	/// <summary>
	/// Start this instance by finding the corresponding object:
	/// a Game Object with a trigger collider that act as a trigger when colliding with another collider
	/// that belongs to any object with the "Player" tag
	/// </summary>
	void Start()
	{
		levelManager = FindObjectOfType<reloadBoundOfMap>();
	}
	/// <summary>
	/// Raises the trigger enter2 d event.
	/// Calls the respawn player method when the collider of the object attached with this code
	/// enters the trigger collider of another object with tag "Player"
	/// </summary>
	/// <param name="collider">Collider.</param>
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player") {
			levelManager.respawnPlayer ();
		}
	}
}
