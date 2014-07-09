using UnityEngine;
using System.Collections;

public class SmallIntestineStoryboard : MonoBehaviour 
{
	public Texture[] pages;			// story the storyboard pages
	public AudioClip[] sounds;		// store the storyboard narrations
	private int currPage = 1;		// store the current page
	private bool hasPlayed = false;	// remember whether the current sound has played

	// for detecting a swipe
	private float xStart = 0.0f;
	private float xEnd = 0.0f;
	private bool swipe = false;

	// check for playthrough
	private bool canSkip = false;

	// trying to preload
	private AsyncOperation loader;

	// Use this for initialization
	void Start () 
	{
		// find out if we can skip without listening
		canSkip = (PlayerPrefs.GetInt ("PlayedSIStory") == 1) ? true : false;

		// preload next scene
		StartCoroutine(loadNextLevel());
	}
	
	IEnumerator loadNextLevel() 
	{
		loader = Application.LoadLevelAsync("LoadLevelSmallIntestine");
		loader.allowSceneActivation = false;
		yield return loader;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!hasPlayed)		// only play the clip once per page
		{
			audio.clip = sounds [currPage - 1];
			playClip();
			hasPlayed = true;
		}

		if (!audio.isPlaying | canSkip)
		{
			foreach (Touch touch in Input.touches) 
			{
				if (touch.phase == TouchPhase.Began) 
				{
					xStart = touch.position.x;
				}
				if (touch.phase == TouchPhase.Moved) 
				{
					xEnd = touch.position.x;
					
					if ((xStart - xEnd) > 30) 
					{
						swipe = true;
					}
				}
			}

			// for pc/mac
			if(Input.GetMouseButtonDown(0))
			{
				xStart = Input.mousePosition.x;
			}
			if (Input.GetMouseButtonUp(0)) 
			{
				xEnd = Input.mousePosition.x;
				
				if ((xStart - xEnd) > 30) 
				{
					swipe = true;
				}
			}

			// set variables for next page
			if (swipe == true)
			{
				currPage++;
				if ((currPage - 1) == pages.Length)
				{
					PlayerPrefs.SetInt("PlayedSIStory", 1);
					PlayerPrefs.Save();
					loader.allowSceneActivation = true;
				}
				swipe = false;
				xStart = 0;
				xEnd = 0;
				hasPlayed = false;
			}
		}
	}

	/*
	 * play the audio clip
	 * */
	private void playClip()
	{
		audio.Play();
	}

	void OnGUI()
	{
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), pages[Mathf.Clamp(currPage - 1, 0, pages.Length - 1)]);

		// create an invisible button by the page turn
		if(!audio.isPlaying || canSkip)
		{
			GUI.color = new Color() { a = 0.0f };
			if (GUI.Button(new Rect(Screen.width * .84f, 0, Screen.width * .16f, Screen.width * .16f),""))
			{
				swipe = true;
			}
			GUI.color = new Color() { a = 1.0f };
		}
	}

	public int getCurrPage()
	{
		return currPage;
	}
}
