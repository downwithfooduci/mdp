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
		if (GUI.Button(new Rect(Screen.width * 0.8f, Screen.height * 0.8f,
		                        Screen.width * 0.2f, Screen.height * 0.1f), "Mouth Game"))
        {
			// load the first part of the game
		//	Application.LoadLevel("IntroStoryboard");	// right now intro storyboard is the first level so we start here
			Application.LoadLevel("LoadLevelMouth");
        }

		// this is just a placeholder for now to the level selection screen
		// should be moved or changed or removed based on what is decided
		if (GUI.Button(new Rect(Screen.width * 0.8f, Screen.height * 0.9f,
		                        Screen.width * 0.2f, Screen.height * 0.1f), "Small Intestine Game"))
		{
		//	Application.LoadLevel("LevelSelection");
			Application.LoadLevel("LoadLevelSmallIntestine");
		}
	}
}
