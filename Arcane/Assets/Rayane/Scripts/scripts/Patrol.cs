using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Node 
{
	int curTargetIndex;
	float pointDistance = 2f; 
	float MovementSpeed = 3.0f;
	public override void Execute()
	{
        // default state is success
		currentState = Results.SUCCESS;

		// move to the target node
		BT.transform.position += BT.transform.forward * MovementSpeed * Time.deltaTime;
		// looks at target
		BT.transform.LookAt (new Vector3(BT.Nodes [curTargetIndex].transform.position.x,BT.transform.position.y,BT.Nodes [curTargetIndex].transform.position.z));
		//Go to next target once reached current target
		if (Vector3.Distance (BT.transform.position, BT.Nodes [curTargetIndex].transform.position) <= pointDistance) 
		{
			curTargetIndex++;
			if (curTargetIndex >= BT.Nodes.Length) 
			{
				curTargetIndex = 0;
			}

				
				
			}
	}

}

