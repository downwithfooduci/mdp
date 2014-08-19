using UnityEngine;
using System.Collections;

// script that handles drawing the tongue layer on the gui
public class TongueLayer : MonoBehaviour 
{
	public Texture tongue;			// to hold the tongue texture

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	void OnGUI()
	{
		GUI.depth++;				// change the GUI depth for proper layering of gui elements

		// draw the texture the same size as the screen
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), tongue);
	}
}
