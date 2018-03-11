using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class arrow : playerHealth {
	Rigidbody2D arrowbody;
	/// <summary>
	/// The sound used for character death.
	/// </summary>
    public dieSoundManager Sound;
    public Vector2 direction = new Vector2(0,0);

	void Start () {
		arrowbody = GetComponent<Rigidbody2D> ();
	}
	void FixedUpdate () {
		arrowbody.velocity = direction;
	}
	/// <summary>
	/// Raises the trigger enter 2d event.
	/// Use: when character collides with arrow, there will be a sound, loads GameOver scene and adds 1 to score
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.CompareTag ("Player")) {
            Sound = GameObject.FindGameObjectWithTag("DieSound").GetComponent<dieSoundManager>();
            Sound.Playsound("characterDie");
            playerHealth.playerScore++;
			SceneManager.LoadScene ("GameOver");
		}
	}
}