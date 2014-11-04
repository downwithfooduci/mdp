using UnityEngine;
using System.Collections;

public class StomachCell : MonoBehaviour 
{
	public Texture[] cellStateImages;

	private string cellState = "burning";
	private string cellName;
	private Rect drawRegion;

	// Use this for initialization
	void Start () 
	{
		// find which cell this is on
		cellName = transform.gameObject.name;
		cellName = cellName.Substring (cellName.Length - 9, 2);

		// set the correct draw region for this cell
		setDrawRegion ();
	}

	void setDrawRegion()
	{
		switch(cellName)
		{
			case "01":
			{
				// upper left cell
				drawRegion = new Rect(0f, 0f, .356f * Screen.width, .551f * Screen.height);
				break;
			}
			case "02":
			{
				// upper middle cell
				drawRegion = new Rect(.319f * Screen.width, 0f, .438f * Screen.width, .521f * Screen.height);
				break;
			}
			case "03":
			{
				// upper right cell
				drawRegion = new Rect(.676f * Screen.width, 0f, .324f * Screen.width, .573f * Screen.height);
				break;
			}
			case "04":
			{
				// lower left cell
				drawRegion = new Rect(0f, .573f * Screen.height, .249f * Screen.width, .557f * Screen.height);
				break;
			}
			case "05":
			{
				// lower middle cell
				drawRegion = new Rect(.205f * Screen.width, .445f * Screen.height, .435f * Screen.width, .557f * Screen.height);
				break;
			}
			case "06":
			{
				// lower right cell
				drawRegion = new Rect(.601f * Screen.width, .443f * Screen.height, .399f * Screen.width, .557f * Screen.height);
				break;
			}
			default:
			{
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	/**
	 * Allows outside classes to alter the cell state based on events
	 */
	public void setCellState(string newState)
	{
		cellState = newState;
	}

	/**
	 * To return the currect state of the cell 
	 */
	public string getCellState()
	{
		return cellState;
	}

	void OnGUI()
	{
		GUI.depth = GUI.depth - 1;

		switch(cellState)
		{
			case "normal":
			{
				break;
			}
			case "slimed":
			{
				GUI.DrawTexture(drawRegion, cellStateImages[1]);
				break;
			}
			case "burning":
			{
				GUI.DrawTexture(drawRegion, cellStateImages[0]);
				break;
			}
			case "dead":
			{
				GUI.DrawTexture(drawRegion, cellStateImages[2]);
				break;
			}
			default:
			{
				break;
			}
		}
	}
}