using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HighScore : IComparable<HighScore> {
	//getting or setting highscores and storing it
	public int ID { get; set;}
	public int Score { get; set;}
	public string Name { get; set;}
	public DateTime Date { get; set;}

	/// <summary>
	/// Initializes a new instance of the <see cref="HighScore"/> class.
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="score">Score.</param>
	/// <param name="name">Name.</param>
	/// <param name="date">Date.</param>
	public HighScore (int id, int score, string name, DateTime date) {
		this.ID = id;
		this.Score = score;
		this.Name = name;
		this.Date = date;
	}
	/// <summary>
	/// Compares the current object with another object of the same type.
	/// Orders by score (low to high), if same score orders by date.
	/// </summary>
	/// <returns>The to.</returns>
	/// <param name="other">Other.</param>
	public int CompareTo(HighScore other) {
		if (other.Score < this.Score) {
			return 1;
		}
		if (other.Score > this.Score) {
			return -1;
		} else if (other.Date < this.Date) {
			return -1;
		} else if (other.Date > this.Date) {
			return 1;
		}
		return 0;
	}
}