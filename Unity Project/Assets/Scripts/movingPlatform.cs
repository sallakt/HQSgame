using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour {

	/// <summary>
	/// The platform is the gameObject that is moving
	/// </summary>
	public GameObject platform;
	/// <summary>
	/// The Speed at which the platform moves
	/// </summary>
	public float moveSpeed;
	/// <summary>
	/// A variable to cycle through each elements of the "targets" array
	/// </summary>
	public int count;

	/// <summary>
	/// The nearest target that the object is moving towards
	/// </summary>
	public Transform currentTarget;

	/// <summary>
	/// An array that contains all of the destination of the gameObject in order
	/// </summary>
	public Transform [] targets;

	/// <summary>
	/// Check to see if the platform is called or not (elevator interaction)
	/// </summary>
	public static bool called;

	/// <summary>
	/// Set the first destination in the targets array to be the current destination
	/// Set the state of the gameObject to not moving (not being called)
	/// </summary>
	void Start () {
		currentTarget = targets [count];	
		called = false;
	}

	/// <summary>
	/// If the gameObject gets called, it will start moving from one destination to the other
	/// If the last element in the targets array has been reach, the gameObject will move back to the origin (targets[0])
	/// </summary>
	void Update () {
		if (called) {
			platform.transform.position = 
				Vector3.MoveTowards (platform.transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
			if (platform.transform.position == currentTarget.position) {
				if (count == targets.Length - 1) {
					count = 0;
				} else
					count++;
				currentTarget = targets [count];
			}
		}
	}
}
