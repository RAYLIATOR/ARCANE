using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{	
	public GameObject helpPanel;
	public GameObject hudPanel;
	public GameObject pauseMenuPanel;
	void Start ()
	{
		
	}
	void Update () 
	{
		Pause ();
	}
	void Pause()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
			{
				hudPanel.SetActive(false);
				pauseMenuPanel.SetActive(true);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				Time.timeScale = 0f;
				Player.shoot = false;
			}
	}
	public void Resume()
	{
		pauseMenuPanel.SetActive(false);
		hudPanel.SetActive(true);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		Time.timeScale = 1f;
		Player.shoot = true;
	}
	public void ExitToMain()
	{
		SceneManager.LoadScene (0);
		Time.timeScale = 1f;
	}
	public void Help()
	{
		pauseMenuPanel.SetActive (false);
		helpPanel.SetActive (true);
	}
	public void returnToPauseMenu()
	{
		helpPanel.SetActive (false);
		pauseMenuPanel.SetActive (true);
	}
}
