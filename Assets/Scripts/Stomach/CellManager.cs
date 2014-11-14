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
	private Rect[] rectangles;

	// Use this for initialization
	void Start () 
	{
		cellScripts = new StomachCell[cells.Length];
		rectangles = new Rect[cells.Length];

		// get the scripts on each of the cells
		for (int i = 0; i < cells.Length; i++)
		{
			cells[i] = (GameObject)Instantiate (cells[i]);
			cellScripts[i] = cells[i].GetComponent<StomachCell>();
		}

		generateRegions ();
	}

	void generateRegions()
	{
		cell1Region = new Rect (0f, 0f, .358f * Screen.width, .551f * Screen.height);
		cell2Region = new Rect (.319f * Screen.width, 0f, .438f * Screen.width, .521f * Screen.height);
		cell3Region = new Rect (.686f * Screen.width, 0f, .324f * Screen.width, .560f * Screen.height);
		cell4Region = new Rect (0f, .450f * Screen.height, .235f * Screen.width, .557f * Screen.height);
		cell5Region = new Rect (.205f * Screen.width, .445f * Screen.height, .4f * Screen.width, .557f * Screen.height);
		cell6Region = new Rect (.615f * Screen.width, .443f * Screen.height, .384f * Screen.width, .557f * Screen.height);

		rectangles [0] = cell1Region;
		rectangles [1] = cell2Region;
		rectangles [2] = cell3Region;
		rectangles [3] = cell4Region;
		rectangles [4] = cell5Region;
		rectangles [5] = cell6Region;
	}

	public void checkForClicks (Vector2 v, string state)
	{
		for (int i = 0; i < rectangles.Length; i++)
		{ 
			if (rectangles[i].Contains(v))
			{
				cellScripts[i].setCellState(state);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
	}
}
