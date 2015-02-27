using UnityEngine;
using System.Collections;

/**
 * Handle game over conditions for the stomach game
 */
public class StomachGameOver : MonoBehaviour 
{
	public Texture gameOverPopup;	//!< to store the texture for the gameOverPopup
	public GUIStyle restart;		//!< to store the textures for the restart button
	public GUIStyle mainMenu;		//!< to store the textures for the mainMenu button
	
	public int maxFood;				//!< the max food allowed to pile up before a gameover
	
	private StomachFoodManager fm;	//!< to hold a reference to the stomach food manager
	
	private bool gameOver;			//!< flag to indicate if the game is over
	
	/**
	 * Use this for initialization
	 */
	void Start () 
	{
		// get references
		fm = FindObjectOfType (typeof(StomachFoodManager)) as StomachFoodManager;
	}
	
	/**
	 * Update is called once per frame
	 */
	void Update () 
	{
		if (fm.getNumFoodBlobs() == maxFood)
		{
			gameOver = true;
			Time.timeScale = 0;
		}
	}
	
	/**
	 * Game over popup is drawn with legacy gui
	 */
	void OnGUI()
	{
		if (gameOver)
		{
			// draw the game over popup box in the middle of the screen
			GUI.DrawTexture(new Rect(Screen.width * 0.3193359375f, 
			                         Screen.height * 0.28515625f, 
			                         Screen.width * 0.3603515625f, 
			                         Screen.height * 0.248697917f), gameOverPopup);
			
			// draw restart button
			if (GUI.Button(new Rect(Screen.width * 0.41015625f, 
			                        Screen.height * 0.41927083f,
			                        Screen.width * 0.0654296875f,
			                        Screen.height * 0.06640625f), "", restart))
			{
				// if restart is pressed
				Time.timeScale = 1;													// unpause the game
				Application.LoadLevel("Stomach");
			}
			
			// draw main menu button
			if (GUI.Button(new Rect(Screen.width * 0.53125f, 
			                        Screen.height * 0.41927083f,
			                        Screen.width * 0.0654296875f,
			                        Screen.height * 0.06640625f), "", mainMenu))
			{
				// if main menu is selected
				Time.timeScale = 1;													// unpause the game
				Application.LoadLevel("MainMenu");	// load the main menu
			}
		}
	}
}