using UnityEngine;
using System.Collections;

/**
 * Handles drawing the zyme avatar with the proper graphic based on what is going on in the game
 */
public class StomachZyme : MonoBehaviour 
{
	private SpriteRenderer sr;

	public Sprite zymeHappy;					//!< holds the texture that will be drawn for happy zyme
	public Sprite zymeConcerned;				//!< holds the texture that will be drawn for concerned zyme
	public Sprite zymeSlimed;					//!< holds the texture that will be drawn for slimed zyme

	private bool drawHappyZyme = true;			//!< flag to indicate we should draw happy zyme
	private bool drawConcernedZyme = false;		//!< flag to indicate we should draw concerned zyme
	private bool drawSlimedZyme = false;		//!< flag to indicate we should draw slimed zyme
	
	void Start () 
	{
		sr = GetComponent<SpriteRenderer> ();

		// set the dimensions of the location to draw the zyme in the stomach game relative to screen size
		sr.sprite = zymeHappy;
	}

	void Update()
	{
		if (drawHappyZyme)
		{
			sr.sprite = zymeHappy;
			drawConcernedZyme = false;
			drawSlimedZyme = false;
		}

		if (drawConcernedZyme)
		{
			sr.sprite = zymeConcerned;
			drawHappyZyme = false;
			drawSlimedZyme = false;
		}

		if (drawSlimedZyme)
		{
			sr.sprite = zymeSlimed;
			drawHappyZyme = false;
			drawConcernedZyme = false;
		}
	}

	public void setDrawHappyZyme()
	{
		drawHappyZyme = true;
		drawConcernedZyme = false;
		drawSlimedZyme = false;
	}

	public void setDrawConcernedZyme()
	{
		drawHappyZyme = false;
		drawConcernedZyme = true;
		drawSlimedZyme = false;
	}

	public void setDrawSlimedZyme()
	{
		drawHappyZyme = false;
		drawConcernedZyme = false;
		drawSlimedZyme = true;
	}
}
