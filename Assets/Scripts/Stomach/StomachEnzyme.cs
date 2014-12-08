using UnityEngine;
using System.Collections;

public class StomachEnzyme : MonoBehaviour 
{
	private SpriteRenderer sr;
	public Sprite activatedTexture;			// to hold the texture of an activated cell
	public Sprite deactivatedTexture;			// to hold the texture of a deactivated cell

	private StomachGameManager gm;

	private Rect cellRect;						// to hold the location of where to draw the cell
	private bool isActivated;					// to mark whether a cell is activated

	// Use this for initialization
	void Start () 
	{
		sr = GetComponent<SpriteRenderer> ();
		gm = FindObjectOfType (typeof(StomachGameManager)) as StomachGameManager;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isActivated)
		{
			sr.sprite = activatedTexture;
		} else
		{
			sr.sprite = deactivatedTexture;
		}
	}

	// function to set the marker of whether or not the cell is currently activated
	public void setActivated(bool activated)
	{
		if (gm.getCurrentAcidLevel() == "acidic")
		{
			isActivated = true;
		} else
		{
			isActivated = false;
		}
	}
}
