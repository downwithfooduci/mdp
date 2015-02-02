using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Handles drawing the zyme avatar with the proper graphic based on what is going on in the game
 */
public class StomachZyme : MonoBehaviour 
{
	private Image i;

	public Sprite zymeHappy;					//!< holds the texture that will be drawn for happy zyme
	public Sprite zymeConcerned;				//!< holds the texture that will be drawn for concerned zyme
	public Sprite zymeSlimed;					//!< holds the texture that will be drawn for slimed zyme

	private bool drawHappyZyme = true;			//!< flag to indicate we should draw happy zyme
	private bool drawConcernedZyme = false;		//!< flag to indicate we should draw concerned zyme
	private bool drawSlimedZyme = false;		//!< flag to indicate we should draw slimed zyme

	public StomachTextBoxes stomachTextBoxes;
	private StomachGameManager gm;
	public PhBar phbar;

	private int timesCodeReachedTB11;			//!< needed for changing zyme image and textbox display for certain cases...
	private int timesCodeReachedTB8;
	
	void Start () 
	{
		i = GetComponent<Image> ();
		gm = FindObjectOfType (typeof(StomachGameManager)) as StomachGameManager;
	}

	void Update()
	{
		// all below code just handles which zyme to draw
		if (drawHappyZyme)
		{
			i.sprite = zymeHappy;
			drawConcernedZyme = false;
			drawSlimedZyme = false;
		}

		if (drawConcernedZyme)
		{
			i.sprite = zymeConcerned;
			drawHappyZyme = false;
			drawSlimedZyme = false;
		}

		if (drawSlimedZyme)
		{
			i.sprite = zymeSlimed;
			drawHappyZyme = false;
			drawConcernedZyme = false;
		}
	}

	/**
	 * Accessor function so we can change to happy zyme from other scripts
	 * if necessary
	 */
	public void setDrawHappyZyme()
	{
		drawHappyZyme = true;
		drawConcernedZyme = false;
		drawSlimedZyme = false;
	}

	/**
	 * Accessor function so we can change to concerned zyme from other scripts
	 * if necessary
	 */
	public void setDrawConcernedZyme()
	{
		drawHappyZyme = false;
		drawConcernedZyme = true;
		drawSlimedZyme = false;
	}

	/**
	 * Accessor function so we can change to slimed zyme from other scripts
	 * if necessary
	 */
	public void setDrawSlimedZyme()
	{
		drawHappyZyme = false;
		drawConcernedZyme = false;
		drawSlimedZyme = true;
	}

	/**
	 * complex logic for which textbox to show for zyme's speech based
	 * on game conditions...
	 */
	public void clickOnZyme()
	{
		// first check if any cells are slimed
		bool cellSlimed = false;

		for (int i = 0; i < gm.cellManager.cellScripts.Length; i++)
		{
			if (gm.cellManager.cellScripts[i].getCellState() == "slimed")
			{
				cellSlimed = true;
				break;
			}
		}

		// next check if any cells are burning
		bool cellBurning = false;

		for (int i = 0; i < gm.cellManager.cellScripts.Length; i++)
		{
			if (gm.cellManager.cellScripts[i].getCellState() == "burning")
			{
				cellBurning = true;
				break;
			}
		}

		// let burning messages take priority so show them first
		if ((cellBurning || !cellSlimed) && gm.getCurrentAcidLevel() == "acidic")
		{
			timesCodeReachedTB8++;
			
			/**
			 * Stomach is acidic but cell is not slimed
			 */
			if (timesCodeReachedTB8 == 1)
			{
				stomachTextBoxes.setTextbox(8);
				return;
			} else
			{
				stomachTextBoxes.setTextbox(9);
				return;
			}
		}

		// if nothing is burning then hire slimed/other cases
		if (gm.getCurrentAcidLevel() == "neutral" && !cellSlimed)
		{
			/**
			 * Stomach is not acidic and cell is not slimed
			 */
			stomachTextBoxes.setTextbox (6);
			return;
		} else if ((gm.getCurrentAcidLevel() == "neutral" || gm.getCurrentAcidLevel() == "basic") 
		           && cellSlimed)
		{
			timesCodeReachedTB11++;
			/**
			 * Stomach is slimed but the acidity has not been raised
			 */
			if (timesCodeReachedTB11 == 1)
			{
				stomachTextBoxes.setTextbox(11);
				return;
			} else if (timesCodeReachedTB11 == 2)
			{
				setDrawSlimedZyme();
				return;
			} else if (timesCodeReachedTB11 == 3)
			{
				stomachTextBoxes.setTextbox(12);
				return;
			}
		} else if (gm.getCurrentAcidLevel() == "acidic")
		{
			/**
			 * Stomach is acidic and some cells are slimed
			 */
			stomachTextBoxes.setTextbox(13);
			return;
		}
	}
}
