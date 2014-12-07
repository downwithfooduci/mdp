using UnityEngine;
using System.Collections;

public class StomachGameManager : MonoBehaviour 
{
	private CellManager cellManager;
	private StomachFoodManager foodManager;
	private EnzymeManager enzymeManager;

	private string currentGameState = "normalstate";
	private float[] nextCellActionTimer;
	private float[] elapsedTime;
	public float actionTime;

	// Use this for initialization
	void Start () 
	{
		cellManager = FindObjectOfType(typeof(CellManager)) as CellManager;
		foodManager = FindObjectOfType (typeof(StomachFoodManager)) as StomachFoodManager;
		enzymeManager = FindObjectOfType (typeof(EnzymeManager)) as EnzymeManager;

		nextCellActionTimer = new float[cellManager.cellScripts.Length];
		elapsedTime = new float[cellManager.cellScripts.Length];
		for (int i = 0; i < cellManager.cellScripts.Length; i++)
		{
			nextCellActionTimer[i] = Mathf.Infinity;
			elapsedTime[i] = 0f;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < nextCellActionTimer.Length; i++)
		{
			elapsedTime[i] += Time.deltaTime;
			if (cellManager.cellScripts[i].getCellState() == "burning" && elapsedTime[i] >= actionTime)
			{
				cellManager.cellScripts[i].setCellState("dead");
			}
		}

		if (currentGameState == "burningstate")
		{
			for (int i = 0; i < cellManager.cellScripts.Length; i++)
			{
				if (cellManager.cellScripts[i].getCellState() != "slimed" || 
				    cellManager.cellScripts[i].getCellState() != "burning")
				{
					cellManager.cellScripts[i].setCellState("burning");
					nextCellActionTimer[i] = 0f;	
				}
			}
		}
	}
}
