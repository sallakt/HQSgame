using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;
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
		player.transform.position = currentCheckpoint.transform.position;
		player.transform.parent = null;
	}
}
