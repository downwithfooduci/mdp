using UnityEngine;
using System.Collections;

/**
 * Handles drawing the zyme avatar with the proper graphic based on what is going on in the game
 */
public class StomachZyme : MonoBehaviour 
{
	public Texture zymeHappy;					//!< holds the texture that will be drawn for happy zyme
	public Texture zymeConcerned;				//!< holds the texture that will be drawn for concerned zyme
	public Texture zymeSlimed;					//!< holds the texture that will be drawn for slimed zyme
	public Texture zymeFloatyRing;				//!< holds the texture for the pool ring that zyme stands on

	private Rect drawZymeRectangle;				//!< holds the location and size of where to draw zyme on the screen
	private Rect drawFloatyRingRectangle;		//!< holds the location and size of where to draw zyme's floaty ring on the screen

	private bool drawHappyZyme = true;			//!< flag to indicate we should draw happy zyme
	private bool drawConcernedZyme = false;		//!< flag to indicate we should draw concerned zyme
	private bool drawSlimedZyme = false;		//!< flag to indicate we should draw slimed zyme

	/**
	 * Use this for initialization
	 * Set the zyme and inner tube rectangle dimenstions relative to screen size
	 */
	void Start () 
	{
		// set the dimensions of the location to draw the zyme in the stomach game relative to screen size
		drawZymeRectangle = new Rect (277f / 1024f * Screen.width, 475f / 768f * Screen.height,
		                             168f / 1024f * Screen.width, 235f / 768f * Screen.height);

		// set the dimensions for the inner tube rectangle relative to screen size
		drawFloatyRingRectangle = new Rect (282f / 1024f * Screen.width, 688f / 768f * Screen.height,
		                                    170f / 1024f * Screen.width, 57f / 768f * Screen.height);
	}

	void OnGUI()
	{
		// draw floaty ring
		GUI.DrawTexture (drawFloatyRingRectangle, zymeFloatyRing);

		// draw the proper zyme on the screen
		if (drawHappyZyme)
		{
			GUI.DrawTexture(drawZymeRectangle, zymeHappy);
		} else if (drawConcernedZyme)
		{
			GUI.DrawTexture(drawZymeRectangle, zymeConcerned);
		} else if (drawSlimedZyme)
		{
			GUI.DrawTexture(drawZymeRectangle, zymeSlimed);
		}
	}
}
