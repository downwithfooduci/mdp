using UnityEngine;
using System.Collections;

public class StomachEnzyme : MonoBehaviour 
{
	private SpriteRenderer sr;
	public Sprite activatedTexture;			// to hold the texture of an activated cell
	public Sprite deactivatedTexture;			// to hold the texture of a deactivated cell

	private StomachGameManager gm;

	// Use this for initialization
	void Start () 
	{
		sr = GetComponent<SpriteRenderer> ();
		gm = FindObjectOfType (typeof(StomachGameManager)) as StomachGameManager;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gm.getCurrentAcidLevel() == "acidic")
		{
			sr.sprite = activatedTexture;
		} else
		{
			sr.sprite = deactivatedTexture;
		}
	}
}
