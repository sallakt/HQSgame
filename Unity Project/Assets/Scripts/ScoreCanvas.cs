using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCanvas : MonoBehaviour {

	//finding game object from unity
	public Text ScoreText;


	// Use this for initialization
	void Start () {
		//finding UI component in Unity
		ScoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		ScoreText.text = "Attempts: " + playerHealth.playerScore.ToString ();
	}

	// Update is called once per frame
	void Update () {
	}
}