using UnityEngine;
using System.Collections;

// script that handles drawing the bottom bar (without any overlays) in the si game
public class DrawBottomSIBar : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		// set the pixel inset relative to screen size
		guiTexture.pixelInset = new Rect(0, 0, Screen.width, Screen.height * 0.17578125f);
	}
	
	// Update is called once per frame
	void Update () {}
}
