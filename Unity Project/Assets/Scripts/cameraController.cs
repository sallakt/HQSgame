using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraController : MonoBehaviour {

	public Camera[] cameras;
	public Camera currentCamera;
	public static int count; 

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
			if (cameraController.count == cameras.Length - 1) {
				cameraController.count = 0;
			} else {
				cameraController.count++;
			}
			currentCamera = cameras [count];
			for (int i = 0; i < cameras.Length; i++) {
				if (i != count) {
					cameras [i].gameObject.SetActive (false);
				}
			}
			currentCamera.gameObject.SetActive (true);
			if (count == 0) {
				Time.timeScale = 1;
			} else {
				Time.timeScale = 0;
			}
		}	
	}
}
