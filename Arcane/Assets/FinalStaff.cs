using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalStaff : MonoBehaviour 
{
	public GameObject youWinPanel;
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Projectile") 
		{
			youWinPanel.SetActive (true);
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
	void Start () 
	{
		
	}
	void Update () 
	{
		
	}
}
