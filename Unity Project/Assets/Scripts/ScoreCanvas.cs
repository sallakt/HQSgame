using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCanvas : MonoBehaviour {

	/// <summary>
	/// The score text object in Unity.
	/// </summary>
	public Text ScoreText;

	void Start () {
		//finding UI component in Unity
		ScoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		ScoreText.text = "Attempts: " + playerHealth.playerScore.ToString ();
	}

	void Update () {
	}
}