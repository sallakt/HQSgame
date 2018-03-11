using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	//disabling and enabling the menu:
	/// <summary>
	/// The pause menu UI gameobject in Unity.
	/// </summary>
	public GameObject PauseUI;
	/// <summary>
	/// Bool to see if the pause menu should be visible and game paused, or not.
	/// </summary>
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
	/// <summary>
	/// Resuming game: not paused anymore.
	/// </summary>
	public void Resume(){
		paused = false;
	}
	/// <summary>
	/// Restarting level: loading same level again.
	/// </summary>
	public void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
	/// <summary>
	/// Going back to MainMenu.
	/// Loading main menu, changing time back and changing score back to 1.
	/// </summary>
	public void MainMenu(){
		SceneManager.LoadScene("Menu");
		Time.timeScale = 1;
		playerHealth.playerScore = 1;
	}
	/// <summary>
	/// Quits application.
	/// also gives a Debug message to know it works.
	/// </summary>
	public void Quit(){
		Debug.Log ("GAME HAS BEEN QUIT");
		Application.Quit ();
	}
}