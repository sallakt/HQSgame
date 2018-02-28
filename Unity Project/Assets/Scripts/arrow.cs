using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class arrow : MonoBehaviour {
	Rigidbody2D arrowbody;
	public Vector2 direction = new Vector2(0,0);

	void Start () {
		arrowbody = GetComponent<Rigidbody2D> ();
	}
	
	void FixedUpdate () {
		arrowbody.velocity = direction;
	}
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.CompareTag ("Player")) {
			SceneManager.LoadScene ("Level1");
		}
	}
}