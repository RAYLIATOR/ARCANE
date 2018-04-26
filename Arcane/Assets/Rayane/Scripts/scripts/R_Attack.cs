using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Attack : Node {

	private GameObject Player;
	public override void Execute()
	{
		currentState = Results.READY;

		Player = GameObject.FindGameObjectWithTag ("Player");
		if (Vector3.Distance (BT.transform.position, Player.transform.position) < 10) 
		{
			
			currentState = Results.SUCCESS;
			BT.transform.LookAt (Player.transform.position);
		}
		else
		{			
			currentState = Results.FAILED;
		}
	}
		

}
