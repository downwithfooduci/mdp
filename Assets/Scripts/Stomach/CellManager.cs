using UnityEngine;
using System.Collections;

public class CellManager : MonoBehaviour 
{
	public GameObject[] cells;
	public StomachCell[] cellScripts;

	private Rect cell1Region;
	private Rect cell2Region;
	private Rect cell3Region;
	private Rect cell4Region;
	private Rect cell5Region;
	private Rect cell6Region;

	// Use this for initialization
	void Start () 
	{
		cellScripts = new StomachCell[cells.Length];

		// get the scripts on each of the cells
		for (int i = 0; i < cells.Length; i++)
		{
			cells[i] = (GameObject)Instantiate (cells[i]);
			cellScripts[i] = cells[i].GetComponent<StomachCell>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
	}
}
