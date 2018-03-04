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
}