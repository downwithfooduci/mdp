using UnityEngine;
using System.Collections;

public class StomachDebugGUI : MonoBehaviour 
{
	public Canvas ui;

	// Use this for initialization
	void Start () 
	{
		ui = GetComponent<Canvas> ();
		ui.enabled = false;
	}

	public void enable()
	{
		ui.enabled = true;
	}
}
