using UnityEngine;
using System.Collections;

public class StomachGameManager : MonoBehaviour 
{
	private CellManager cellManager;
	private StomachFoodManager foodManager;

	private string currentAcidLevel = "neutral";
	private float[] elapsedTime;
	public float actionTime;

	// Use this for initialization
	void Start () 
	{
		cellManager = FindObjectOfType(typeof(CellManager)) as CellManager;
		foodManager = FindObjectOfType (typeof(StomachFoodManager)) as StomachFoodManager;

		elapsedTime = new float[cellManager.cellScripts.Length];
		for (int i = 0; i < cellManager.cellScripts.Length; i++)
		{
			elapsedTime[i] = 0f;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		/**
		 * Always do this update
		 */
		for (int i = 0; i < cellManager.cellScripts.Length; i++)
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
					elapsedTime[i] = 0f;
					continue;
				}

				if (cellManager.cellScripts[i].getCellState() == "slimed")
				{
					if (elapsedTime[i] >= actionTime)
					{
						cellManager.cellScripts[i].setCellState("burning");
						elapsedTime[i] = 0f;
					}
					continue;
				}

				if (cellManager.cellScripts[i].getCellState() != "burning")
				{
					cellManager.cellScripts[i].setCellState("burning");
					elapsedTime[i] = 0f;
					continue;
				}
			}

			if (getCurrentAcidLevel() == "basic")
			{
				cellManager.cellScripts[i].setCellState("normal");
				elapsedTime[i] = 0f;
				continue;
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
