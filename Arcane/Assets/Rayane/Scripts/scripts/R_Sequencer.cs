using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Sequencer : Node {

	//Checkes all its children
	//If all its children have succeeded... the sequencer returns success
	public override void Execute()
	{
		for(int i =0; i<leaves.Count;i++)
		{
			leaves[i].Execute();

		if(leaves[i].currentState == Results.FAILED)
		{
				currentState = Results.FAILED;
				return;
		}
			if(leaves[i].currentState == Results.RUNNING)
			{
				currentState = Results.RUNNING;
				return;
			}
       }
		currentState = Results.SUCCESS;

	
	}
}
