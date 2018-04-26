using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_tornado : MonoBehaviour
{

	public Transform[] Nodes;
	int curTargetIndex;
	float pointDistance = 2f; 
	float MovementSpeed = 8.0f;
	void Update()
	{
		

		// move to the target node
		transform.position += transform.forward * MovementSpeed * Time.deltaTime;
		// looks at target
		transform.LookAt (new Vector3(Nodes [curTargetIndex].transform.position.x,transform.position.y,Nodes [curTargetIndex].transform.position.z));
		//Go to next target once reached current target
		if (Vector3.Distance (transform.position, Nodes [curTargetIndex].transform.position) <= pointDistance) 
		{
			curTargetIndex++;
			if (curTargetIndex >= Nodes.Length) 
			{
				curTargetIndex = 0;
			}



		}
	}

	}
