using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapController : MonoBehaviour {
    public dieSoundManager dieSound;
    //player - trap interaction
    public reloadTrap levelManager;
	// Use this for initialization
	void Start () {
		//player - trap interaction
		levelManager = FindObjectOfType<reloadTrap>();
        dieSound = GameObject.FindGameObjectWithTag("DieSound").GetComponent<dieSoundManager>();
    }

    //player - trap interaction
    void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
            dieSound.Playsound("characterDie");
            levelManager.respawnPlayer ();
        }
	}
}
