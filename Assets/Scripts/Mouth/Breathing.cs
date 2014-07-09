using UnityEngine;
using System.Collections;

public class Breathing : MonoBehaviour 
{
	// hold the images
	public Texture[] breathing;
	public Texture[] notBreathing;

	// animation delay
	public float animationDelay1 = .5f;
	public float animationDelay2 = 1.0f;
	private float timePassed = 0f;

	public GameObject flaps;
	private openFlap flapScript;

	// Use this for initialization
	void Start () 
	{
		flapScript = (openFlap)flaps.GetComponent(typeof(openFlap));
	}
	
	// Update is called once per frame
	void Update () 
	{
		timePassed += Time.deltaTime;
	}

	void OnGUI()
	{
		if (flapScript.isEpiglotisOpen() == true)
		{
			if (timePassed < animationDelay1)
			{
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), notBreathing[0]);
			} else if (timePassed > animationDelay1 && timePassed < animationDelay2)
			{
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), notBreathing[1]);
			} else if (timePassed > animationDelay2)
			{
				timePassed = 0f;
			}
		} else
		{
			if (timePassed < animationDelay1)
			{
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), breathing[0]);
			} else if (timePassed > animationDelay1 && timePassed < animationDelay2)
			{
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), breathing[1]);
			} else if (timePassed > animationDelay2)
			{
				timePassed = 0f;
			}
		}
	}
}
