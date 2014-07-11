using UnityEngine;
using System.Collections;

public class NutrientsText : MonoBehaviour 
{
	private int nutrients;
	private Color color;

	// for green fading
	private Color originalColor;

	// Use this for initialization
	void Start () 
	{
		guiText.fontSize = (int)(Screen.width * .02f) + 1;
		guiText.pixelOffset = new Vector2 (.487f * Screen.height, .128f * Screen.width);
	}
	
	// Update is called once per frame
	void Update () 
	{

		guiText.color = color;

		if (!color.Equals(originalColor))
		{
			color = Color.Lerp(color, originalColor, Time.deltaTime);
		}

		guiText.text = "NUTRIENTS: " + nutrients;
	}

	public void updateText(int nutrients, Color color)
	{
		this.nutrients = nutrients;
		this.color = color;
	}

	public void setOriginalColor(Color color)
	{
		originalColor = color;
	}
}
