using UnityEngine;
using System.Collections;

/**
 * Keep track of general cell information
 */
public class CellManager : MonoBehaviour 
{
	public GameObject[] cells;              //!< for references to all the cell game objects

    /*Everytime you change the size of cells, remember to change the size of cellScripts*/

    public StomachCell[] cellScripts;		//!< for references to all the stomach cell scripts
	public CellButtons cellButtons;			//!< for a reference to the cell buttons script

	public Texture tapFigure;				//!< image of tap fingure 
	private bool popUp;						//!< boolean value to check if the pop up should appear
	private int cellNumber;					//!< cell number of first burned cell, -1 if no one burns


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

		//initialize the values for pop up
		popUp = false;
		cellNumber = -1;
	}

	void Update()
	{
		//handle popup when the stomach wall is burning
		for(int i = 0; i < 6; i++)
		{
			StomachCell cell = cellScripts [i];
			if ((cell.getCellState () == "burning") && (cellNumber == -1)) {
				popUp = true;
				cellNumber = i; 
			}
			if (cell.getCellState () == "slimed")
				popUp = false;
		}
	}

	// display the tap popup
	void OnGUI()
	{
		if(popUp)
		{
			GUI.DrawTexture (new Rect(Screen.width * 0.125f, 
				Screen.height * 0.715f, 
				Screen.width * 0.2093359375f, 
				Screen.height * 0.300697917f),tapFigure);
		}
		//Debug.Log (cellNumber);
	}
	
	/**
	 * Function called when a cell is clicked on to get the number of the cell clicked on
	 */

	public void clickOnCell(int cellNum)
	{
		cellButtons.checkMouseClick(cellNum);
	}
    public int getCellNumber()
    {
        return cellScripts.Length;
    }
}