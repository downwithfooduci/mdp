using UnityEngine;
using System.Collections;

// script class that helps with loading and keeping track of the proper mouth level
public class MouthLoadLevelCounter : MonoBehaviour 
{
	private int level;			// variable to hold the level
	public int MAX_LEVEL = 2; 	// for bounds checking

	// Use this for initialization
	void Start () 
	{
		level = PlayerPrefs.GetInt ("DesiredMouthLevel");
		
		if (level != -1)
		{
			// reset the variable for later use
			PlayerPrefs.SetInt("DesiredMouthLevel", -1);
			PlayerPrefs.Save ();
		} else
		{
			// if it was -1 then we are starting as normal
			level = 1;
		}
		
		if (GameObject.FindGameObjectsWithTag ("mouthBackgroundChooser").Length > 1)
			Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		string scene = Application.loadedLevelName;
		if (scene != "LoadLevelMouth" && scene != "Mouth" && scene != "MouthStats")
			Destroy (gameObject);
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
		if (newLevel > 0 && newLevel <= MAX_LEVEL)
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
