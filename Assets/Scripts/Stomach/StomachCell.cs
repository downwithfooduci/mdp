using UnityEngine;
using System.Collections;

public class StomachCell : MonoBehaviour 
{
	public Texture[] cellStateImages;

	private string cellState = "normal";

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
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
		switch(cellState)
		{
		case "normal":
		{
			break;
		}
		case "slimed":
		{
			break;
		}
		case "burning":
		{
			break;
		}
		case "dead":
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