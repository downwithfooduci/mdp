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

	private GameObject skipStoryEnabler;
	private SkipStoryEnablerScript skipStoryEnablerScript;
	private bool skipEnabled = false;

	void Start()
	{
		skipStoryEnabler = GameObject.Find ("SkipStoryEnabler(Clone)");
		skipStoryEnablerScript = skipStoryEnabler.GetComponent<SkipStoryEnablerScript> ();
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
			skipEnabled = GUI.Toggle(new Rect(150, 50, 100, 50), skipEnabled, "Allow Skip B4 Audio Plays");
			if (skipEnabled)
			{
				skipStoryEnablerScript.setSkipStory(true);
			} else
			{
				skipStoryEnablerScript.setSkipStory(false);
			}

/***********************************************************
 * List all storybook segments for selection
 * ********************************************************/
			if (GUI.Button(new Rect(150, 100, 
			                        100, 50), "Intro Story"))
			{
				Application.LoadLevel("IntroStoryboard");
			}
			
			if (GUI.Button(new Rect(150, 150, 
			                        100, 50), "Mouth Story"))
			{
				Application.LoadLevel("MouthStoryboard");
			}

			if (GUI.Button(new Rect(150, 200, 
			                        100, 50), "Mouth Animation"))
			{
				Application.LoadLevel("MouthAnimation");
			}
			
			if (GUI.Button(new Rect(150, 250, 
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
				desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				levelSI = desiredSILevelObj.GetComponent<DesiredSILevel>();
				levelSI.setDesiredLevel(1);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}
			
			if (GUI.Button(new Rect(300, 100, 
			                        100, 50), "SI Level 2"))
			{
				desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				levelSI = desiredSILevelObj.GetComponent<DesiredSILevel>();
				levelSI.setDesiredLevel(2);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}
			
			if (GUI.Button(new Rect(300, 150, 
			                        100, 50), "SI Level 3"))
			{
				desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				levelSI = desiredSILevelObj.GetComponent<DesiredSILevel>();
				levelSI.setDesiredLevel(3);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}

			if (GUI.Button(new Rect(300, 200, 
			                        100, 50), "SI Level 4"))
			{
				desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				levelSI = desiredSILevelObj.GetComponent<DesiredSILevel>();
				levelSI.setDesiredLevel(4);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}

			if (GUI.Button(new Rect(300, 250, 
			                        100, 50), "SI Level 5"))
			{
				desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				levelSI = desiredSILevelObj.GetComponent<DesiredSILevel>();
				levelSI.setDesiredLevel(5);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}

			if (GUI.Button(new Rect(300, 300, 
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
		}
	}
}
