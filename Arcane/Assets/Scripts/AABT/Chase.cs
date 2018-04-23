using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : CNode
{
    float distanceToPlayer;
    public override void Execute()
    {
        distanceToPlayer = Vector3.Distance(ownerBT.player.transform.position, ownerBT.transform.position);
		//Debug.Log (distanceToPlayer);
		if(distanceToPlayer <= ownerBT.chaseRange && distanceToPlayer >= ownerBT.attackRange)
        {
            ownerBT.animator.SetTrigger("Walk");
            ownerBT.transform.LookAt(new Vector3(ownerBT.player.transform.position.x,ownerBT.transform.position.y,ownerBT.player.transform.position.z)); 
			ownerBT.enemyRb.AddForce (ownerBT.transform.forward * ownerBT.standardSpeed);
			ownerBT.enemyRb.velocity = Vector3.ClampMagnitude (ownerBT.enemyRb.velocity, ownerBT.maxSpeed);
            result = state.running;
        }
		else if (distanceToPlayer <= ownerBT.attackRange) 
		{	
			result = state.success;
		}
        else
        {
            result = state.failure;
        }
    }
}
