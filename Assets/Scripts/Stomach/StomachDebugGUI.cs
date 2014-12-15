using UnityEngine;
using System.Collections;

public class StomachDebugGUI : MonoBehaviour 
{
	public Canvas ui;

	// Use this for initialization
	void Start () 
	{
		ui.enabled = false;
	}

	public void enable()
	{
		Time.timeScale = 0f;
		ui.enabled = true;
	}
}
