using UnityEngine;
using System.Collections;

public class LostNutrientsTutorial : MonoBehaviour 
{
	// for zyme
	public GameObject zyme;
	private ZymePopupScript zymeScript;
	
	public Texture zymePopupImage;

	private bool showTutorial = false;
	public Texture circle;

	// Use this for initialization
	void Start () 
	{
		zymeScript = ((GameObject)Instantiate(zyme)).GetComponent<ZymePopupScript> ();
		showTutorial = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (zymeScript.getButtonPressed())
		{
			showTutorial = false;
			zymeScript.setDraw(false);
			Time.timeScale = 1.0f;
		}
	}

	void OnGUI()
	{
		if (showTutorial) 
		{
			zymeScript.setDrawZymeLeft ();
			zymeScript.setImage (zymePopupImage);
			zymeScript.setDraw(true);
			zymeScript.setShowButton (true);
			Time.timeScale = .01f;

			GUI.DrawTexture(new Rect(.84f * Screen.width, .82f * Screen.height, .16f*Screen.width, .17f * Screen.height), circle);
		}
	}
}
