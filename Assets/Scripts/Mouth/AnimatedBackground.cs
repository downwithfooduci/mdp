using UnityEngine;
using System.Collections;

public class AnimatedBackground : MonoBehaviour 
{
	public Texture[] stills;			// story the animations stills
	public AudioClip[] audioClips;
	public int[] numSlides;
	private int currPage = 0;		// store the current page
	private int currGroup = 0;
	bool allowSwitch = false;
	public Texture corner;
	int numInGroup;
	float slideTimeout = 1f;
	int currentSound;
	
	// for slide animation delay
	private float timeDelay;
	public float animationDelay;

	// for detecting a swipe
	private float xStart = 0.0f;
	private float xEnd = 0.0f;
	private bool swipe = false;

	// check for playthrough
	GameObject skipStory;
	private bool canSkip = false;
	SkipStoryEnablerScript skipStoryScript;
	
	// Use this for initialization
	void Start () 
	{
		skipStory = GameObject.Find("SkipStoryEnabler(Clone)");
		skipStoryScript = skipStory.GetComponent<SkipStoryEnablerScript> ();
		if (skipStoryScript != null)
		{
			canSkip = skipStoryScript.getSkipStory();
		}

		audio.clip = audioClips[currGroup];
		numInGroup = numSlides[currGroup];
		numInGroup--;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(slideTimeout > 0)
		{
			slideTimeout -= Time.deltaTime;
		} else if(!allowSwitch)
		{
			if(numInGroup > 0)
			{
				numInGroup--;
				currPage++;
				slideTimeout = 1f;
			} else if(!audio.isPlaying)
			{
				currGroup++;
				if(currGroup >= audioClips.Length)
				{
					currGroup--;
					allowSwitch = true;
				}
				else
				{
					audio.clip = audioClips[currGroup];
					audio.Play();
					numInGroup = numSlides[currGroup];
				}
			}
		}
		if (allowSwitch | canSkip)
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
		if (swipe == true)
		{
			Application.LoadLevel("SmallIntestineStoryboard");
		}
	}
	
	void OnGUI()
	{
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), stills[currPage]);
		if(allowSwitch | canSkip)
		{
			GUI.DrawTexture(new Rect(Screen.width * .84f, 0, Screen.width * .16f, Screen.width * .16f), corner);
		}
	}
}