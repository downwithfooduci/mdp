using UnityEngine;
using System.Collections;

// script for handing the behavvior and drawing of the add base button in the stomach game
public class AddBaseButton : MonoBehaviour 
{
	public GUIStyle baseButton;					// style to hold the base button textures
	private Rect baseButtonRect;				// holds the relative location to draw the base button

	private PhBar phbar;						// to hold a reference to the ph bar

	// Use this for initialization
	void Start () 
	{
		// find the phbar
		phbar = FindObjectOfType(typeof(PhBar)) as PhBar;

		// set the dimensions of the base button rect relative to screen size
		baseButtonRect = new Rect (64f / 1024f * Screen.width, 601f / 768f * Screen.height,
		          166f / 1024f * Screen.width, 129f / 768f * Screen.height);
	}
	
	// Update is called once per frame
	void Update () {}

	void OnGUI()
	{
		GUI.depth = GUI.depth - 2;

		// draw the base button
		if (GUI.RepeatButton(baseButtonRect, "", baseButton))
		{
			phbar.addBase();		// when the button is pressed call the addBase function from the phBar script
		}
	}
}
