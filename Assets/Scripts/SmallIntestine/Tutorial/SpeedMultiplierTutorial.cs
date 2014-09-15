using UnityEngine;
using System.Collections;

/**
 * Tutorial stuff for speed multiplier
 */
public class SpeedMultiplierTutorial : MonoBehaviour  
{
	// for zyme
	public GameObject zyme;
	private ZymePopupScript zymeScript;

	private bool showTutorial;
	private bool page1Shown;
	private bool tutorialOver;
	private bool tutorialReady;

	public GameObject spotLight;
	private GameObject spawnedLight;
	private bool lightOn;

	public float tutorialDelay;
	private float elapsedTime;
	
	// Use this for initialization
	void Start () 
	{
		zymeScript = ((GameObject)Instantiate(zyme)).GetComponent<ZymePopupScript> ();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (PlayerPrefs.GetInt("SISpeedTutorial") == 1)
		{
			tutorialReady = true;
		}

		if (tutorialReady)
		{
			if (!tutorialOver)
			{ 
				elapsedTime += Time.deltaTime;
				
				if (elapsedTime > tutorialDelay)
				{
					showTutorial = true;
					if (!lightOn)
					{
						spawnLightOnSpeed ();
					}
				}
			}

			if (zymeScript.getButtonPressed() && showTutorial)
			{
				showTutorial = false;
				zymeScript.setDraw(false);
				tutorialOver = true;
				PlayerPrefs.SetInt("SISpeedTutorial", 0);
				PlayerPrefs.SetInt("SIFatsTutorial", 1);
				PlayerPrefs.Save();
				Time.timeScale = 1;
			}
			
			if (tutorialOver)
			{
				Destroy(spawnedLight.gameObject);
			}
		}
	}

	void spawnLightOnSpeed()
	{
		Vector3 newLightLoc = new Vector3 (-23f, 5f, -11.5f);
		
		spawnedLight = (GameObject)Instantiate(spotLight);
		spawnedLight.transform.position = newLightLoc;
		
		lightOn = true;
	}

	void OnGUI()
	{
		if (tutorialReady)
		{
			if (showTutorial)
			{
				zymeScript.setDraw(true);
				zymeScript.setShowButton(true);
				zymeScript.setText("The stopwatch can be \nused to speed up or slow \ndown the flow of food!");
				Time.timeScale = .01f;
			}
		}
	}
}

