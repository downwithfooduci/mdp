using UnityEngine;
using System.Collections;

public class MainCell : MonoBehaviour 
{
	private StomachCell mainCellScript;		//!< main cell script to use for state changes

	public Texture[] cellFaces;
	private Rect cellFaceRegion;

	private CellButtons menu;

	// Use this for initialization
	void Start () 
	{
		mainCellScript = gameObject.GetComponent<StomachCell> ();

		menu = gameObject.GetComponent<CellButtons>();

		cellFaceRegion = new Rect (.40f * Screen.width, .10f * Screen.height, .25f * Screen.width, .25f * Screen.height);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		GUI.depth = GUI.depth - 10;

		switch(mainCellScript.getCellState())
		{
			case "normal":
			{
				GUI.DrawTexture(cellFaceRegion, cellFaces[3]);
				break;
			}
			case "slimed":
			{
				GUI.DrawTexture(cellFaceRegion, cellFaces[3]);
				break;
			}
			case "burning":
			{
				GUI.DrawTexture(cellFaceRegion, cellFaces[1]);
				break;
			}
			case "dead":
			{
				GUI.DrawTexture(cellFaceRegion, cellFaces[2]);
				break;
			}
			case "questioning":
			{
				GUI.DrawTexture(cellFaceRegion, cellFaces[4]);
				break;
			}
			case "blinking":
			{
				GUI.DrawTexture(cellFaceRegion, cellFaces[0]);
				break;
			}
			case "sleeping":
			{
				GUI.DrawTexture(cellFaceRegion, cellFaces[5]);
				break;
			}
			default:
			{
				break;
			}
		}
	}
}
