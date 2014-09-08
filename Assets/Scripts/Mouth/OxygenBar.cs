using UnityEngine;
using System.Collections;

/**
 * script that handles the behavior of the oxygen bar
 */
public class OxygenBar : MonoBehaviour 
{
	private Vector2 position;					//!< variable to hold the position of the oxygenBar
	private Vector2 originalSize;				//!< variable to hold the size of the oxygenBar

	public Texture oxygenBar;					//!< to hold the texture of the oxygen bar
	public float percent;						//!< the current percentage the oxygen bar is filled (between 0 and 1)

	openFlap flap;								//!< to hold a reference to the script on the flaps
	EsophagusDebugConfig config;				//!< to hold a reference to the debug config in the mouth game

	float depletionRate = .05f;					//!< to hold the oxygen depletion rate
	float gainRate = .05f;						//!< to hold the oxygen gain rate

	/**
	 * Use this for initialization
	 * Find references, initialize variables
	 */
	void Start () 
	{
		percent = 1f;												// the oxygen bar should start off at 100%

		GameObject flaps = GameObject.Find("Flaps");				// find the flaps reference
		flap = flaps.GetComponent<openFlap>();						// get the script from the flaps

		GameObject debugger = GameObject.Find("Debugger");			// find a reference to the debugger
		config = debugger.GetComponent<EsophagusDebugConfig>();		// get the script from the debug config
	}
	
	/**
	 * Update is called once per frame
	 * Finds out if flap is open or not and updates oxygen percentage accordingly
	 */
	void Update () 
	{
		if(config.debugActive)						// check if we are using debugger values or reading from the script
		{
			depletionRate = config.oxygenDeplete;	// if necessary get the depletion rate set in the debugger
			gainRate = config.oxygenGain;			// if necessary get the gain rate set in the debugger
		}

		if(flap.isEpiglotisOpen() || flap.isCough())	// check if the flap is open or a cough is happening
		{
			percent -= depletionRate * Time.deltaTime;	// if either is the case the oxygen should decrease
		}
		else
		{
			percent += gainRate * Time.deltaTime;		// otherwise the oxygen should gain
		}

		percent = Mathf.Clamp(percent, 0, 1f);		// clamp the value between 0 and 1 so the bar doesn't over or under flow
	}

	/**
	 * Handles drawing of the oxygen bar properly
	 */
	void OnGUI()
	{
		// set the x and y position of the oxygen bar relative to screen size
		position.x = (2779f / 3072f) * Screen.width;
		position.y = (395f / 2304f) * Screen.height + (1f-percent) * (673f / 2304f) * Screen.height;

		// set the size of the oxygen bar relative to screen size
		originalSize.x = (190f / 3072f) * Screen.width;
		originalSize.y = (673f / 2304f) * Screen.height * percent; // *percent will grow or shrink the vertical size of 
																	// the bar based on oxygen level

		// draw the oxygen bar at the specified position at the specified size
		GUI.DrawTexture(new Rect(position.x, position.y, originalSize.x, originalSize.y), oxygenBar);
	}

	/**
	 * function that will allow checking what percent the oxygen bar is at
	 */
	public float getPercent()
	{
		return percent;
	}
}
