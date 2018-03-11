using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserDoorTrap : toggleTarget {

	Collider2D deathZone;
	SpriteRenderer laserSprite;

	void Start () {
		deathZone = GetComponent<Collider2D> ();
		laserSprite = GetComponent<SpriteRenderer> ();
		//deathZone.enabled = true;
		//laserSprite.enabled = true;
	}

	public override void SetState(bool open)
	{
		base.SetState (open);
		deathZone.enabled = !open;
		laserSprite.enabled = !open;
	}
}

