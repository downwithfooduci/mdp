using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainCell : MonoBehaviour 
{
	private StomachCell mainCellScript;		//!< main cell script to use for state changes
	public Image face;
	public Sprite[] cellFaces;
	public StomachTextBoxes textboxes;

	private bool wasSingClicked;
	private float elapsedTime = 0f;
	private float maxElapsedTime = 2f;

	// Use this for initialization
	void Start () 
	{
		mainCellScript = gameObject.GetComponent<StomachCell> ();
	}

	void Update()
	{
		/**
		 * Special logic for if the sing button was clicked
		 */
		if (wasSingClicked)
		{
			elapsedTime += Time.deltaTime;

			if (elapsedTime < maxElapsedTime)
			{
				face.sprite = cellFaces[0];
				return;
			} else
			{
				wasSingClicked = false;
				textboxes.setTextbox (1);
				face.sprite = cellFaces[3];
			}
		}

		/**
		 * Sets the main cell face under normal conditions
		 */
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
			default:
			{
				break;
			}
		}
	}

	/**
	 * Function called when the sing button is clicked on the
	 * main cell
	 */
	public void singClicked()
	{
		wasSingClicked = true;
		elapsedTime = 0f;
	}

	/**
	 * Function called when the die button is clicked on the
	 * main cell
	 */
	public void dieClicked()
	{
		textboxes.setTextbox (2);
	}

	/**
	 * Function called when the mucous button is clicked on the
	 * main cell
	 */
	public void mucousClicked()
	{
		textboxes.setTextbox (3);
	}
}
