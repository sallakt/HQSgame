using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserDoorTrap : toggleTarget {
	/// <summary>
	/// The death zone is the trigger collider of the laser door
	/// </summary>
	Collider2D deathZone;
	/// <summary>
	/// The laser sprite is the sprite renderer of the laser beam for the door
	/// </summary>
	SpriteRenderer laserSprite;
	/// <summary>
	/// Get all the necessary component from the object this code is attached to
	/// </summary>
	void Start () {
		deathZone = GetComponent<Collider2D> ();
		laserSprite = GetComponent<SpriteRenderer> ();
		//deathZone.enabled = true;
		//laserSprite.enabled = true;
	}

	/// <summary>
	/// Method overidden from parent toggleTarget.
	/// Set the sprite renderer and collider to active/inactive depends on the needed state
	/// </summary>
	/// <param name="open">If set to <c>true</c> open.</param>
	public override void SetState(bool open)
	{
		base.SetState (open);
		deathZone.enabled = !open;
		laserSprite.enabled = !open;
	}
}

