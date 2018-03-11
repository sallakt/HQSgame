using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	/// <summary>
	/// Takes an object of class "playerController" to manage the heirachy of the character
	/// (interaction with moving platforms)
	/// </summary>
	private playerController player;

	/// <summary>
	/// Get the necessary components in the object this script is attached to
	/// </summary>
	void Start () {
		player = FindObjectOfType<playerController> ();
	}
	/// <summary>
	/// Respawns the player.
	/// Set the parent to null (moving platform interaction)
	/// Add 1 to the number of attempts
	/// </summary>
	public virtual void respawnPlayer() {
		player.transform.parent = null;
		playerHealth.playerScore++;
	}
}
