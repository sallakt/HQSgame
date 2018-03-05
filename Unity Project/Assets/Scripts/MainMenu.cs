using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //Main menu "play" button
    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }
    //Main menu "quit" button
    public void Quit()
    {
        //to let us know it works (written in the console in Unity)
        Debug.Log("GAME HAS BEEN QUIT");
        Application.Quit();
    }
	//GameOverMenu button to going back to main menu
	public void ToMenu()
	{
		SceneManager.LoadScene("Menu");
	}

	//Highscore "menu"
	public void ToScores() {
		SceneManager.LoadScene("HighScores");
	}

	//getting the score from player health
	private static int score;
	//in highscore menu restart button also restarts count
	public void Restart() {
		SceneManager.LoadScene("Level1");
		//setting score back to 0
		score = 0;
	}
}