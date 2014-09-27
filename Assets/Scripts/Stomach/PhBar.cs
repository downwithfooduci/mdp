using UnityEngine;
using System.Collections;

// script that controls drawing the phBar and level indicators for the stomach game
public class PhBar : MonoBehaviour 
{
	public Texture phBarTexture;					// to hold the texture of the ph bar
	public Texture desiredAcidLevelIndicator;		// to hold the texture of the arrows marking the ph level we should reach
	public Texture currentAcidLevelIndicator;		// to hold the bar that should line up with the arrows

	private Rect phBarRect;							// to hold the draw location and size data for the ph Bar
	private Rect desiredLevelRect;					// to hold the draw location and size data for the desired level arrows
	private Rect currentLevelRect;					// to hold the draw location and size data for the current level bar4
	private float currentLevelRectHeight;			// store a random starting height for the currentLevelRect

	public float startingAcidSpeed;				// the speed the bar initially moves when acid is added
	public float acidSpeedDecayTime;			// the time for the bar to slow to 0 after acid is added
	
	public float startingBaseSpeed;				// the speed the bar initially moves when base is added
	public float baseSpeedDecayTime;			// the time for the bar to slow to 0 after base is added

	private bool startAddAcid;						// flag to mark whether we are currently adding acid
	private bool startAddBase;						// flag to mark whether we are currently adding base
	private float elapsedTime;						// to count the time spent adding acid or base for velocity vector

	// Use this for initialization
	void Start () 
	{
		// create the rectangle for the phBar relative to the screen size
		phBarRect = new Rect (33f / 1024f * Screen.width, 44f / 768f * Screen.height, 
		                      116f / 1024f * Screen.width, 632f / 768f * Screen.height);

		// create the rectangle for the desired level indicator relative to the screen size
		desiredLevelRect = new Rect (12f / 1024f * Screen.width, 301f / 768f * Screen.height,
		                             158f / 1024f * Screen.width, 50f / 768f * Screen.height);

		// starting level of the current level indicator
		// right now just start it at a random height...
		while (currentLevelRectHeight == 0 || (currentLevelRectHeight > 300 && currentLevelRectHeight < 351))
		{
			currentLevelRectHeight = Random.Range (56f, 658f);
		}
		currentLevelRect = new Rect (47f / 1024f * Screen.width, currentLevelRectHeight / 768f * Screen.height,
		                            90f / 1024f * Screen.width, 7f / 768f * Screen.height);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// first check if the time that the acid/base should be added is up
		if (elapsedTime > acidSpeedDecayTime && startAddAcid)			// check if we're adding acid and time is up
		{																// if it is...
			startAddAcid = false;										// set the flag to indicate we aren't adding acid
			elapsedTime = 0f;											// reset the elapsed timer
			return;
		} else if (elapsedTime > baseSpeedDecayTime && startAddBase)	// check if we're adding base and the time is up
		{																// if it is...
			startAddBase = false;										// set the flag to indicate we aren't adding base
			elapsedTime = 0f;											// reset the elapsed timer
			return;
		}

		// check if we are currently adding acid
		if (startAddAcid)
		{
			// increment the timer
			elapsedTime += Time.deltaTime;

			// set the new destination the current acid level indicator should be drawn at
			// it should move at a decreasing speed so to do so we multiply the desired speed by the percentage of time
			// that is left to move the indicator line
			moveCurrentLevelRect(startingAcidSpeed * ( 1 - (elapsedTime / acidSpeedDecayTime)));

			return;
		}

		// check if we are currently adding base
		if (startAddBase)
		{
			// increment the timer
			elapsedTime += Time.deltaTime;

			// set the new destination the current base level indicator should be drawn at
			// it should move at a decreasing speed so to do so we multiply the desired speed by the percentage of time
			// that is left to move the indicator line
			moveCurrentLevelRect(startingBaseSpeed * ( 1 - (elapsedTime / baseSpeedDecayTime)));
			
			return;
		}
	}

	void OnGUI()
	{
		// draw the ph bar
		GUI.DrawTexture (phBarRect, phBarTexture);

		// draw the desired level indicator
		GUI.DrawTexture (desiredLevelRect, desiredAcidLevelIndicator);

		// draw the current level indicator
		GUI.DrawTexture (currentLevelRect, currentAcidLevelIndicator);
	}

	private void moveCurrentLevelRect(float speed)
	{
		//Mathf.Clamp(currentLevelRect.y + (speed * Time.deltaTime), 56f, 648f)
		currentLevelRect = new Rect (currentLevelRect.x, 
		                             Mathf.Clamp(currentLevelRect.y + (speed * Time.deltaTime), 
		            					56f / 768f * Screen.height, 
		            					658f / 768f * Screen.height), 
		                            currentLevelRect.width, currentLevelRect.height);
	}

	// function that can be called to simulate adding acid to the stomach and its effect on the ph bar
	public void addAcid()
	{
		startAddAcid = true;		// throw the flag to indicate we should start adding acid
		startAddBase = false;		// if we were adding base, override the decision (no longer add base)
		elapsedTime = 0f;			// reset elapsed time
	}

	// function that can be called to simulate adding base to the stomach and its effect on the ph bar
	public void addBase()
	{
		startAddBase = true;		// throw the flag to indicate that we should start adding base
		startAddAcid = false;		// if we were adding acid, override the decision (no longer add acid)
		elapsedTime = 0f;			// reset elapsed time
	}
}
