using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisableMainGUI : MonoBehaviour 
{
	public Canvas c;
	public UnityEngine.UI.Button debug;

	public void disable()
	{
		c.enabled = false;
		debug.enabled = false;
	}

	public void enable()
	{
		c.enabled = true;
		debug.enabled = true;
	}
}
