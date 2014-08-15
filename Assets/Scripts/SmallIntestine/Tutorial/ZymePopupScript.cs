using UnityEngine;
using System.Collections;

public class ZymePopupScript : MonoBehaviour 
{
	// texture and value for drawing zyme properly
	public Texture zyme;
	float ratio = 1.4250681198910081743869209809264f;

	// for the button
	public GUIStyle gotIt;

	// set the text for zyme
	private string currentZymeText;

	// booleans
	private bool drawZyme;
	private bool drawButton;
	private bool buttonPressed;

	// for fonts
	public GUIStyle style;

	// Use this for initialization
	void Start () 
	{
		style.fontSize = (int)(18f / 597f * Screen.height);  // set font relative to screen 
		gotIt.fontSize = (int)(20f / 597f * Screen.height);	 // set font relative to screen
	}
	
	// Update is called once per frame
	void Update () {}

	public void setText(string text)
	{
		currentZymeText = text;
	}

	public void setDraw(bool draw)
	{
		drawZyme = draw;
	}

	public void setShowButton(bool show)
	{
		drawButton = show;
	}

	public bool getButtonPressed()
	{
		bool temp = buttonPressed;
		buttonPressed = false;
		return temp;
	}

	void OnGUI()
	{
		if (drawZyme)
		{
			GUI.DrawTexture(new Rect(Screen.width - (.4f * Screen.height * ratio), 
			                         (Screen.height * 0.82421875f) - (.4f * Screen.height),
			                         (.4f * Screen.height * ratio),
			                         (.4f * Screen.height)), zyme);
			GUI.Label(new Rect(.58f*Screen.width, .42f*Screen.height, .8f*Screen.width, .8f*Screen.height),
			          currentZymeText,
			          style);

			if(drawButton)
			{
				if (GUI.Button(new Rect(Screen.width - (.5112f * Screen.height), 
				                        (Screen.height * 0.82421875f) - (.15f * Screen.height),
				                        (.12f * Screen.width),
				                        (.1f * Screen.height)), "Got it!", gotIt))
				{
					buttonPressed = true;
					drawButton = false;
				}
			}
		}
	}
}
