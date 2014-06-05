using UnityEngine;
using System.Collections;

public class MouthLoadLevelCounter : MonoBehaviour 
{
	private int level;
	private int MAX_LEVEL = 2; // for bounds checking

	// Use this for initialization
	void Start () 
	{
		GameObject desiredMouthLevel = GameObject.Find ("ManualMouthLevelSelection(Clone)");
		
		if (desiredMouthLevel != null)
		{
			DesiredMouthLevel desiredMouthLevelScript = desiredMouthLevel.GetComponent<DesiredMouthLevel> ();
			level = desiredMouthLevelScript.getDesiredLevel();
			Destroy (desiredMouthLevel);
		} else
		{
			level = 1;
		}
		
		if (GameObject.FindGameObjectsWithTag ("mouthBackgroundChooser").Length > 1)
			Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		string scene = Application.loadedLevelName;
		if (scene != "LoadLevelMouth" && scene != "Mouth")
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
