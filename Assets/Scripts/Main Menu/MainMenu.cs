using UnityEngine;
using System.Collections;

/**
 * class for the main menu screen for the game
 */
public class MainMenu : MonoBehaviour 
{
	public Texture background;	//!< for the background image on the main screen
	public GUIStyle startBtn;	//!< for the start button

	/**
	 * Handles drawing all elements on the main title screen
	 */
	void OnGUI()
    {
		// draw the texture for the background that takes up the entire screen
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), background);

		// draw the start button in the bottom right corner


		if (GUI.Button (new Rect(Screen.width * 0.8f, Screen.height * 0.8f,
		                         Screen.width * 0.2f, Screen.height * 0.1f), "Mouth Game"))
		    {
			Application.LoadLevel("LoadLevelMouth");
			}
		if (GUI.Button(new Rect(Screen.width * 0.8f, Screen.height * 0.9f,
		                        Screen.width * 0.2f, Screen.height * 0.1f), "Small Intestine Game"))
		{
			Application.LoadLevel("LoadLevelSmallIntestine");
		}
	}
}
