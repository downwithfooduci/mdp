using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StomachReturnButton : MonoBehaviour 
{
	public Canvas ui;
	public Canvas main;

	void Start()
	{
		ui.enabled = false;
	}

	public void setEnable()
	{
		Time.timeScale = 0f;
		ui.enabled = true;
		main.enabled = false;
	}

	public void returnToMain()
	{
		Application.LoadLevel ("MainMenu");
	}

	public void cancel()
	{
		Time.timeScale = 1f;
		ui.enabled = false;
		main.enabled = true;
	}
}
