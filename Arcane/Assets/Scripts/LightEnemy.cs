using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemy : MonoBehaviour
{
    public GameObject playerGameobject;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float triggerRange = 50f;
    public bool isPlayerInRange;
    public int firstReaction;
	public void Start ()
    {
        firstReaction = Random.Range(1, 3);
    }
	
	void Update ()
    {
        transform.LookAt(playerGameobject.transform);
        float distanceToPlayer = Vector3.Distance(transform.position, playerGameobject.transform.position);
        if(distanceToPlayer<=triggerRange && distanceToPlayer>=5f)
        {
            isPlayerInRange = true;
            Act();
        }
	}

    void Act()
    {
        if (isPlayerInRange)
        {
            if (firstReaction == 1)
            {
                Attack();
            }
            else if (firstReaction == 2)
            {
                Flee();
            }
        }
    }      

    void Idle()
    {

    }

    void Attack()
    {
        transform.position -= Vector3.forward;
    }

    void Flee()
    {
        transform.position += Vector3.forward;
    }
}
