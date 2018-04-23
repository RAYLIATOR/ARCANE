using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }
    void Start ()
    {
	}
	void Update ()
    {
        transform.position += transform.forward*1f;
	}
}
