using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapController : MonoBehaviour {
    /// <summary>
    /// Sound created when an object of tag "Player" touches the collider of the object this script attaches to
    /// </summary>
	public dieSoundManager dieSound;
	/// <summary>
	/// levelManager is an object of class reloadTrap (child of LevelManager)
	/// </summary>
    public reloadTrap levelManager;

	/// <summary>
	/// Get the necessary components in the object this script is attached to
	/// </summary>
	void Start () {
		//player - trap interaction
		levelManager = FindObjectOfType<reloadTrap>();
        dieSound = GameObject.FindGameObjectWithTag("DieSound").GetComponent<dieSoundManager>();
    }

	/// <summary>
	/// Respawn the character if the collider of an object tagged "Player" touches a collider of this object
	/// </summary>
	/// <param name="collider">The collider of the object that enters that of this object</param>
    void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
            dieSound.Playsound("characterDie");
            levelManager.respawnPlayer ();
        }
	}
}
