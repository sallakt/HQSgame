using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowShooter : MonoBehaviour {

	//arrow script:
	public arrow myarrow;
	/// <summary>
	/// The arrow speed.
	/// </summary>
	public float arrowSpeed;
	/// <summary>
	/// The time betweeen arrows.
	/// </summary>
	private float time = 0;
	/// <summary>
	/// The arrow delay.
	/// </summary>
	public float arrowDelay;
	/// <summary>
	/// Is the arrow shot from the left or right.
	/// </summary>
	public bool fromLeft = false;
	/// <summary>
	/// Bool for shooting: is it happening or not.
	/// </summary>
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
	/// <summary>
	/// Raises the trigger enter 2d event.
	/// Use: if player enters the area a box starts shooting.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			shoot = true;
		}
	}
	/// <summary>
	/// Raises the trigger exit 2d event.
	/// Use: if player is not in the area the box doesn't/stops shooting
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			shoot = false;
		}
	}
}