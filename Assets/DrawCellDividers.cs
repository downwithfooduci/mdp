using UnityEngine;
using System.Collections;

public class DrawCellDividers : MonoBehaviour 
{
	public Texture cellDividers;

	void OnGUI()
	{
		GUI.depth = GUI.depth - 1;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), cellDividers);
	}
}
