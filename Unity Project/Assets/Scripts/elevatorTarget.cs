using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorTarget : toggleTarget {

	/// <summary>
	/// The state of the elevator: 
	/// Open = Called = move
	/// Close = Halted = not move 
	/// ==> Open message = called (in movingPlatform)
	/// ==> Close message = !called (in movingPlatform)
	/// </summary>

	public override void SetState(bool called) {
		base.SetState (called);
		movingPlatform.called = !called;
	}
}
