using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraController : MonoBehaviour {
	/// <summary>
	/// The cameras is an array of camera that are available to the user
	/// </summary>
	public Camera[] cameras;
	/// <summary>
	/// The current camera: the only camera that is active at any given time
	/// </summary>
	public Camera currentCamera;
	/// <summary>
	/// Variable used to cycle through each camera in the cameras array
	/// </summary>
	public static int count; 

	/// <summary>
	/// Set all camera to inactive and the main camera to active at the begining of any scene
	/// </summary>
	void Start () {
		currentCamera = cameras[count]; 
		for (int i = 0; i < cameras.Length; i++) {
			cameras [i].gameObject.SetActive (false);
		}
		currentCamera.gameObject.SetActive (true);
	}

	/// <summary>
	/// Check for the Key "C". Once the key is pressed, the next camera in the array will be the active camera
	/// The array in this case only has 2 cameras. The 2nd camera (the "overview camera") once become active
	/// will also temporary stop all actions in the game
	/// </summary>
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
