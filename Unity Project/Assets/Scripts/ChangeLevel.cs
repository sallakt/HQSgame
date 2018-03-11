using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{

    public string nextLevel;

	/// <summary>
	/// Raises the trigger enter 2d event.
	/// Use: when player touches the flag object the next level will be loaded.
	/// (What the next level is can be changed for each level in Unity.)
	/// </summary>
	/// <param name="collision">Collision.</param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}