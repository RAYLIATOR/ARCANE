using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Selector : Node {

	//Checks every children in order
	//If one is success... the Selctor is success
	public override void Execute()
	{
		for (int i = 0; i < leaves.Count; i++) {
			leaves [i].Execute ();

			if (leaves [i].currentState == Results.SUCCESS) {
				currentState = Results.SUCCESS;
				return;
			}

			if (leaves [i].currentState == Results.RUNNING) {
				currentState = Results.RUNNING;
				return;
			}
		}
		currentState = Results.FAILED;
	}
}
