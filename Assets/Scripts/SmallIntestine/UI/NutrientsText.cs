using UnityEngine;
using System.Collections;

// script that handles drawing the nutrients text and score in the si game
public class NutrientsText : MonoBehaviour 
{
	private int nutrients;			// to hold the score
	private Color color;			// for the font color

	// for green fading
	private Color originalColor;	// for the original font color

	// Use this for initialization
	void Start () 
	{
		// set the font size relative to the screen size
		guiText.fontSize = (int)(Screen.width * .02f) + 1;	
		// set the pixel offset relative to the screen size
		guiText.pixelOffset = new Vector2 (.487f * Screen.height, .128f * Screen.width);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		guiText.color = color;					// set the text color to the desired color

		if (!color.Equals(originalColor))		// check if the desired color is the original color and if it's not...
		{
			color = Color.Lerp(color, originalColor, Time.deltaTime);	// fade the color from this color to the original color
		}

		guiText.text = "NUTRIENTS: " + nutrients;	// what we want printed to the screen
	}

	// function that can be called to sett the desired score text and and desired font color
	public void updateText(int nutrients, Color color)
	{
		this.nutrients = nutrients;
		this.color = color;
	}

	// function that can be called to change the original color so we can change the look of the color fading
	public void setOriginalColor(Color color)
	{
		originalColor = color;
	}
}
