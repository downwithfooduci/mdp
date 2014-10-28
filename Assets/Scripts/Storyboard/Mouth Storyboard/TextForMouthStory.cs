using UnityEngine;
using System.Collections;
using System.IO;

// all the text classes are really hacked together because they were done late at night at the last minute
// they have the text show up with the audio on the screen.
public class TextForMouthStory : MonoBehaviour 
{
	StoryboardHandler mouthStoryboard;
	private string[] text;
	private float timer;
	private bool resetTimerPage2, resetTimerPage3;

	// Use this for initialization
	void Start () 
	{
		mouthStoryboard = this.gameObject.GetComponent<StoryboardHandler> ();
		
		TextAsset mouthText = Resources.Load ("MouthText") as TextAsset;
		text = mouthText.text.Split("\n"[0]);	
		
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
	}

	void OnGUI()
	{
		GUI.depth--;
		
		GUIStyle statsStyle = GUI.skin.box;
		statsStyle.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		statsStyle.normal.textColor = Color.yellow;
		statsStyle.fontSize = (int)(20f / 597f * Screen.height);
		statsStyle.wordWrap = true;
		statsStyle.alignment = TextAnchor.MiddleCenter;
		
		if (mouthStoryboard.getCurrPage() == 1)
		{
			GUI.Box(new Rect(.05f*Screen.width, (625f/768f)*Screen.height, .9f*Screen.width,
			                 .15f*Screen.height), text[0], statsStyle);
			timer = 0;
		} 

		if (mouthStoryboard.getCurrPage() == 2)
		{
			if (!resetTimerPage2)
			{
				timer = 0;
				resetTimerPage2 = true;
			}

			if (timer < 5)
			{
				GUI.Box(new Rect(.05f*Screen.width, (625f/768f)*Screen.height, .9f*Screen.width,
				                 .15f*Screen.height), text[1], statsStyle);
			} else if (timer < 18)
			{
				GUI.Box(new Rect(.05f*Screen.width, (625f/768f)*Screen.height, .9f*Screen.width,
				                 .17f*Screen.height), text[2], statsStyle);
			} else if (timer < 28)
			{
				GUI.Box(new Rect(.05f*Screen.width, (625f/768f)*Screen.height, .9f*Screen.width,
				                  .15f*Screen.height), text[3], statsStyle);
			} else
			{
				GUI.Box(new Rect(.05f*Screen.width, (625f/768f)*Screen.height, .9f*Screen.width,
				                 .15f*Screen.height), text[4], statsStyle);
			}
		}

		if (mouthStoryboard.getCurrPage() == 3)
		{
			if (!resetTimerPage3)
			{
				timer = 0;
				resetTimerPage3 = true;
			}

			if (timer < 4)
			{
				GUI.Box(new Rect(.05f*Screen.width, (625f/768f)*Screen.height, .9f*Screen.width,
			    	             .15f*Screen.height), text[5], statsStyle);
			} else if (timer < 11)
			{
				GUI.Box(new Rect(.05f*Screen.width, (625f/768f)*Screen.height, .9f*Screen.width,
				                 .15f*Screen.height), text[6], statsStyle);
			} else
			{
				GUI.Box(new Rect(.05f*Screen.width, (625f/768f)*Screen.height, .9f*Screen.width,
				                 .15f*Screen.height), text[7], statsStyle);
			}
		}		
	}
}
