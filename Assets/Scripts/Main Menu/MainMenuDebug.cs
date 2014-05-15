using UnityEngine;
using System.Collections;

public class MainMenuDebug : MonoBehaviour 
{
	private bool debugEnabled = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
		}
	}
}
