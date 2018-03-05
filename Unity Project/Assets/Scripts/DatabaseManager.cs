using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;

public class DatabaseManager : MonoBehaviour {

//the sorting of the scores low vs. high has been changed in HighScore.cs : the lower the better
//now the lowest score is on top, so lowest score in this .cs means worst

	//connection screen for opening the DB
	private string connectString;
	//adding scores to a list
	private List<HighScore> highScores = new List<HighScore> ();
	//showing score
	public GameObject scorePrefab;
	public Transform scoreParent;
	public int topScores;
	public int saveScores;
	public InputField enterName;
	public GameObject nameDialog;
	//getting the score from player health
	private static int score;

	void Start () {
		//finding the databse in unity
		connectString = "URI=file:" + Application.dataPath + "/HighScoreDatabase.sqlite";

		CreateTable ();

		DelExtraScores ();
		//GetScore ();
		ShowScore();
	}
	
	void Update () {
		//when escape is pressed it will show/hide it
		if (Input.GetKeyDown (KeyCode.Escape)) {
			nameDialog.SetActive(!nameDialog.activeSelf);
		}
		//get player score data
		score = playerHealth.playerScore;
	}

//FOR THE DB TO WORK WHEN BUILDING
	private void CreateTable() {
		using (IDbConnection dbConnection = new SqliteConnection (connectString)) {

			dbConnection.Open ();
			//making a DB command: CREATE TABLE
			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {
				//create the DB table if it doesn't exist
				string sqlQuery = String.Format ("CREATE TABLE if not exists HighScores (DI INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, Name TEXT NOT NULL, Score INTEGER NOT NULL, Date DATETIME NOT NULL DEFAULT CURRENT_DATE)");
				dbCmd.CommandText = sqlQuery;
				dbCmd.ExecuteScalar ();
				dbConnection.Close ();
			}
		}
	}
		
//ENTER NAME
	public void EnterName() {
		//don't save empty name
		if (enterName.text != string.Empty) {
			//THIS IS INPUTTING RANDOM NUMBERS
			//has to be changed to what our player earns as a score!
			//int score = UnityEngine.Random.Range (1, 100);
			InsertScore (enterName.text, score);
			//after entering name the text box becomes empty again
			enterName.text = string.Empty;
			ShowScore ();
		}
	}


//INSERT SCORE
	private void InsertScore(string name, int newScore){
		GetScore ();
		int count = highScores.Count;

		//if a new score is better than the worst that is saved and taken to account in the top
		//then the worst ones needs to be deleted
		if (highScores.Count > 0) {
			HighScore lowestScore = highScores [highScores.Count - 1];
			if (lowestScore != null && saveScores > 0 && highScores.Count >= saveScores && newScore > lowestScore.Score) {
				DeleteScore (lowestScore.ID);
				count--;
			}
		}
		if (count < saveScores) {

			using (IDbConnection dbConnection = new SqliteConnection (connectString)) {

				dbConnection.Open ();
				//making a DB command: INSERT
				using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {

					string sqlQuery = String.Format ("INSERT INTO HighScores(Name,Score) VALUES(\"{0}\",\"{1}\")", name, newScore);
					dbCmd.CommandText = sqlQuery;
					dbCmd.ExecuteScalar ();
					dbConnection.Close ();
				}
			}
		}
	}

//GET SCORE
	private void GetScore() {
		//clearing the list
		highScores.Clear ();

		using (IDbConnection dbConnection = new SqliteConnection (connectString)) {

			dbConnection.Open ();
			//making a DB command: SELECT
			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {

				string sqlQuery = "SELECT * FROM HIghScores";
				dbCmd.CommandText = sqlQuery;
				//reading the DB
				using (IDataReader reader = dbCmd.ExecuteReader ()) {
					while (reader.Read ()) {
						//making the score
						highScores.Add(new HighScore(reader.GetInt32(0), reader.GetInt32(2), reader.GetString(1), reader.GetDateTime(3)));
					}
					dbConnection.Close ();
					reader.Close ();
				}
			}
		}
//SORTING THE SCORES
		highScores.Sort();
	}

//DELETE SCORE
	private void DeleteScore(int id) {
		using (IDbConnection dbConnection = new SqliteConnection (connectString)) {

			dbConnection.Open ();
			//making a DB command: INSERT
			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {

				string sqlQuery = String.Format("DELETE FROM HighScores WHERE ID = \"{0}\"", id);
				dbCmd.CommandText = sqlQuery;
				dbCmd.ExecuteScalar ();
				dbConnection.Close();
			}
		}
	}
//SHOWING SCORE
	private void ShowScore() {
		GetScore ();
		//array of scores so it will be new again
		foreach (GameObject score in GameObject.FindGameObjectsWithTag("Score")) {
			Destroy (score);
		}

		//ordering
		for (int i = 0; i < topScores; i++) {
			if (i <= highScores.Count - 1) {
				//instantiating
				GameObject tempObject = Instantiate (scorePrefab);
				//making new highscore and putting it in the list
				HighScore tempScore = highScores [i];
				//run through the scores
				tempObject.GetComponent<HighScoreScript> ().SetScore (tempScore.Name, tempScore.Score.ToString (), "#" + (i + 1).ToString ());
				//showing it in the right place (as a child of the Score in the Unity HighScoreMenu)
				tempObject.transform.SetParent (scoreParent);
				//aligning it with the text box
				tempObject.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
			}
		}
	}

//LIMITING HOW MANY SCORES ARE STORED
	private void DelExtraScores() {
		GetScore ();
		if (saveScores <= highScores.Count) {
			//how many to delete
			int deleteCount = highScores.Count - saveScores;
			//delete only the worst ranking ones
			highScores.Reverse();
			//DELETION
			using (IDbConnection dbConnection = new SqliteConnection (connectString)) {

				dbConnection.Open ();
				//making a DB command: INSERT
				using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {
					for (int i = 0; i < deleteCount; i++) {

						string sqlQuery = String.Format ("DELETE FROM HighScores WHERE ID = \"{0}\"", highScores[i].ID);
						dbCmd.CommandText = sqlQuery;
						dbCmd.ExecuteScalar ();
					}
					dbConnection.Close ();
				}
			}
		}
	}
//ACCESS AT END OF GAME
	//what happens when touched - scores screen
/*	void OnTriggerEnter2D(Collider2D collision){
		if (collision.CompareTag ("Player")) {
			SceneManager.LoadScene ("HighScores");
		}
	}*/
}