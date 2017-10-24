using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fridgeSkipButton : MonoBehaviour {


	public GUIStyle mainMenuStyle;	//!< for main menu button

	public Texture confirmPopup;	//!< for pop up confirm box
	public GUIStyle confirmYes;		//!< button for "skip game"
	public GUIStyle confirmNo;		//!< button for "keep going"

	private string prevLevel;
	public float x, y;

	private bool confirmUp;			//!< flag to determine whether the confirm box is up
	private FingerPopup fp;
	private string scence;



	void Start(){
		fp = FindObjectOfType (typeof(FingerPopup)) as FingerPopup;
		scence = Application.loadedLevelName;
		prevLevel = PlayerPrefs.GetString ("lastLoadedGame");
		Debug.Log ("prevLevel" + prevLevel);
	}

	/**
	 * Draws the return button and handles drawing the Quit game pop up if necessary
	 */

	void OnGUI()
	{
		// this just handles the menu button in the corner
		//if(Time.timeScale != 0)		// don't draw the main menu button if timescale is 0 because this means there is some
			// other user control option up such as game over
		//{
			if (GUI.Button(new Rect(Screen.width * x,//.79f, 
				Screen.height * y,//0.01822916f,
				Screen.width * .09f,
				Screen.height * .06f), "", mainMenuStyle))
			{
				//if(scence == "Mouth")fp.setPaused ();
				Time.timeScale = 0;		// pause the game
				confirmUp = true;		// throw flag
			}
		//}

		// if the menu button has been pressed
		if (confirmUp)			// confirm the user wants to exit to the main menu
		{
			GUI.depth--;

			// draw gui texture that holds box with buttons
			GUI.DrawTexture(new Rect(Screen.width * 0.3193359375f, 
				Screen.height * 0.28515625f, 
				Screen.width * 0.3603515625f, 
				Screen.height * 0.248697917f), confirmPopup);

			// draw "skip game" button
			if (GUI.Button(new Rect(Screen.width * 0.3903f, 
				Screen.height * 0.41927083f,
				Screen.width * 0.1025f,
				Screen.height * 0.06640625f), "", confirmYes))
			{
				// if the "skip game" button was pressed
				Time.timeScale = 1;					// unpause the game
				/*
				if (level == "SmallIntestineLevel1") {
					GameObject chooseBackground = GameObject.Find("ChooseBackground");	// find the background chooser
					SmallIntestineLoadLevelCounter  SIlevel = chooseBackground.GetComponent<SmallIntestineLoadLevelCounter>();
					SIlevel.nextLevel();
					if (SIlevel.getLevel () <= SIlevel.getMaxLevels ()) {
						Application.LoadLevel ("LoadLevelSmallIntestine");
					}
					else {
						Application.LoadLevel ("SmallIntestineEndStoryboard");
					}
				}
				else{
					Application.LoadLevel(level);	// return to the main menu
				}
				*/
				if (prevLevel == "Mouth") {
					Application.LoadLevel ("MouthEndStoryboard");
				} else if (prevLevel == "Stomach") {
					Application.LoadLevel ("StomachEndStoryboard");
				} else if (prevLevel == "SI") {
					GameObject chooseBackground = GameObject.Find("ChooseBackground");	// find the background chooser
					SmallIntestineLoadLevelCounter  SIlevel = chooseBackground.GetComponent<SmallIntestineLoadLevelCounter>();
					SIlevel.nextLevel();
					if (SIlevel.getLevel () <= SIlevel.getMaxLevels ()) {
						Application.LoadLevel ("LoadLevelSmallIntestine");
					}
					else {
						Application.LoadLevel ("SmallIntestineEndStoryboard");
					}
				} else if (prevLevel == "LI") {
					Application.LoadLevel ("LargeIntestineEndStoryboard");
				}

			}

			// draw "keep going" button
			if (GUI.Button(new Rect(Screen.width * 0.51125f, 
				Screen.height * 0.41927083f,
				Screen.width * 0.1025f,
				Screen.height * 0.06640625f), "", confirmNo))
			{
				// if the "keep going" button was pressed
				Time.timeScale = 1;					// unpause the game
				if(scence == "Mouth")fp.setPaused();
				confirmUp = false;					// unflag the confirm up variable
			}
		}
	}
}
