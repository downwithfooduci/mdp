using UnityEngine;
using System.Collections;

public class StomachEnzyme : MonoBehaviour 
{
	public Texture activatedTexture;			// to hold the texture of an activated cell
	public Texture deactivatedTexture;			// to hold the texture of a deactivated cell

	private Rect cellRect;						// to hold the location of where to draw the cell
	private bool isActivated;					// to mark whether a cell is activated

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	void OnGUI()
	{
		// draw the activated or deactivated texture at the set location
		if (isActivated)
		{
			GUI.DrawTexture(cellRect, activatedTexture);
		} else
		{
			GUI.DrawTexture(cellRect, deactivatedTexture);
		}
	}

	// function that can be called to set the location to draw the stomach cell
	public void setDrawLocation(float x, float y)
	{
		// set the draw rectangle for the cell relative to screen size
		cellRect = new Rect (x / 1024f * Screen.width, y / 1024f * Screen.height, 
		                     194f / 1024f * Screen.width, 159f / 768f * Screen.height);
	}

	// function to set the marker of whether or not the cell is currently activated
	public void setActivated(bool activated)
	{
		isActivated = activated;
	}
}
