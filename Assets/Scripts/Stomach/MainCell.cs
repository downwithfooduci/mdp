using UnityEngine;
using System.Collections;

public class MainCell : MonoBehaviour 
{
	private StomachCell mainCellScript;		//!< main cell script to use for state changes

	public Texture[] cellFaces;
	private CellButtons menu;

	// Use this for initialization
	void Start () 
	{
		mainCellScript = gameObject.GetComponent<StomachCell> ();

		menu = new CellButtons ();
		menu.initializeMenu ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		switch(mainCellScript.getCellState())
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
		case "questioning":
		{
			break;
		}
		case "blinking":
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
