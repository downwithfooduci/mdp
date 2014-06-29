using UnityEngine;
using System.Collections;

public class AddMainMenuButton : MonoBehaviour {
	public GUIStyle mainMenuStyle;	// for main menu button
	
	public Texture confirmPopup;	// for pop up confirm box
	public GUIStyle confirmYes;		// button for yes
	public GUIStyle confirmNo;		// button for no

	// trying to preload
	private AsyncOperation loader;
	
	private bool confirmUp;
	
	void OnGUI()
	{
		if (confirmUp) 
		{
			GUI.depth--;
		} else
		{
			GUI.depth += 10;
		}

		// this just handles the menu button in the corner
		if(Time.timeScale != 0)
		{
			if (GUI.Button(new Rect(0, 
			                        0,
			                        100,
			                        50), "", mainMenuStyle))
			{
				confirmUp = true;		// throw flag
			//	Application.LoadLevel("MainMenu");
			}
		}
		
		// if the menu button has been pressed
		//TODO: this is hidden
		if (confirmUp)
		{
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
				AsyncOperation load = Application.LoadLevelAsync("MainMenu");
				load.priority = 1;
				load.allowSceneActivation = true;
			//	Application.LoadLevel("MainMenu");
			}
			
			// draw no button
			if (GUI.Button(new Rect(Screen.width * 0.53125f, 
			                        Screen.height * 0.41927083f,
			                        Screen.width * 0.0654296875f,
			                        Screen.height * 0.06640625f), "", confirmNo))
			{
				confirmUp = false;
			}
			
		}
	}
}
