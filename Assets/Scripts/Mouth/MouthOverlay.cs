using UnityEngine;
using System.Collections;

// script for layering some mouth gui elements over top of the main background
public class MouthOverlay : MonoBehaviour 
{
	public Texture mouthOverlay, sideBar;	// hold the textures for the mouth overlay and the side bar

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	void OnGUI()
	{
		// draw the texture for the mouth overlay the size of the entire screen
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), mouthOverlay);

		// draw the side bar on the right side of the screen taking up the specified space
		GUI.DrawTexture(new Rect(Screen.width * .87f, 0, Screen.width * .13f, Screen.height), sideBar);
	}
}
