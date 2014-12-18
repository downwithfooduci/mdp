using UnityEngine;
using System.Collections;

public class StomachDebugGUI : MonoBehaviour 
{
	public Canvas ui;
	public RectTransform r;

	// Use this for initialization
	void Start () 
	{
		ui.enabled = false;


	}

	public void enable()
	{
		Time.timeScale = 0f;
		ui.enabled = true;
		r.anchoredPosition = new Vector2 (1023f/2f, 768f/2f);
		r.localScale = new Vector3 (1f, 1f, 1f);
	}
}
