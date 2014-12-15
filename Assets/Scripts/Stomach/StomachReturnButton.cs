using UnityEngine;
using System.Collections;

public class StomachReturnButton : MonoBehaviour 
{
	public Canvas ui;

	void Start()
	{
		ui.enabled = false;
	}

	public void setEnable()
	{
		Time.timeScale = 0f;
		ui.enabled = true;
	}

	public void returnToMain()
	{
		Application.LoadLevel ("MainMenu");
	}

	public void cancel()
	{
		Time.timeScale = 1f;
		ui.enabled = false;
	}
}
