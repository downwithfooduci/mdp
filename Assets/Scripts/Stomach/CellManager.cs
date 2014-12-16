using UnityEngine;
using System.Collections;

public class CellManager : MonoBehaviour 
{
	public GameObject[] cells;
	public StomachCell[] cellScripts;

	// Use this for initialization
	void Start () 
	{
		cellScripts = new StomachCell[6];

		// get the scripts on each of the cells
		for (int i = 0; i < 6; i++)
		{
			cellScripts[i] = cells[i].GetComponent<StomachCell>();
		}
	}

	public void clickOnCell()
	{
		Debug.Log ("akfj");
	}
}
