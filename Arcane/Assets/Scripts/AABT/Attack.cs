using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : CNode
{
	float attackRate = 0.5f;
	float nextTimeToFire = 0f;
	public override void Execute()
	{
        ownerBT.transform.LookAt(new Vector3(ownerBT.player.transform.position.x, ownerBT.transform.position.y, ownerBT.player.transform.position.z));
        //Debug.Log (Player.playerHealth);
		//Debug.Log(ownerBT.enemyHealth);
		if (ownerBT.enemyHealth <= 0) 
		{            
			result = state.failure;
		}
		else if (Player.playerHealth > 0) 
		{            
			AttackPlayer (ownerBT.enemyDamage);
			result = state.running;
		}
		else if (Player.playerHealth <= 0) 
		{
			result = state.success;
		}
	}
	void AttackPlayer(float damage)
	{
		if (Time.time >= nextTimeToFire) 
		{
			ownerBT.animator.SetTrigger("Attack");
			ownerBT.Invoke ("DamagePlayer", 1);
			nextTimeToFire = Time.time + 1f / attackRate;
		}
	}
}
