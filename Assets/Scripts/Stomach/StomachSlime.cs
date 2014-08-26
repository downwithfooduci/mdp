using UnityEngine;
using System.Collections;

// script that handles drawing the slime pool in the stomach game
public class StomachSlime : MonoBehaviour 
{
	public Texture slime;				// to hold the texture of the slime

	private Rect slimeRect;				// to hold the rectangle definining the dimensions of where to draw the slime

	// Use this for initialization
	void Start () 
	{
		// create the rectangle defining where to draw the slime pool relative to screen size
		slimeRect = new Rect (599f / 1024f * Screen.width, 527f / 768f * Screen.height,
		                      349f / 1024f * Screen.width, 196f / 768f * Screen.height);
	}
	
	// Update is called once per frame
	void Update () {}

	void OnGUI()
	{
		// draw the slime pool
		GUI.DrawTexture (slimeRect, slime);
	}
}
