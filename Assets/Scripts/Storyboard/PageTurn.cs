using UnityEngine;
using System.Collections;

public class PageTurn : MonoBehaviour 
{
	public Texture corner;
	private bool canSkip = false;

	// Use this for initialization
	void Start () 
	{
		// figure out if we can skip
		if (Application.loadedLevelName.Equals("IntroStoryboard"))
		{
			canSkip = ((PlayerPrefs.GetInt("PlayedIntroStory") == 1) ? true : false);
		} else if (Application.loadedLevelName.Equals("MouthStoryboard"))
		{
			canSkip = ((PlayerPrefs.GetInt("PlayedMouthStory") == 1) ? true : false);
		} else if (Application.loadedLevelName.Equals("MouthEndStoryboard"))
		{
			canSkip = ((PlayerPrefs.GetInt("PlayedMouthEndStory") == 1) ? true : false);
		} else if (Application.loadedLevelName.Equals("SmallIntestineStoryboard"))
		{
			canSkip = (PlayerPrefs.GetInt("PlayedSIStory") == 1) ? true : false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.depth--;
		if (!audio.isPlaying || canSkip)
			GUI.DrawTexture(new Rect(Screen.width * .84f, 0, Screen.width * .16f, Screen.width * .16f), corner);
	}
}
