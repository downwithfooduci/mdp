using UnityEngine;
using System.Collections;

public class AnimatedBackground : MonoBehaviour 
{
	public Texture[] stills;			// story the animations stills
	private int currPage = 1;		// store the current page
	bool allowSwitch = false;
	public Texture corner;
	
	// for slide animation delay
	private float timeDelay;
	public float animationDelay;

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
		timeDelay += Time.deltaTime;
		if (timeDelay >= animationDelay)
		{
			currPage++;
			if (currPage > stills.Length)
			{
				currPage = 1;
				allowSwitch = true;
			}
			timeDelay = 0;
		}

		if (allowSwitch)
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
		}
		
		// set variables for next page
		if (swipe == true)
		{
			Application.LoadLevel("SmallIntestineStoryboard");
		}
	}
	
	void OnGUI()
	{
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), stills[currPage - 1]);

		if(allowSwitch)
		{
			GUI.DrawTexture(new Rect(Screen.width - 100, 0, 100, 100), corner);
		}
	}
}