using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour {

	public GameObject platform;

	public float moveSpeed;
	public int count;

	public Transform currentTarget;
	public Transform [] targets;

	// Use this for initialization
	void Start () {
		currentTarget = targets [count];	
	}
	
	// Update is called once per frame
	void Update () {
		platform.transform.position = 
			Vector3.MoveTowards (platform.transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
		if (platform.transform.position == currentTarget.position) {
			if (count == targets.Length -1) {
				count = 0;
			} else
				count++;
			currentTarget = targets [count];
		}
	}
}
