using UnityEngine;
using System.Collections;

// script that controls drawing the phBar and level indicators for the stomach game
public class PhBar : MonoBehaviour 
{
	public Texture phBarTexture;					// to hold the texture of the ph bar
	public Texture desiredAcidLevelIndicator;		// to hold the texture of the arrows marking the ph level we should reach
	public Texture currentAcidLevelIndicator;		// to hold the bar that should line up with the arrows

	private Rect phBarRect;							// to hold the draw location and size data for the ph Bar
	private Rect desiredLevelRect;					// to hold the draw location and size data for the desired level arrows
	private Rect currentLevelRect;					// to hold the draw location and size data for the current level bar

	// Use this for initialization
	void Start () 
	{
		// create the rectangle for the phBar relative to the screen size
		phBarRect = new Rect (33f/1024f * Screen.width, 44f/768f*Screen.height, 
		                      116f/1024f*Screen.width, 632f/768f*Screen.height);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		// draw the ph bar
		GUI.DrawTexture (phBarRect, phBarTexture);
	}
}
