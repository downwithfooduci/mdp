using UnityEngine;
using System.Collections;

public class MainMenuDebug : MonoBehaviour 
{
	private bool debugEnabled = false;

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
				PlayerPrefs.SetInt("DesiredSILevel", 0);
				PlayerPrefs.Save();
				Application.LoadLevel("LoadLevelSmallIntestine");
			}
			if (GUI.Button(new Rect(300, 100, 
			                        100, 50), "SI Level 1"))
			{
				PlayerPrefs.SetInt("DesiredSILevel", 1);
				PlayerPrefs.Save();
				Application.LoadLevel("LoadLevelSmallIntestine");
			}
			
			if (GUI.Button(new Rect(300, 150, 
			                        100, 50), "SI Level 2"))
			{
				PlayerPrefs.SetInt("DesiredSILevel", 2);
				PlayerPrefs.Save();
				Application.LoadLevel("LoadLevelSmallIntestine");
			}
			
			if (GUI.Button(new Rect(300, 200, 
			                        100, 50), "SI Level 3"))
			{
				PlayerPrefs.SetInt("DesiredSILevel", 3);
				PlayerPrefs.Save();
				Application.LoadLevel("LoadLevelSmallIntestine");
			}

			if (GUI.Button(new Rect(300, 250, 
			                        100, 50), "SI Level 4"))
			{
				PlayerPrefs.SetInt("DesiredSILevel", 4);
				PlayerPrefs.Save();
				Application.LoadLevel("LoadLevelSmallIntestine");
			}

			if (GUI.Button(new Rect(300, 300, 
			                        100, 50), "SI Level 5"))
			{
				PlayerPrefs.SetInt("DesiredSILevel", 5);
				PlayerPrefs.Save();
				Application.LoadLevel("LoadLevelSmallIntestine");
			}

			if (GUI.Button(new Rect(300, 350, 
			                        100, 50), "SI Level 6"))
			{
				PlayerPrefs.SetInt("DesiredSILevel", 6);
				PlayerPrefs.Save();
				Application.LoadLevel("LoadLevelSmallIntestine");
			}


/***********************************************************
 * Allow jumping between different game levels for Mouth game
 * ********************************************************/
			if (GUI.Button(new Rect(450, 50, 
			                        100, 50), "Mouth 1"))
			{
				PlayerPrefs.SetInt("DesiredMouthLevel", 1);
				PlayerPrefs.Save();
				Application.LoadLevel("LoadLevelMouth");
			}
			
			if (GUI.Button(new Rect(450, 100, 
			                        100, 50), "Mouth 2"))
			{
				PlayerPrefs.SetInt("DesiredMouthLevel", 1);
				PlayerPrefs.Save();
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
