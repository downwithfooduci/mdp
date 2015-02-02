using UnityEngine;
using System.Collections;

/**
 * Keep track of general cell information
 */
public class CellManager : MonoBehaviour 
{
	public GameObject[] cells;				//!< for references to all the cell game objects
	public StomachCell[] cellScripts;		//!< for references to all the stomach cell scripts
	public CellButtons cellButtons;			//!< for a reference to the cell buttons script

	/**
	 * Use this for initialization
	 */
	void Start () 
	{
		// initialize the script array
		cellScripts = new StomachCell[6];

		// get the scripts on each of the cells
		for (int i = 0; i < 6; i++)
		{
			cellScripts[i] = cells[i].GetComponent<StomachCell>();
		}
	}

	/**
	 * Function called when a cell is clicked on to get the number of the cell clicked on
	 */
	public void clickOnCell(int cellNum)
	{
		cellButtons.checkMouseClick(cellNum);
	}
}
