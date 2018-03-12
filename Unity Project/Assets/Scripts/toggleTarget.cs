using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleTarget : MonoBehaviour {
	/// <summary>
	/// State of the toggleTarget. 
	/// Initialized as false (close)
	/// </summary>
	private bool isOpen = false;
	/// <summary>
	/// Set toggleTarget state to "On"
	/// </summary>
	public void Open(){
		if (!isOpen) 
			SetState (true);
	}
	/// <summary>
	/// Set toggleTarget state to "Off"
	/// </summary>
	public void Close(){
		if (isOpen) 
			SetState (false);
	}
	/// <summary>
	/// Method for the children of this class to change state of the toggleTarget
	/// </summary>
	protected void Toggle()
	{
		if (isOpen)
			Close ();
		else
			Open ();
	}
	/// <summary>
	/// Set the state of the toggleTarget to "true" or "false"
	/// Children of this class can have different behaviour in either state
	/// </summary>
	/// <param name="open">If set to <c>true</c> open.</param>
	public virtual void SetState(bool open)
	{
		isOpen = open;
	}
}


