﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blade : MonoBehaviour {

	public playerHealth die;
	public float rotationspeed;

	//what the blade does - rotates with x speed
	void FixedUpdate () {
		this.transform.Rotate(new Vector3(0,0,rotationspeed));
	}
	//what happens when touched - death
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.CompareTag ("Player")) {
			die.makeDead();
		}
	}
}