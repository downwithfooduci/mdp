using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Generic script that handles stomach cell behavior, relevant to any cell
 */
public class StomachCell : MonoBehaviour 
{
	private Image i;						//!< hold the reference to the image to change it
	public Image timer;						//!< to hold the current timer image
	
	public Sprite[] timers;					//!< array of timer images
	public Sprite[] cellStateImages;		//!< array of cell state images
	
	private string cellState = "normal";	//!< default cell state is normal
	private bool cellRefresh = false;

    public int CellNum;
    private mouseDrag MD;

	/**
	 * For initialization
	 */
	void Start()
	{
		// get a reference to the image
		i = GetComponent<Image> ();

        MD = FindObjectOfType(typeof(mouseDrag)) as mouseDrag;
	}
	
	/**
	 * Update... called every frame.
	 * Draws the correct cell image based on state
	 */
	void Update()
	{
		if (cellState == "normal")
		{
			i.sprite = cellStateImages[0];
			return;
		}
		
		if (cellState == "burning")
		{
			i.sprite = cellStateImages[1];
			return;
		}
		
		if (cellState == "slimed")
		{
			i.sprite = cellStateImages[2];
			return;
		}
		
		if (cellState == "dead")
		{
			i.sprite = cellStateImages[3];
			return;
		}
	}
	
	/**
	 * set the correct cell timer image for the cell
	 */
	public void setTimerImage(int index)
	{
		//if (index != 5)
						timer.sprite = timers [index];

		/*
		else
						timer.sprite = null;
		*/				
	}
	
	/**
	 * Allows outside classes to alter the cell state based on events
	 */
	public void setCellState(string newState)
	{
		if (getCellState() != "dead") {
			cellState = newState;
		}
		else
			cellState = "dead";
	}
	
	/**
	 * To return the currect state of the cell 
	 */
	public string getCellState()
	{
		return cellState;
	}

	/**
	 * Mark to refresh slime
	 */
	public void setCellRefresh(bool refresh)
	{
		cellRefresh = refresh;
	}

	/**
	 * Return whether or not we need to refresh the cell
	 */
	public bool getCellRefresh()
	{
		return cellRefresh;
	}

    void OnMouseOver()
    {
        MD.setCellNum(CellNum);
        Debug.Log(CellNum);

    }

}