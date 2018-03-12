using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadTrap : LevelManager {
	/// <summary>
	/// Respawns the player.
	/// Set the parent to null (moving platform interaction)
	/// Add 1 to the number of attempts
	/// Loads the "GameOver" scene
	/// </summary>
    public override void respawnPlayer()
	{
		base.respawnPlayer ();
		SceneManager.LoadScene ("GameOver");
    }
}
