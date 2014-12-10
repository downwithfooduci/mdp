using UnityEngine;
using System.Collections;

public class StomachGameManager : MonoBehaviour 
{
	// values that shouldn't normally be changed during game play
	public float TIME_TO_BURN;
	public float TIME_TO_DIE;
	public float TIME_FOR_SLIME_FADE;
	public float TIME_TO_REVIVE;
	public int MAX_CELL_DEATHS;

	private int cellDeaths;

	private CellManager cellManager;
	private StomachFoodManager foodManager;

	private string currentAcidLevel = "neutral";
	private float[] elapsedTime;
	private float[] nextCellActionTime;

	// Use this for initialization
	void Start () 
	{
		cellManager = FindObjectOfType(typeof(CellManager)) as CellManager;
		foodManager = FindObjectOfType (typeof(StomachFoodManager)) as StomachFoodManager;

		elapsedTime = new float[cellManager.cellScripts.Length];
		nextCellActionTime = new float[cellManager.cellScripts.Length];

		for (int i = 0; i < cellManager.cellScripts.Length; i++)
		{
			nextCellActionTime[i] = Mathf.Infinity;
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
			/**
			 * Need to handle all possible cases if the acid level is neutral or basic
			 */
			if (getCurrentAcidLevel() == "neutral" ||
			    getCurrentAcidLevel() == "basic")
			{
				if (cellManager.cellScripts[i].getCellState() == "dead")
				{
					if (elapsedTime[i] >= nextCellActionTime[i])
					{
						cellManager.cellScripts[i].setCellState("normal");
						nextCellActionTime[i] = TIME_TO_BURN;
						elapsedTime[i] = 0f;
					}
					continue;
				}

				if (cellManager.cellScripts[i].getCellState() == "slimed")
				{
					nextCellActionTime[i] = TIME_FOR_SLIME_FADE;
					elapsedTime[i] = 0f;
					continue;
				}

				cellManager.cellScripts[i].setCellState("normal");
				nextCellActionTime[i] = TIME_TO_BURN;
				elapsedTime[i] = 0f;
				continue;
			}

			if (getCurrentAcidLevel() == "acidic")
			{
				if (cellManager.cellScripts[i].getCellState() == "dead")
				{
					if (elapsedTime[i] >= nextCellActionTime[i])
					{
						cellManager.cellScripts[i].setCellState("normal");
						nextCellActionTime[i] = TIME_TO_BURN;
						elapsedTime[i] = 0f;
					}
					continue;
				}

				// if the cell has been burning for too long it dies
				if (cellManager.cellScripts[i].getCellState() == "burning")
				{
					if (elapsedTime[i] >= nextCellActionTime[i])
					{
						cellManager.cellScripts[i].setCellState("dead");
						cellDeaths++;
						nextCellActionTime[i] = TIME_TO_REVIVE;
						elapsedTime[i] = 0f;
					}
					continue;
				}

				if (cellManager.cellScripts[i].getCellState() == "slimed")
				{
					if (elapsedTime[i] >= nextCellActionTime[i])
					{
						cellManager.cellScripts[i].setCellState("burning");
						nextCellActionTime[i] = TIME_TO_DIE;
						elapsedTime[i] = 0f;
					}
					continue;
				}

				if (cellManager.cellScripts[i].getCellState() == "normal")
				{
					if (elapsedTime[i] >= nextCellActionTime[i])
					{
						cellManager.cellScripts[i].setCellState("burning");
						nextCellActionTime[i] = TIME_TO_DIE;
						elapsedTime[i] = 0f;
					}
					continue;
				}
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
