using UnityEngine;
using System.Collections;

/**
 * script that helps load levels in the small intestine game
 */
public class SmallIntestineLoadLevelCounter : MonoBehaviour 
{
	private int level;			//!< to hold the current level
	private int MAX_LEVEL = 6;  //!< for bounds checking

	/**
	 * Use this for initialization
	 * Checks for what level we are on and updates the saved level value for next time.
	 */
	void Start () 
	{
		// check what level we are loading
		level = PlayerPrefs.GetInt ("DesiredSILevel");

		if (level != -1)				// if the level was not -1, load the value and then set it to -1 for next time
		{
			// reset the variable for later use
			PlayerPrefs.SetInt("DesiredSILevel", -1);
			PlayerPrefs.Save ();
		} else
		{
			// if it was -1 then we are starting as normal, which means starting from level 1
			level = 0;	// load the tutorial first
		}

		// look if there is more than once instance of the background chooser. if there is destroy this one
		if (GameObject.FindGameObjectsWithTag ("backgroundChooser").Length > 1)
			Destroy (gameObject);
	}
	
	/**
	 * Update is called once per frame
	 * Handles clean up of this level counter if we leave a scene where it should stay alive
	 */
	void Update () 
	{
		string scene = Application.loadedLevelName;				// store the name of the current loaded scene

		// check if we are in a scene where it is appropriate to be using this script
		// since this script does not destroy when we change scenes, we have to check to make sure we are still
		// in a valid SI game related scene to determine if we should manually destroy this instance of the script
		if (scene != "LoadLevelSmallIntestine" && scene != "SmallIntestineEven" && 
		    scene != "SmallIntestineOdd" && scene != "SmallIntestineStats" && scene != "SmallIntestineTutorial")
		{
			Destroy (gameObject);
		}
	}

	/**
	 * Called when scenes are changed. Makes sure it's not destroyed.
	 */
	void Awake() 
	{
		// this causes this instance of the script to not be destroyed when we change scenes
		DontDestroyOnLoad(transform.gameObject);
	}

	/**
	 * Allow manual level changing forced by a menu rather than automatic transitions
	 */
	public void manualSetLevel(int newLevel)
	{
		if (newLevel >= 0 && newLevel <= MAX_LEVEL)	// verify that the desired level is a valid number
		{
			level = newLevel;						// if it is set level to that value
		}
	}

	/**
	 * For moving on to the next level
	 */
	public void nextLevel()
	{
		level++;			// when this function is called it sill just increase the level variable by 1
	}

	/**
	 * For reseeting game
	 */
	public void resetLevel()
	{
		// resetting does not go back to the tutorial (since a user would probably only play the tutorial once)
		level = 1;
	}

	/**
	 * a function that can be called to get the current level # being stored in level
	 */
	public int getLevel()
	{
		return level;
	}

	/**
	 * a function that can be called to get the value stored in MAX_LEVEL
	 */
	public int getMaxLevels()
	{
		return MAX_LEVEL;
	}
}
