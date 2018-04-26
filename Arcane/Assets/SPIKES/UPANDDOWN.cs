using UnityEngine;
using System.Collections;

public class UPANDDOWN : MonoBehaviour 
{

	private int maxSpeed = 2;
	private Vector3 startPos;

	// Use this for initialization
	void Start () 
	{
		

		startPos = transform.position;
	}

	// Update is called once per frame
	void Update ()
	{
		MoveVertical ();
	}

	void MoveVertical()
	{
		transform.position = new Vector3(transform.position.x, startPos.y + Mathf.Sin(Time.time * maxSpeed), transform.position.z);

		if(transform.position.y > 8.0f)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		}
		else if(transform.position.y < -10f)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		}
	}
}