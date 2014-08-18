using UnityEngine;
using System.Collections;

// script for the "game over" behavior of the mouth game
public class EsophagusGameOver : MonoBehaviour 
{
	private bool isGameOver = false;	// flag to hold whether or not the game is over

	public Texture gameOverPopup;		// to hold the texture of the game over popup box
	public GUIStyle restart;			// to hold the textures for the restart button
	public GUIStyle mainMenu;			// to hold the textures for the mainMenu button

	OxygenBar oxygenBar;				// to hold a reference to the oxygen bar
	
	// Use this for initialization
	void Start () 
	{
		oxygenBar = gameObject.GetComponent<OxygenBar> ();	// find the reference to the oxygen bar
	}
	
	// Update is called once per frame
	void Update () 
	{
		// check if we should throw the game over flag because the oxygen bar runs out
		if (oxygenBar.getPercent() <= 0 && !isGameOver)
		{
			isGameOver = true;		// if the oxygen bar has run out throw the game over flag
			Time.timeScale = 0;		// pause the game to stop movement of food
		}
	}

	void OnGUI()
	{
		if (isGameOver)		// determine if we should draw the game over popup box
		{
			// this draws the popup box in the middle of the screen
			GUI.DrawTexture(new Rect(Screen.width * 0.3193359375f, 
			                         Screen.height * 0.28515625f, 
			                         Screen.width * 0.3603515625f, 
			                         Screen.height * 0.248697917f), gameOverPopup);
			
			// draw restart button in proper condition
			if (GUI.Button(new Rect(Screen.width * 0.41015625f, 
			                        Screen.height * 0.41927083f,
			                        Screen.width * 0.0654296875f,
			                        Screen.height * 0.06640625f), "", restart))
			{
				// if the restart button is pressed
				Time.timeScale = 1;					// unpause the game
				Application.LoadLevel("Mouth");		// reload the mouth game from the current level
			}
			
			// draw the main menu button
			if (GUI.Button(new Rect(Screen.width * 0.53125f, 
			                        Screen.height * 0.41927083f,
			                        Screen.width * 0.0654296875f,
			                        Screen.height * 0.06640625f), "", mainMenu))
			{
				// if the main menu button is pressed
				Time.timeScale = 1;					// unpause the game
				Application.LoadLevel("MainMenu");	// load up the main menu
			}
		}
	}
}	