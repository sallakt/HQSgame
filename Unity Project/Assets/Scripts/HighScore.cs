using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HighScore : IComparable<HighScore> {
	//making highscores and storing it
	public int ID { get; set;}
	public int Score { get; set;}
	public string Name { get; set;}
	public DateTime Date { get; set;}

	//create
	public HighScore (int id, int score, string name, DateTime date) {
		this.ID = id;
		this.Score = score;
		this.Name = name;
		this.Date = date;
	}
	//sorting the score: order by score (low to high numbers), if same score order by date
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