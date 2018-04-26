using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : Node 
{ 
	private GameObject Player;
	private float speed;
	public Rigidbody rb;
	public override void Execute()
	{
		currentState = Results.READY;
		speed = 5f;
		Player = GameObject.FindGameObjectWithTag ("Player");
			if (Vector3.Distance (BT.transform.position, Player.transform.position) < 45) 
			{
			currentState = Results.SUCCESS;
			BT.transform.LookAt (new Vector3(Player.transform.position.x, BT.transform.position.y, Player.transform.position.z));
			BT.transform.position += BT.transform.forward * speed * Time.deltaTime;
	        }
			else
			{			
				currentState = Results.FAILED;
			}
        }

	 }

