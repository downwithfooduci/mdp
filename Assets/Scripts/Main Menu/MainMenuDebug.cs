using UnityEngine;
using System.Collections;

public class MainMenuDebug : MonoBehaviour 
{
	private bool debugEnabled = false;

	public GameObject desiredSILevel;
	private GameObject desiredSILevelObj;
	private DesiredSILevel levelSI;

	public GameObject desiredMouthLevel;
	private GameObject desiredMouthLevelObj;
	private DesiredMouthLevel levelMouth;

	void Start()
	{
	}

	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(0, 0, 
		                        100, 50), "Debug"))
		{
		//TODO: disable/reenable debug
			debugEnabled = !debugEnabled;
		}

		if (debugEnabled == true)
		{
			GUI.depth--;
/***********************************************************
 * List all games for selection
 * ********************************************************/
			if (GUI.Button(new Rect(0, 50, 
		   	                     100, 50), "Enzyme Game"))
			{
				Application.LoadLevel("Enzyme");
			}

			if (GUI.Button(new Rect(0, 100, 
			                        100, 50), "Mouth Game"))
			{
				Application.LoadLevel("LoadLevelMouth");
			}

			if (GUI.Button(new Rect(0, 150, 
			                        100, 50), "SI Game"))
			{
				Application.LoadLevel("LoadLevelSmallIntestine");
			}
/***********************************************************
 * Change Page Turn requirements for Story
 * ********************************************************/
			if (GUI.Button(new Rect(150, 50, 
			                        125, 50), "Allow Skip Story"))
			{
				PlayerPrefs.SetInt("PlayedIntroStory", 1);
				PlayerPrefs.SetInt("PlayedMouthStory", 1);
				PlayerPrefs.SetInt("PlayedMouthEndStory", 1);
				PlayerPrefs.SetInt("PlayedSIStory", 1);
				PlayerPrefs.Save();
			}

			if (GUI.Button(new Rect(150, 100, 
			                        125, 50), "DO NOT Allow Skip Story"))
			{
				PlayerPrefs.SetInt("PlayedIntroStory", 0);
				PlayerPrefs.SetInt("PlayedMouthStory", 0);
				PlayerPrefs.SetInt("PlayedMouthEndStory", 0);
				PlayerPrefs.SetInt("PlayedSIStory", 0);
				PlayerPrefs.Save();
			}

/***********************************************************
 * List all storybook segments for selection
 * ********************************************************/
			if (GUI.Button(new Rect(150, 150, 
			                        125, 50), "Intro Story"))
			{
				Application.LoadLevel("IntroStoryboard");
			}
			
			if (GUI.Button(new Rect(150, 200, 
			                        125, 50), "Mouth Story"))
			{
				Application.LoadLevel("MouthStoryboard");
			}

			if (GUI.Button(new Rect(150, 250, 
			                        125, 50), "Mouth Animation"))
			{
				Application.LoadLevel("MouthAnimation");
			}
			
			if (GUI.Button(new Rect(150, 300, 
			                        125, 50), "SI Story"))
			{
				Application.LoadLevel("MouthEndStoryboard");
			}

/***********************************************************
 * Allow jumping between different game levels for SI game
 * ********************************************************/
			if (GUI.Button(new Rect(300, 50, 
			                        100, 50), "SI Tutorial"))
			{
				desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				levelSI = desiredSILevelObj.GetComponent<DesiredSILevel>();
				levelSI.setDesiredLevel(0);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}
			if (GUI.Button(new Rect(300, 100, 
			                        100, 50), "SI Level 1"))
			{
				desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				levelSI = desiredSILevelObj.GetComponent<DesiredSILevel>();
				levelSI.setDesiredLevel(1);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}
			
			if (GUI.Button(new Rect(300, 150, 
			                        100, 50), "SI Level 2"))
			{
				desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				levelSI = desiredSILevelObj.GetComponent<DesiredSILevel>();
				levelSI.setDesiredLevel(2);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}
			
			if (GUI.Button(new Rect(300, 200, 
			                        100, 50), "SI Level 3"))
			{
				desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				levelSI = desiredSILevelObj.GetComponent<DesiredSILevel>();
				levelSI.setDesiredLevel(3);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}

			if (GUI.Button(new Rect(300, 250, 
			                        100, 50), "SI Level 4"))
			{
				desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				levelSI = desiredSILevelObj.GetComponent<DesiredSILevel>();
				levelSI.setDesiredLevel(4);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}

			if (GUI.Button(new Rect(300, 300, 
			                        100, 50), "SI Level 5"))
			{
				desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				levelSI = desiredSILevelObj.GetComponent<DesiredSILevel>();
				levelSI.setDesiredLevel(5);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}

			if (GUI.Button(new Rect(300, 350, 
			                        100, 50), "SI Level 6"))
			{
				desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				levelSI = desiredSILevelObj.GetComponent<DesiredSILevel>();
				levelSI.setDesiredLevel(6);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}


/***********************************************************
 * Allow jumping between different game levels for Mouth game
 * ********************************************************/
			if (GUI.Button(new Rect(450, 50, 
			                        100, 50), "Mouth 1"))
			{
				desiredMouthLevelObj = (GameObject)Instantiate (desiredMouthLevel);
				levelMouth = desiredMouthLevelObj.GetComponent<DesiredMouthLevel>();
				levelMouth.setDesiredLevel(1);
				Application.LoadLevel("LoadLevelMouth");
			}
			
			if (GUI.Button(new Rect(450, 100, 
			                        100, 50), "Mouth 2"))
			{
				desiredMouthLevelObj = (GameObject)Instantiate (desiredMouthLevel);
				levelMouth = desiredMouthLevelObj.GetComponent<DesiredMouthLevel>();
				levelMouth.setDesiredLevel(2);
				Application.LoadLevel("LoadLevelMouth");
			}

/***********************************************************
 * Reset save data
 * ********************************************************/
			if (GUI.Button(new Rect(600, 50, 
			                        100, 50), "Reset all data"))
			{
				PlayerPrefs.DeleteAll();
			}

			if (GUI.Button(new Rect(600, 100, 
			                        100, 50), "Reset only scores"))
			{
				PlayerPrefs.DeleteKey("Mouth1");
				PlayerPrefs.DeleteKey("Mouth2");
				PlayerPrefs.DeleteKey("SI1");
				PlayerPrefs.DeleteKey("SI2");
				PlayerPrefs.DeleteKey("SI3");
				PlayerPrefs.DeleteKey("SI4");
				PlayerPrefs.DeleteKey("SI5");
				PlayerPrefs.DeleteKey("SI6");
			}

			if (GUI.Button(new Rect(600, 150, 
			                        100, 50), "View High Scores"))
			{
				Application.LoadLevel("HighScores");
			}
		}
	}
}
