using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
	public Button pauseButton;

	void Start()
	{
		Button btn = pauseButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		if (Time.timeScale != 0) 
		{
			Time.timeScale = 0;
			Debug.Log ("Paused");
		} 
		else 
		{
			Time.timeScale = 1;	
			Debug.Log ("Resumed");
		}
	}
}