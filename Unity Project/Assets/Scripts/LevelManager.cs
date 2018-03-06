using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : playerHealth {

	//public GameObject currentCheckpoint;
	private playerController player;
	//private playerHealth spawnHealth;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<playerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void respawnPlayer() {
		SceneManager.LoadScene ("GameOver");
		player.transform.parent = null;
		playerHealth.playerScore++;
	}
}
