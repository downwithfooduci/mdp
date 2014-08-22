using UnityEngine;
using System.Collections;

public class MouthStoryboard : MonoBehaviour {

	public Texture[] pages;			// story the storyboard pages
	public AudioClip[] sounds;		// store the storyboard narrations
	private int currPage = 1;		// store the current page
	private bool hasPlayed = false;	// remember whether the current sound has played
	
	// for swipe detection
	DetectStraightSwipe swipeDetection;

	// check for playthrough
	private bool canSkip = false;

	// trying to preload
	private AsyncOperation loader;
	
	// Use this for initialization
	void Start () 
	{
		// find the script for detecting touch
		swipeDetection = gameObject.GetComponent<DetectStraightSwipe> ();

		// find out if we can skip without listening
		canSkip = (PlayerPrefs.GetInt ("PlayedMouthStory") == 1) ? true : false;

		// preload next scene
		StartCoroutine(loadNextLevel());
	}

	IEnumerator loadNextLevel() 
	{
		loader = Application.LoadLevelAsync("LoadLevelMouth");
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

		if (!audio.isPlaying || canSkip)
		{
			if (swipeDetection.getSwipeLeft() == true)				// attempt to detect a swipe to the right
			{
				swipeDetection.resetSwipe();						// reset the variables to prevent multiple page turns
				currPage++;											// increment the page since we are going forward
				
				if ((currPage - 1) == pages.Length)					// perform bounds checking to see if we should load the next scene
				{
					PlayerPrefs.SetInt("PlayedMouthStory", 1);
					PlayerPrefs.Save();
					loader.allowSceneActivation = true;
				}
				
				hasPlayed = false;
			} 
			else if (swipeDetection.getSwipeRight() == true)			// attempt to detect a swipe to the left
			{
				swipeDetection.resetSwipe();						// reset the varaibel to prevent multiple page turns
				
				if (currPage - 1 > 0)								// perform bounds checking to make sure we don't go back too far
				{
					currPage--;
					hasPlayed = false;
				}
			}
		} else if (audio.isPlaying)
		{
			swipeDetection.resetSwipe();							// if we can't change the page yet forget the swipe
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
				currPage++;
				hasPlayed = false;
			}
			GUI.color = new Color() { a = 1.0f };
		}
	}

	public int getCurrPage()
	{
		return currPage;
	}
}
