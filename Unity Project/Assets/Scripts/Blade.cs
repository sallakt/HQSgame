using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blade : MonoBehaviour {

	public playerHealth die;
	public float rotationspeed;

	/// <summary>
	/// Rotation of the blade: rotates with 'rotationspeed'.
	/// </summary>
	void FixedUpdate () {
		this.transform.Rotate(new Vector3(0,0,rotationspeed));
	}
	/// <summary>
	/// Raises the trigger enter 2d event.
	/// Use: When player touches the blade they die.
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.CompareTag ("Player")) {
			die.makeDead();
		}
	}
}