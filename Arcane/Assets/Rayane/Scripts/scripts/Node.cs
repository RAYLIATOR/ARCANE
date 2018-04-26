using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
	//Node class for behavior tree
	public enum Results {SUCCESS, FAILED, RUNNING, READY};  // Stores the variables for the result and everysingle node wll have one of these results

	public List<Node> leaves = new List<Node> (); //Creating a list of type node called leaves

	public Behavior_tree BT;

	public Results currentState = Results.READY; //Giving a default Result

	public void Initialization() //Initializing everysingle Leaf
	{
		for(int i=0; i<leaves.Count; i++) 
		{
			leaves [i].BT = BT;
			leaves [i].Initialization ();
		}

		if (currentState == Results.FAILED) //to see if
		{
			Debug.Log ("Behavior FAILED");
		}

		if (currentState == Results.READY) //to see if
		{
			Debug.Log ("Behavior READY");
		}

		if (currentState == Results.SUCCESS) //to see if
		{
			Debug.Log ("Behavior SUCCESS");
		}

		if (currentState == Results.RUNNING) //to see if
		{
			Debug.Log ("Behavior RUNNING");
		}	
 }
	public void debugLeaves()
	{    Debug.Log (this.GetType().Name +" : "+ currentState);
		for (int i = 0; i < leaves.Count; i++) 
		{
			leaves [i].debugLeaves();
		}
	}

	public virtual void Execute()
	{
		
	}
}