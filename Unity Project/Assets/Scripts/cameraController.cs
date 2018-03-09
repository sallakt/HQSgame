using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraController : MonoBehaviour {

	public Camera[] cameras;
	public Camera currentCamera;
	public int count; 

	// Use this for initialization
	void Start () {
		currentCamera = cameras[count]; 
		for (int i = 0; i < cameras.Length; i++) {
			cameras [i].gameObject.SetActive (false);
		}
		currentCamera.gameObject.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) {
			if (count == cameras.Length - 1) {
				count = 0;
			} else
				count++;
			currentCamera.gameObject.SetActive (false);
			currentCamera = cameras [count];
			currentCamera.gameObject.SetActive (true);
		}	
		if (count != 0) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}
}
