using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek_steer : MonoBehaviour {
	Vector3 velocity;
	float speed;
	public GameObject target;
	Vector3 steering;
	float maxSpeed;
	Vector3 desiredVelocity;
	float maxAcc;
	float mass;
	// Use this for initialization
	void Start () {
		maxSpeed = 5;
		maxAcc = 5;
		mass = 4;

	}

	// Update is called once per frame
	void Update () {
		desiredVelocity = Vector3.Normalize (target.transform.position - transform.position) * maxSpeed;
		steering = desiredVelocity - velocity;
		steering = Vector3.ClampMagnitude (steering, maxAcc);
		velocity = velocity + steering * Time.deltaTime;
		velocity = Vector3.ClampMagnitude (velocity + steering, maxSpeed);
		transform.position = transform.position + velocity * Time.deltaTime;
	}
}
