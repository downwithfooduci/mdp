using UnityEngine;
using System.Collections;

public class StomachZyme : MonoBehaviour 
{
	public Texture zymeHappy;
	public Texture zymeConcerned;

	private Rect drawZymeRectangle;
	private bool drawHappyZyme = true;

	// Use this for initialization
	void Start () 
	{
		// set the dimensions of the location to draw the zyme in the stomach game relative to screen size
		drawZymeRectangle = new Rect (230f / 1024f * Screen.width, 460f / 768f * Screen.height,
		                             168f / 1024f * Screen.width, 235f / 768f * Screen.height);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		// draw the proper zyme on the screen
		if (drawHappyZyme)
		{
			GUI.DrawTexture(drawZymeRectangle, zymeHappy);
		} else
		{
			GUI.DrawTexture(drawZymeRectangle, zymeConcerned);
		}
	}
}
