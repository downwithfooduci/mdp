using UnityEngine;
using System.Collections;

public class NutrientsTutorial : MonoBehaviour 
{
	// for zyme
	public GameObject zyme;
	private ZymePopupScript zymeScript;

	public float tutorialDelay;
	private float elapsedTime;

	private bool showTutorial = false;
	private bool page1Shown = false;
	private bool tutorialOver = false;

	public GUIStyle gotIt;

	public GameObject light;
	private GameObject spawnedLight;
	private bool lightOn = false;
	
	public GameObject speedMultiplierTutorial;
	private bool nextTutorial = false;

	// Use this for initialization
	void Start () 
	{
		zymeScript = ((GameObject)Instantiate(zyme)).GetComponent<ZymePopupScript> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (nextTutorial)
		{
			return;
		}

		if (!tutorialOver && PlayerPrefs.GetInt("SIStats_towersUpgraded") > 1)
		{ 
			elapsedTime += Time.deltaTime;

			if (elapsedTime > tutorialDelay)
			{
				showTutorial = true;
				if (!lightOn)
				{
					spawnLightOnNutrients ();
				}
			}
		}

		if (tutorialOver)
		{
			Destroy(spawnedLight.gameObject);
			Instantiate(speedMultiplierTutorial);
			nextTutorial = true;
		}
	}

	void spawnLightOnNutrients()
	{
		// set the light location to be on the tower
		Vector3 newLightLoc = new Vector3 (-2.46f, 5f, -14.22f);
		
		spawnedLight = (GameObject)Instantiate(light);
		spawnedLight.transform.position = newLightLoc;
		
		lightOn = true;
	}

	void OnGUI()
	{
		gotIt.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		gotIt.fontSize = (int)(20f / 597f * Screen.height);
		gotIt.alignment = TextAnchor.MiddleCenter;

		if (showTutorial && !page1Shown)
		{
			Instantiate(zyme);
			zymeScript.setDraw(true);
			zymeScript.setText("Nutrients are used to \npurchase and upgrade \nenzyme towers!");
			Time.timeScale = .01f;

			if (GUI.Button(new Rect(Screen.width - (.5112f * Screen.height), 
			                        (Screen.height * 0.82421875f) - (.15f * Screen.height),
			                        (.12f * Screen.width),
			                        (.1f * Screen.height)), "Got it!", gotIt))
			{
				zymeScript.setDraw(false);
				page1Shown = true;
				Time.timeScale = 1;
			}
		}

		if (showTutorial && page1Shown)
		{
			zymeScript.setDraw(true);
			zymeScript.setText("Nutrients are earned \nby absorbing nutrients!");
			Time.timeScale = .01f;

			if (GUI.Button(new Rect(Screen.width - (.5112f * Screen.height), 
			                        (Screen.height * 0.82421875f) - (.15f * Screen.height),
			                        (.12f * Screen.width),
			                        (.1f * Screen.height)), "Got it!", gotIt))
			{
				showTutorial = false;
				zymeScript.setDraw(false);
				tutorialOver = true;
				Time.timeScale = 1;
			}
		}

	}
}
