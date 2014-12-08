using UnityEngine;
using System.Collections;

public class StomachGameManager : MonoBehaviour 
{
	private CellManager cellManager;
	private StomachFoodManager foodManager;
	private EnzymeManager enzymeManager;

	private string currentAcidLevel = "neutral";
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
		/**
		 * Always do this update
		 */
		for (int i = 0; i < nextCellActionTimer.Length; i++)
		{
			elapsedTime[i] += Time.deltaTime;
		}

		/**
		 * Adjust each cell based on cell state and acidic level
		 */
		for (int i = 0; i < cellManager.cellScripts.Length; i++)
		{
			if (getCurrentAcidLevel() == "neutral")
			{
				cellManager.cellScripts[i].setCellState("normal");
				elapsedTime[i] = 0f;
				continue;
			}

			if (getCurrentAcidLevel() == "acidic")
			{
				// if the cell has been burning for too long it dies
				if (cellManager.cellScripts[i].getCellState() == "burning" && elapsedTime[i] >= actionTime)
				{
					cellManager.cellScripts[i].setCellState("dead");
				}

				
				if (cellManager.cellScripts[i].getCellState() == "slimed")
				{
					continue;
				}

				if (cellManager.cellScripts[i].getCellState() != "burning")
				{
					cellManager.cellScripts[i].setCellState("burning");
					nextCellActionTimer[i] = 0f;	
				}
			}

			if (getCurrentAcidLevel() == "basic")
			{
			}
		}
	}

	public void setCurrentAcidLevel(string currentAcidLevel)
	{
		this.currentAcidLevel = currentAcidLevel;
	}

	public string getCurrentAcidLevel()
	{
		return currentAcidLevel;
	}
}
