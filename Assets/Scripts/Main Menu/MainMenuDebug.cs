using UnityEngine;
using System.Collections;

public class MainMenuDebug : MonoBehaviour 
{
	private bool debugEnabled = false;
	public GameObject desiredSILevel;

	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.depth--;

		if (GUI.Button(new Rect(0, 0, 
		                        100, 50), "Debug"))
		{
		//TODO: disable/reenable debug
			debugEnabled = !debugEnabled;
		}

		if (debugEnabled == true)
		{
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
				Application.LoadLevel("Mouth");
			}

			if (GUI.Button(new Rect(0, 150, 
			                        100, 50), "SI Game"))
			{
				Application.LoadLevel("LoadLevelSmallIntestine");
			}

/***********************************************************
 * List all storybook segments for selection
 * ********************************************************/
			if (GUI.Button(new Rect(150, 50, 
			                        100, 50), "Intro Story"))
			{
				Application.LoadLevel("IntroStoryboard");
			}
			
			if (GUI.Button(new Rect(150, 100, 
			                        100, 50), "Mouth Story"))
			{
				Application.LoadLevel("MouthStoryboard");
			}
			
			if (GUI.Button(new Rect(150, 150, 
			                        100, 50), "SI Story"))
			{
				Application.LoadLevel("SmallIntestineStoryboard");
			}

/***********************************************************
 * Allow jumping between different game levels for SI game
 * ********************************************************/
			if (GUI.Button(new Rect(300, 50, 
			                        100, 50), "SI Level 1"))
			{
				GameObject desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				DesiredSILevel level = desiredSILevelObj.GetComponent<DesiredSILevel>();
				level.setDesiredLevel(1);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}
			
			if (GUI.Button(new Rect(300, 100, 
			                        100, 50), "SI Level 2"))
			{
				GameObject desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				DesiredSILevel level = desiredSILevelObj.GetComponent<DesiredSILevel>();
				level.setDesiredLevel(2);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}
			
			if (GUI.Button(new Rect(300, 150, 
			                        100, 50), "SI Level 3"))
			{
				GameObject desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				DesiredSILevel level = desiredSILevelObj.GetComponent<DesiredSILevel>();
				level.setDesiredLevel(3);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}

			if (GUI.Button(new Rect(300, 200, 
			                        100, 50), "SI Level 4"))
			{
				GameObject desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				DesiredSILevel level = desiredSILevelObj.GetComponent<DesiredSILevel>();
				level.setDesiredLevel(4);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}

			if (GUI.Button(new Rect(300, 250, 
			                        100, 50), "SI Level 5"))
			{
				GameObject desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				DesiredSILevel level = desiredSILevelObj.GetComponent<DesiredSILevel>();
				level.setDesiredLevel(5);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}

			if (GUI.Button(new Rect(300, 300, 
			                        100, 50), "SI Level 6"))
			{
				GameObject desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				DesiredSILevel level = desiredSILevelObj.GetComponent<DesiredSILevel>();
				level.setDesiredLevel(6);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}
		}
	}
}
