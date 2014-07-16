using UnityEngine;
using System.Collections;

public class ZymePopupScript : MonoBehaviour 
{
	public Texture zyme;
	float ratio = 1.4250681198910081743869209809264f;
	private string currentZymeText;
	private bool drawZyme;

	// for fonts
	public GUIStyle style;

	// Use this for initialization
	void Start () 
	{
		style.fontSize = (int)(18f / 597f * Screen.height);  // set font relative to screen 
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
		}
	}
}
