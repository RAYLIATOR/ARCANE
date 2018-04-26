using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior_tree : MonoBehaviour {

	Node root;
	public Transform[] Nodes;
	public float speed;

	void Start()
	{
		
		//Behavior tree structure
		root = new R_Selector ();
		root.leaves.Add (new R_Selector ()); //CHANGE TO SEQUENCER LATER
		root.leaves.Add (new Patrol ());
		root.leaves [0].leaves.Add (new Seek ());
		root.leaves [0].leaves.Add (new R_Attack ());	



		root.BT = this;
		root.Initialization (); //calling the funtion in node class
	}

	void Update()
	{
		
		root.Execute ();
		if(Input.GetKeyDown(KeyCode.K))
	     {
		     root.debugLeaves ();
	     }
	}

}
