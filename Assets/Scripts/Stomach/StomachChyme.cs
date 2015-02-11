using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Handles drawing the proper stomach chyme graphic based on stomach acidity level
 */
public class StomachChyme : MonoBehaviour 
{
	public float ACIDIC;
	public float BASIC;
	public RectTransform acidHeight;

	private StomachGameManager gm;
	private Image i;

	public Sprite neutralChyme;			//!< holds the texture for the chyme when stomach is "neutral"
	public Sprite acidicChyme;				//!< holds the texture for the chyme when stomach is "acidic"
	public Sprite basicChyme;				//!< holds the texture for the chyme when stomach is "basic"

	private float acidityLevel;				//!< to hold the acidity level value

	/**
	 * Use this for initialization
	 * Get a reference to the phbar
	 */
	void Start () 
	{
		i = GetComponent<Image> ();
		gm = FindObjectOfType (typeof(StomachGameManager)) as StomachGameManager;
	}
	
	/**
	 * Update is called once per frame
	 * Check for the current acidity level
	 */
	void Update () 
	{
		acidityLevel = acidHeight.anchoredPosition.y;

		if (acidityLevel > ACIDIC)
		{
			i.sprite = acidicChyme;
			gm.setCurrentAcidLevel("acidic");
		} else if (acidityLevel < ACIDIC && acidityLevel > BASIC)
		{
			i.sprite = neutralChyme;
			gm.setCurrentAcidLevel("neutral");
		} else
		{
			i.sprite = basicChyme;
			gm.setCurrentAcidLevel("basic");
		}
	}
}
