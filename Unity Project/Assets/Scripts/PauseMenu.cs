using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	//disabling and enabling the menu
	public GameObject PauseUI;

	private bool paused = false;

	//disable the menu when playing
	void Start (){
		PauseUI.SetActive (false);
	}
	void Update(){
		if (Input.GetButtonDown("Pause")) {
			//when the menu appears and dissapears
			paused = !paused;
		}
		if (paused) {
			//now the PauseUI menu will be shown
			PauseUI.SetActive (true);
			//freeze time
			Time.timeScale = 0;
		}
		if (!paused) {
			PauseUI.SetActive (false);
			//back to "normal" time
			Time.timeScale = 1;
		}
	}

	public void Resume(){
		paused = false;
	}
	public void Restart(){
		//load same level again
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		//or in brackets SceneManager.GetActiveScene()
		//or in brackets SceneManager.LoadScene
	}
	public void MainMenu(){
		SceneManager.LoadScene("Menu");
		Time.timeScale = 1;
	}
	public void Quit(){
		//to let us know it works
		Debug.Log ("GAME HAS BEEN QUIT");
		Application.Quit ();
	}
}