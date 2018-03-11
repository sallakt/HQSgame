using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour {

	/// <summary>
	/// The platform.
	/// </summary>
	public GameObject platform;

	public float moveSpeed;
	public int count;

	public Transform currentTarget;
	public Transform [] targets;

	public static bool called;

	// Use this for initialization
	void Start () {
		currentTarget = targets [count];	
		called = false;
	}
	
	// Update is called once per frame
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
