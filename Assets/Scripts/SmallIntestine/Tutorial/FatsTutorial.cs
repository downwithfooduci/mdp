using UnityEngine;
using System.Collections;

/**
 * Tutorial stuff for fats
 */
public class FatsTutorial : MonoBehaviour 
{
	// for zyme
	public GameObject zyme;
	private ZymePopupScript zymeScript;

	public Texture zymePopupImage;

	private bool showTutorial;

	public float maxTimeSinceStart;
	private float elapsedTimeSinceStart;

	// Use this for initialization
	void Start () 
	{
		zymeScript = ((GameObject)Instantiate(zyme)).GetComponent<ZymePopupScript> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		elapsedTimeSinceStart += Time.deltaTime;

		if (zymeScript.getButtonPressed() && showTutorial)
		{
			zymeScript.setDraw(false);
			Time.timeScale = 1;
			PlayerPrefs.SetInt ("SIFatsTutorial", 0);
			PlayerPrefs.Save();
			showTutorial = false;
		}

		if (PlayerPrefs.GetInt ("SIFatsTutorial") == 1 && elapsedTimeSinceStart > maxTimeSinceStart)
		{
			showTutorial = true;
		}
	}

	void OnGUI()
	{
		if (showTutorial)
		{
			zymeScript.setDraw(true);
			zymeScript.setShowButton(true);
			zymeScript.setImage(zymePopupImage);
			Time.timeScale = .01f;
		}
	}
}
