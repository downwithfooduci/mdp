using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisableMainGUIButtons : MonoBehaviour 
{
	public UnityEngine.UI.Button cell1;
	public UnityEngine.UI.Button cell2;
	public UnityEngine.UI.Button cell3;
	public UnityEngine.UI.Button cell4;
	public UnityEngine.UI.Button cell5;
	public UnityEngine.UI.Button cell6;
	public UnityEngine.UI.Button acid;
	public UnityEngine.UI.Button basic;
	public UnityEngine.UI.Button debug;

	public void disableButtons()
	{
		cell1.enabled = false;
		cell2.enabled = false;
		cell3.enabled = false;
		cell4.enabled = false;
		cell5.enabled = false;
		cell6.enabled = false;
		acid.enabled = false;
		basic.enabled = false;
		debug.enabled = false;
	}

	public void enableButtons()
	{
		cell1.enabled = true;
		cell2.enabled = true;
		cell3.enabled = true;
		cell4.enabled = true;
		cell5.enabled = true;
		cell6.enabled = true;
		acid.enabled = true;
		basic.enabled = true;
		debug.enabled = true;
	}
}
