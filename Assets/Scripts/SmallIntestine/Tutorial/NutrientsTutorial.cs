using UnityEngine;
using System.Collections;

/**
 * Tutorial stuff for nutrients
 */
public class NutrientsTutorial : MonoBehaviour 
{
	// for zyme
	public GameObject zyme;
	private ZymePopupScript zymeScript;

	public float tutorialDelay;
	private float elapsedTime;

	private bool showTutorial = false;
	private bool tutorialOver = false;

	public Texture circle;
	private bool circleDone;
	private bool showCircle;
	public Texture finger;

	// Use this for initialization
	void Start () 
	{
		zymeScript = ((GameObject)Instantiate(zyme)).GetComponent<ZymePopupScript> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!tutorialOver && PlayerPrefs.GetInt("SIStats_towersUpgraded") > 1)
		{ 
			elapsedTime += Time.deltaTime;

			if (elapsedTime > tutorialDelay)
			{
				showTutorial = true;
			}
		}

		if (zymeScript.getButtonPressed() && showTutorial)
		{
			showTutorial = false;
			zymeScript.setDraw(false);
			tutorialOver = true;
			Time.timeScale = 1;
		}

		if (tutorialOver)
		{
			PlayerPrefs.SetInt("SISpeedTutorial", 1);
			PlayerPrefs.Save();
		}
	}

	void OnGUI()
	{
		if (showTutorial)
		{
			zymeScript.setDraw(true);
			zymeScript.setShowButton(true);
			zymeScript.setText("Use nutrients to \npurchase Enzyme People!\n" +
			                   "Tap the villi to absorb \nnutrients!");
			Time.timeScale = .01f;

			// circle nutrients text
			GUI.DrawTexture(new Rect(.32f*Screen.width, .8f*Screen.height, .2f*Screen.width, .1f*Screen.height), circle);
			GUI.DrawTexture(new Rect(.2f*Screen.width, .2f*Screen.height, .25f*Screen.width, .415f*Screen.height), finger);
		}
	}
}