using UnityEngine;
using System.Collections;

public class MouthStoryboard : MonoBehaviour {

	public Texture[] pages;			// story the storyboard pages
	public AudioClip[] sounds;		// store the storyboard narrations
	private int currPage = 1;		// store the current page
	private bool hasPlayed = false;	// remember whether the current sound has played
	
	// for detecting a swipe
	private float xStart = 0.0f;
	private float xEnd = 0.0f;
	private bool swipe = false;
	
	// Use this for initialization
	void Start () 
	{
		
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
		
		if (!audio.isPlaying)
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
			if(Input.GetKeyDown(KeyCode.Space))
				swipe = true;
		}
		
		// set variables for next page
		if (swipe)
		{
			currPage++;
			if ((currPage - 1) == pages.Length)
			{
				Application.LoadLevel("MouthAnimation");
			}
			swipe = false;
			xStart = 0;
			xEnd = 0;
			hasPlayed = false;
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
	}
}
