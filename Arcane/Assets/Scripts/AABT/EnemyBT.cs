using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBT : MonoBehaviour
{
    public Animator animator;
	public Rigidbody enemyRb;
    public GameObject player;
	public float standardSpeed ;
	public float maxSpeed ;
    public float chaseRange ;
    public float attackRange;
    public float enemyDamage ;
    public float enemyHealth;
    CNode root;
	void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "Projectile") 
		{
			TakeDamage (Player.playerDamage);
		}
	}
	void Start ()
    {
        //animator = GetComponent<Animator>();
		enemyDamage = 10f;
		enemyRb = GetComponent<Rigidbody> ();
        root = new Selector();
        root.children.Add(new Sequencer());
        root.children.Add(new Idle());
        root.children[0].children.Add(new Chase());
        root.children[0].children.Add(new Attack());
        root.assignOwner(this);
        root.ownerBT = this;
        //root.Initialization();
    }
	void Update ()
    {
		print (enemyHealth);
		root.Execute();
		if (enemyHealth <= 0) 
		{
			Die ();
		}
	}
	void TakeDamage(float damage)
	{
		enemyHealth -= damage;
	}
	public void Die()
	{
		enemyRb.velocity = Vector3.zero;
		animator.SetTrigger("Die");
		Destroy (gameObject, 3f);
	}
    
}
