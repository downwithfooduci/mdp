using UnityEngine;
using System.Collections;

public class DrawHealthFace : MonoBehaviour 
{
	public Texture[] faces;
	private int index;
	private Rect faceRect;

	// Use this for initialization
	void Start () 
	{
		faceRect = new Rect (Screen.width * .864f, Screen.height * 0.14f - Screen.height * 0.102864583f, Screen.width * 0.078125f, Screen.height * 0.102864583f);
		guiTexture.pixelInset = faceRect;
	}
	
	// Update is called once per frame
	void Update () 
	{
		guiTexture.texture = faces [index];
	}

	public void setFace(int index)
	{
		this.index = index;
	}
}
