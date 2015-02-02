using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Script for the stomach enzyme
 */
public class StomachEnzyme : MonoBehaviour 
{
	private Image i;							//!< reference to the image
	public Sprite activatedTexture;				//!< to hold the texture of an activated cell
	public Sprite deactivatedTexture;			//!< to hold the texture of a deactivated cell

	public StomachTextBoxes textboxes;			//!< reference to the stomach text boxes script
	private StomachGameManager gm;				//!< reference to the stomach game manager

	/**
	 * Use this for initialization
	 */
	void Start () 
	{
		// get references
		i = GetComponent<Image> ();
		gm = FindObjectOfType (typeof(StomachGameManager)) as StomachGameManager;
	}
	
	/**
	 * Update is called once per frame
	 */
	void Update () 
	{
		// Draw the proper activated or deactivated texture based on acid level
		if (gm.getCurrentAcidLevel() == "acidic")
		{
			i.sprite = activatedTexture;
		} else
		{
			i.sprite = deactivatedTexture;
		}
	}

	/**
	 * Called when the enzyme is clicked on
	 */
	private void clickOnEnzyme()
	{
		if (gm.getCurrentAcidLevel() != "acidic")
		{
			textboxes.setTextbox(5);
		}
	}
}
