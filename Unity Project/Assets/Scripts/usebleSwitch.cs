using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usebleSwitch : toggleObject {
	/// <summary>
	/// Toggle the toggleObject state 
	/// Uses different name so that the message sent from the player does not interfere with unwanted objects from other classes
	/// </summary>
	public void Use ()
	{
		Toggle();
	}
}
