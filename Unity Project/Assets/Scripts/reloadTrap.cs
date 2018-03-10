using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadTrap : LevelManager {
    public override void respawnPlayer()
	{
		base.respawnPlayer ();
		SceneManager.LoadScene ("GameOver");
    }
}
