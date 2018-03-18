using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animation EnemyAnimation;
    public AnimationClip idleClip;
    public AnimationClip idleAggressiveClip;
    public AnimationClip walkClip;
    public AnimationClip runClip;
    public AnimationClip attackClip;
    public AnimationClip dieClip;
    float triggerRange = 30f;
    float enemySpeed = 10f;
    public float distanceToPlayer;
    GameObject Player;
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Idle();
	}
	void Update ()
    {
        distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
	}
    void Idle()
    {
        EnemyAnimation.clip = idleClip;
        if(distanceToPlayer<=triggerRange)
        {
            Chase();
        }
    }
    void Chase()
    {
        if (distanceToPlayer <= 15f)
        {
            EnemyAnimation.clip = runClip;
        }
        else
        {
            EnemyAnimation.clip = walkClip;
        }
    }
    void Attack()
    {
        EnemyAnimation.clip = attackClip;
    } 
      
}
