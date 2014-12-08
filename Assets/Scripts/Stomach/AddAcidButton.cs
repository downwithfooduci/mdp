using UnityEngine;
using System.Collections;

// script that handles the behavior and drawing of the acid button in the stomach game
public class AddAcidButton : MonoBehaviour 
{
	public GUIStyle acidButton;				// holds the style for the acid button textures
	private Rect acidButtonRect;			// the rectangle defining the relative position to draw the acid button

	private PhBar phbar;						// to hold a reference to the ph bar

	// Use this for initialization
	void Start () 
	{
		// find the phbar
		phbar = FindObjectOfType(typeof(PhBar)) as PhBar;

		// set the dimensions of the acid button rect relative to screen size
		acidButtonRect = new Rect (91f / 1024f * Screen.width, 11f / 768f * Screen.height,
		                          184f / 1024f * Screen.width, 133f / 768f * Screen.height);
	}
	
	// Update is called once per frame
	void Update () {}

	void OnGUI()
	{
		GUI.depth = GUI.depth - 5;

		// draw the acid button
		if (GUI.RepeatButton (acidButtonRect, "", acidButton))
		{
			phbar.addAcid();		// when the button is pressed call the addAcid function from phBar script
		}
	}
}
