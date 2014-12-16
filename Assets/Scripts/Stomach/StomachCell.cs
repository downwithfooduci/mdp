using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StomachCell : MonoBehaviour 
{
	private Image i;

	public Sprite[] cellStateImages;

	private string cellState = "normal";

	void Start()
	{
		i = GetComponent<Image> ();
	}

	void Update()
	{
		if (cellState == "normal")
		{
			i.sprite = cellStateImages[0];
		}

		if (cellState == "slimed")
		{
			i.sprite = cellStateImages[1];
		}

		if (cellState == "burning")
		{
			i.sprite = cellStateImages[2];
		}

		if (cellState == "dead")
		{
			i.sprite = cellStateImages[3];
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