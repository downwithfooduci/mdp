using UnityEngine;
using System.Collections;

// script for the return button for the mouth game
public class EsophagusReturnButton : MonoBehaviour 
{
	public GUIStyle mainMenuStyle;	// for main menu button
	
	public Texture confirmPopup;	// for pop up confirm box
	public GUIStyle confirmYes;		// button for yes
	public GUIStyle confirmNo;		// button for no
	
	private bool confirmUp;			// flag to determine whether the confirm box is up
	
	void OnGUI()
	{
		// this just handles the menu button in the corner
		if(Time.timeScale != 0)		// don't draw the main menu button if timescale is 0 because this means there is some
									// other user control option up such as game over
		{
			if (GUI.Button(new Rect(Screen.width * .89f, 
			                        Screen.height * 0.01822916f,
			                        Screen.width * .09f,
			                        Screen.height * .06f), "", mainMenuStyle))
			{
				Time.timeScale = 0;		// pause the game
				confirmUp = true;		// throw flag
			}
		}
		
		// if the menu button has been pressed
		if (confirmUp)			// confirm the user wants to exit to the main menu
		{
			GUI.depth--;
			
			// draw gui texture that holds box with buttons
			GUI.DrawTexture(new Rect(Screen.width * 0.3193359375f, 
			                         Screen.height * 0.28515625f, 
			                         Screen.width * 0.3603515625f, 
			                         Screen.height * 0.248697917f), confirmPopup);
			
			// draw yes button
			if (GUI.Button(new Rect(Screen.width * 0.41015625f, 
			                        Screen.height * 0.41927083f,
			                        Screen.width * 0.0654296875f,
			                        Screen.height * 0.06640625f), "", confirmYes))
			{
				// if the yes button was pressed
				Time.timeScale = 1;					// unpause the game
				Application.LoadLevel("MainMenu");	// return to the main menu
			}
			
			// draw no button
			if (GUI.Button(new Rect(Screen.width * 0.53125f, 
			                        Screen.height * 0.41927083f,
			                        Screen.width * 0.0654296875f,
			                        Screen.height * 0.06640625f), "", confirmNo))
			{
				// if the no button was pressed
				Time.timeScale = 1;					// unpause the game
				confirmUp = false;					// unflag the confirm up variable
			}
		}
	}
}