using UnityEngine;
using System.Collections;

public class SmallIntestineLoadLevelCounter : MonoBehaviour 
{
	private int level;
	private int MAX_LEVEL = 6; // for bounds checking

	// Use this for initialization
	void Start () 
	{
		level = PlayerPrefs.GetInt ("DesiredSILevel");

		if (level != -1)
		{
			// reset the variable for later use
			PlayerPrefs.SetInt("DesiredSILevel", -1);
			PlayerPrefs.Save ();
		} else
		{
			// if it was -1 then we are starting as normal
			level = 1;
		}
		if (GameObject.FindGameObjectsWithTag ("backgroundChooser").Length > 1)
			Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		string scene = Application.loadedLevelName;
		if (scene != "LoadLevelSmallIntestine" && scene != "SmallIntestineEven" && 
		    scene != "SmallIntestineOdd" && scene != "SmallIntestineStats" && scene != "SmallIntestineTutorial")
		{
			Destroy (gameObject);
		}
	}

	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
	}

	/*
	 * Allow manual level changing forced by a menu rather than automatic transitions
	 * */
	public void manualSetLevel(int newLevel)
	{
		if (newLevel >= 0 && newLevel <= MAX_LEVEL)
		{
			level = newLevel;
		}
	}

	/*
	 * For moving on to the next level
	 * */
	public void nextLevel()
	{
		level++;
	}

	/*
	 * For reseeting game
	 * */
	public void resetLevel()
	{
		// resetting does not go back to the tutorial
		level = 1;
	}

	public int getLevel()
	{
		return level;
	}

	public int getMaxLevels()
	{
		return MAX_LEVEL;
	}
}
