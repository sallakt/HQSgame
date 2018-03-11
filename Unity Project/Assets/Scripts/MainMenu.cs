using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	/// <summary>
	/// Play game.
	/// Loads first scene and changes players score back to 1.
	/// </summary>
    public void Play() {
        SceneManager.LoadScene("Level1");
		playerHealth.playerScore = 1;
    }
    //Main menu "quit" button
	/// <summary>
	/// Quits application.
	/// also gives a Debug message to know it works.
	/// </summary>
    public void Quit() {
        Debug.Log("GAME HAS BEEN QUIT");
        Application.Quit();
    }
	/// <summary>
	/// Going back to MainMenu (from GameOverMenu).
	/// </summary>
	public void ToMenu() {
		SceneManager.LoadScene("Menu");
	}
	/// <summary>
	/// Going to HighScores (database view).
	/// </summary>
	public void ToScores() {
		SceneManager.LoadScene("HighScores");
	}

	/// <summary>
	/// Restarting game (from highscore menu).
	/// Loads level1 and sets player score back to 1.
	/// </summary>
	public void Restart() {
		SceneManager.LoadScene("Level1");
		//setting score back to 1
		playerHealth.playerScore = 1;
	}
	/// <summary>
	/// Start game again (from GameOver menu).
	/// Loads level1 but doesn't set player score back!
	/// </summary>
	public void StartAgain() {
		SceneManager.LoadScene("Level1");
	}
}