using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleObject : MonoBehaviour {

	//public List<GameObject> targets = new List<GameObject>();
	public List<GameObject> targets = new List<GameObject>();
	public string onMessage;
	public string offMessage;
	private bool turnedOn;
	private Animator myAni;

	void Start()
	{
		myAni = GetComponent<Animator> ();
	}
	void TurnOn()
	{
		if (!turnedOn)
			SetState (true);	
	}

	void TurnOff()
	{
		if (turnedOn)
			SetState (false);
	}

	protected void Toggle()
	{
		if (turnedOn)
			TurnOff ();
		else 
			TurnOn ();
	}

	void SetState(bool on)
	{
		turnedOn = on;	
		myAni.SetBool("isOn",on);
		Debug.Log ("switch state" + on);
		if (!on) {
			if (targets.Count > 0 && !string.IsNullOrEmpty (onMessage)) {
				Debug.Log ("onMessage sent");
				//targets.ForEach (n => n.SendMessage (onMessage));
				foreach (GameObject n in targets) n.gameObject.SendMessage (onMessage);
			} 		
		} else if (on) {
			if (targets.Count > 0 && !string.IsNullOrEmpty (offMessage)) {
				Debug.Log ("offMessage sent");
				//targets.ForEach (n => n.SendMessage (offMessage));
				foreach (GameObject n in targets) n.gameObject.SendMessage (offMessage);
			}
		}
	}
}
