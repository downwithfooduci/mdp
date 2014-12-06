using UnityEngine;
using System.Collections;

public class StomachCell : MonoBehaviour 
{
	private SpriteRenderer sr;

	public Sprite[] cellStateImages;

	private string cellState = "burning";

	void Start()
	{
		sr = GetComponent<SpriteRenderer> ();
	}

	void Update()
	{
		if (cellState == "normal")
		{
			sr.sprite = null;
		}

		if (cellState == "slimed")
		{
			sr.sprite = cellStateImages[0];
		}

		if (cellState == "burning")
		{
			sr.sprite = cellStateImages[1];
		}

		if (cellState == "dead")
		{
			sr.sprite = cellStateImages[2];
		}
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
}