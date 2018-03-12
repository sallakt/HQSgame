using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleObject : MonoBehaviour {
	/// <summary>
	/// List of targets that the toggle object will send message to
	/// </summary>
	public List<GameObject> targets = new List<GameObject>();
	/// <summary>
	/// The message for the "On" state
	/// </summary>
	public string onMessage;
	/// <summary>
	/// The message for the "Off" state
	/// </summary>
	public string offMessage;
	/// <summary>
	/// Check the toggleObject current state ("true" or "false")
	/// </summary>
	private bool turnedOn;
	/// <summary>
	/// Set the variables to change the color of the button indicating its current state
	/// </summary>
	private Animator myAni;
	/// <summary>
	/// Get all necessary components from the object that has this script attached to
	/// </summary>
	void Start()
	{
		myAni = GetComponent<Animator> ();
	}
	/// <summary>
	/// Set toggleObject state to "On"
	/// </summary>
	void TurnOn()
	{
		if (!turnedOn)
			SetState (true);	
	}
	/// <summary>
	/// Set toggleObject state to "Off"
	/// </summary>
	void TurnOff()
	{
		if (turnedOn)
			SetState (false);
	}
	/// <summary>
	/// Method for the children of this class to change state of the toggleObject
	/// </summary>
	protected void Toggle()
	{
		if (turnedOn)
			TurnOff ();
		else 
			TurnOn ();
	}
	/// <summary>
	/// Send the onMessage/offMessage to the target(s)
	/// </summary>
	/// <param name="on">If set to <c>true</c> on.</param>
	void SetState(bool on)
	{
		turnedOn = on;	
		myAni.SetBool("isOn",on);
		if (!on) {
			if (targets.Count > 0 && !string.IsNullOrEmpty (onMessage)) {
				//targets.ForEach (n => n.SendMessage (onMessage));
				foreach (GameObject n in targets) n.gameObject.SendMessage (onMessage);
			} 		
		} 
		if (on) {
			if (targets.Count > 0 && !string.IsNullOrEmpty (offMessage)) {
				//targets.ForEach (n => n.SendMessage (offMessage));
				foreach (GameObject n in targets) n.gameObject.SendMessage (offMessage);
			}
		}
	}
}
