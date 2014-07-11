using UnityEngine;
using System.Collections;

public class DrawBottomSIBar : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		guiTexture.pixelInset = new Rect(0, 0, Screen.width, Screen.height * 0.17578125f);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
