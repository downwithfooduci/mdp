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

	public CellManager cellManager;

	private string currentAcidLevel = "neutral";
	private float[] elapsedTime;
	private float[] nextCellActionTime;
	private string[] lastCellState;

	// Use this for initialization
	void Start () 
	{
		cellManager = FindObjectOfType(typeof(CellManager)) as CellManager;

		elapsedTime = new float[cellManager.cellScripts.Length];
		nextCellActionTime = new float[cellManager.cellScripts.Length];
		lastCellState = new string[cellManager.cellScripts.Length];

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
			 * Update timer
			 */
			if (elapsedTime[i] < .1f*nextCellActionTime[i])
			{
				cellManager.cellScripts[i].setTimerImage(0);
			} else if (elapsedTime[i] < .3f*nextCellActionTime[i])
			{
				cellManager.cellScripts[i].setTimerImage(1);
			} else if (elapsedTime[i] < .5f*nextCellActionTime[i])
			{
				cellManager.cellScripts[i].setTimerImage(2);
			}else if (elapsedTime[i] < .7f*nextCellActionTime[i])
			{
				cellManager.cellScripts[i].setTimerImage(3);
			}else if (elapsedTime[i] < .9f*nextCellActionTime[i])
			{
				cellManager.cellScripts[i].setTimerImage(4);
			}

			/**
			 * Check for changes by other scripts
			 */
			if (cellManager.cellScripts[i].getCellState() == "slimed" && lastCellState[i] == "burning")
			{
				lastCellState[i] = "slimed";
				nextCellActionTime[i] = TIME_FOR_SLIME_FADE;
				elapsedTime[i] = 0f;
			}

			if (cellManager.cellScripts[i].getCellState() == "dead" && lastCellState[i] != "dead")
			{
				lastCellState[i] = "dead";
				nextCellActionTime[i] = TIME_TO_REVIVE;
				elapsedTime[i] = 0f;
			}

			/**
			 * Need to handle all possible cases if the acid level is neutral or basic
			 */
			if (getCurrentAcidLevel() == "neutral" ||
			    getCurrentAcidLevel() == "basic")
			{
				if (cellManager.cellScripts[i].getCellState() == "dead")
				{
					lastCellState[i] = "dead";
					if (elapsedTime[i] >= nextCellActionTime[i])
					{
						cellManager.cellScripts[i].setCellState("normal");
						lastCellState[i] = "normal";
						nextCellActionTime[i] = TIME_TO_BURN;
						elapsedTime[i] = 0f;
					}
					continue;
				}

				if (cellManager.cellScripts[i].getCellState() == "slimed")
				{
					lastCellState[i] = "slimed";
					nextCellActionTime[i] = TIME_FOR_SLIME_FADE;
					elapsedTime[i] = 0f;
					continue;
				}

				cellManager.cellScripts[i].setCellState("normal");
				lastCellState[i] = "normal";
				nextCellActionTime[i] = TIME_TO_BURN;
				elapsedTime[i] = 0f;
				continue;
			}

			if (getCurrentAcidLevel() == "acidic")
			{
				if (cellManager.cellScripts[i].getCellState() == "dead")
				{
					lastCellState[i] = "dead";
					if (elapsedTime[i] >= nextCellActionTime[i])
					{
						cellManager.cellScripts[i].setCellState("normal");
						lastCellState[i] = "normal";
						nextCellActionTime[i] = TIME_TO_BURN;
						elapsedTime[i] = 0f;
					}
					continue;
				}

				// if the cell has been burning for too long it dies
				if (cellManager.cellScripts[i].getCellState() == "burning")
				{
					lastCellState[i] = "burning";
					if (elapsedTime[i] >= nextCellActionTime[i])
					{
						cellManager.cellScripts[i].setCellState("dead");
						lastCellState[i] = "dead";
						cellDeaths++;
						nextCellActionTime[i] = TIME_TO_REVIVE;
						elapsedTime[i] = 0f;
					}
					continue;
				}

				if (cellManager.cellScripts[i].getCellState() == "slimed")
				{
					lastCellState[i] = "slimed";
					if (elapsedTime[i] >= nextCellActionTime[i])
					{
						cellManager.cellScripts[i].setCellState("burning");
						lastCellState[i] = "burning";
						nextCellActionTime[i] = TIME_TO_DIE;
						elapsedTime[i] = 0f;
					}
					continue;
				}

				if (cellManager.cellScripts[i].getCellState() == "normal")
				{
					lastCellState[i] = "normal";
					if (elapsedTime[i] >= nextCellActionTime[i])
					{
						cellManager.cellScripts[i].setCellState("burning");
						lastCellState[i] = "burning";
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
