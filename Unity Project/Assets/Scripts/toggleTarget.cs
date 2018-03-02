using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleTarget : MonoBehaviour {

	private bool isOpen;

	// Use this for initialization


	public void Open(){
		if (!isOpen) 
			SetState (true);
	}

	public void Close(){
		if (isOpen) 
			SetState (false);
	}

	public void Toggle()
	{
		if (isOpen)
			Close ();
		else
			Open ();
	}

	public virtual void SetState(bool open)
	{
		isOpen = open;
	}
}


