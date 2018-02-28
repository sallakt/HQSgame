using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowShooter : MonoBehaviour {

	//arrow script:
	public arrow myarrow;

	public float arrowSpeed;
	private float time = 0;
	public float arrowDelay;

	public bool fromLeft = false;
	public bool shoot = false;

	private Vector2 direction2;

	void Start () {
		direction2 = new Vector2 (arrowSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (shoot == true) {
			
			//arrow delay:
			if (time < Time.time) {
				//create the arrow
				arrow arrow = Instantiate<arrow>(myarrow, transform.position, transform.rotation) as arrow;
				//set direction and speed
				arrow.direction = direction2;
				//when shooting from the left we want to rotate the arrow accordingly
				if (fromLeft == true) {
					arrow.transform.rotation = Quaternion.Euler (0, 0, 180);
				} else {
					arrow.transform.rotation = Quaternion.Euler (0, 0, 0);
				}
				time = Time.time + arrowDelay;
			}
		}
	}
	//when you enter the shooting box's area it will start shooting:
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			shoot = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			shoot = false;
		}
	}
}