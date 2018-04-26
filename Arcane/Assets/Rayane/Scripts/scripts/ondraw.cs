using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ondraw : MonoBehaviour {
	
	public float lookPerimeter = 5f;

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookPerimeter);
	}
}
