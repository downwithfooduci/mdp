using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainCell : MonoBehaviour 
{
	private StomachCell mainCellScript;		//!< main cell script to use for state changes
	public Image face;
	public Sprite[] cellFaces;

	// Use this for initialization
	void Start () 
	{
		mainCellScript = gameObject.GetComponent<StomachCell> ();
	}

	void Update()
	{
		switch(mainCellScript.getCellState())
		{
			case "normal":
			{
				face.sprite = cellFaces[3];
				break;
			}
			case "slimed":
			{
				face.sprite = cellFaces[3];
				break;
			}
			case "burning":
			{
				face.sprite = cellFaces[1];
				break;
			}
			case "dead":
			{
				face.sprite = cellFaces[2];
				break;
			}
			case "questioning":
			{
				face.sprite = cellFaces[4];
				break;
			}
			case "blinking":
			{
				face.sprite = cellFaces[0];
				break;
			}
			case "sleeping":
			{
				face.sprite = cellFaces[4];
				break;
			}
			default:
			{
				break;
			}
		}
	}
}
