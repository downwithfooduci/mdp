using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StomachEnzyme : MonoBehaviour 
{
	private Image i;
	public Sprite activatedTexture;			// to hold the texture of an activated cell
	public Sprite deactivatedTexture;			// to hold the texture of a deactivated cell

	public StomachTextBoxes textboxes;

	private StomachGameManager gm;

	// Use this for initialization
	void Start () 
	{
		i = GetComponent<Image> ();
		gm = FindObjectOfType (typeof(StomachGameManager)) as StomachGameManager;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gm.getCurrentAcidLevel() == "acidic")
		{
			i.sprite = activatedTexture;
		} else
		{
			i.sprite = deactivatedTexture;
		}
	}

	public void clickOnEnzyme()
	{
		if (gm.getCurrentAcidLevel() != "acidic")
		{
			textboxes.setTextbox(5);
		}
	}
}
