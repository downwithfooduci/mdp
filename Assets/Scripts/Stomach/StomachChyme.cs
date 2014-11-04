using UnityEngine;
using System.Collections;

/**
 * Handles drawing the proper stomach chyme graphic based on stomach acidity level
 */
public class StomachChyme : MonoBehaviour 
{
	public Texture neutralChyme;			//!< holds the texture for the chyme when stomach is "neutral"
	public Texture acidicChyme;				//!< holds the texture for the chyme when stomach is "acidic"
	public Texture basicChyme;				//!< holds the texture for the chyme when stomach is "basic"

	private PhBar phBar;					//!< holds a reference to the phbar script to monitor acidity level
	private float acidityLevel;				//!< to hold the acidity level value

	/**
	 * Use this for initialization
	 * Get a reference to the phbar
	 */
	void Start () 
	{
		phBar = gameObject.GetComponent<PhBar>();
	}
	
	/**
	 * Update is called once per frame
	 * Check for the current acidity level
	 */
	void Update () 
	{
		acidityLevel = phBar.getCurrentLevelRectHeight();
	}

	/** 
	 * Draw the proper chyme graphic based on the acidity level
	 */
	void OnGUI()
	{
		GUI.depth = GUI.depth - 2;

		if (acidityLevel < .270f * Screen.height)
		{
			GUI.DrawTexture(new Rect(0f, Screen.height - .2f * Screen.height, Screen.width, .2f * Screen.height), acidicChyme);
		} else if (acidityLevel > .662f * Screen.height)
		{
			GUI.DrawTexture(new Rect(0f, Screen.height - .2f * Screen.height, Screen.width, .2f * Screen.height), basicChyme);
		} else
		{
			GUI.DrawTexture(new Rect(0f, Screen.height - .2f * Screen.height, Screen.width, .2f * Screen.height), neutralChyme);
		}
	}
}
