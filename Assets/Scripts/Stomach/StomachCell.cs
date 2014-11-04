using UnityEngine;
using System.Collections;

public class StomachCell : MonoBehaviour 
{
	public Texture[] cellStateImages;
	
	private string cellState = "burning";

	private Rect cellRect;

	// Use this for initialization
	void Start () 
	{
		cellRect = getRect ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Rect getRect()
	{
		return new Rect ();
	}
	
	public string getCellState()
	{
		return cellState;
	}

	void OnGUI()
	{
		GUI.depth = GUI.depth--;

		switch (getCellState ()) 
		{
			case ("normal"):
			{
				break;
			}
			case ("blinking"):
			{
				break;
			}
			case ("slimed"):
			{
			GUI.DrawTexture (cellRect, cellStateImages [1]);
				break;
			}
			case ("burning"):
			{
			GUI.DrawTexture (cellRect, cellStateImages [0]);
				break;
			}
			case ("dead"):
			{
			GUI.DrawTexture (cellRect, cellStateImages [2]);
				break;
			}
			case ("question"):
			{
				break;
			}
			case ("sleeping"):
			{
				break;
			}
			default:
			{
				break;
			}
		}
	}
}
