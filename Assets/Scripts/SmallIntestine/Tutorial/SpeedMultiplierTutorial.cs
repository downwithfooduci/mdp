using UnityEngine;
using System.Collections;

public class SpeedMultiplierTutorial : MonoBehaviour  
{
	// for zyme
	public GameObject zyme;
	private ZymePopupScript zymeScript;
	
	public GUIStyle gotIt;

	private bool showTutorial;
	private bool page1Shown;
	private bool tutorialOver;

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
		
		if (tutorialOver)
		{
			Destroy(spawnedLight.gameObject);
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
		gotIt.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		gotIt.fontSize = (int)(20f / 597f * Screen.height);
		gotIt.alignment = TextAnchor.MiddleCenter;

		if (showTutorial)
		{
			Instantiate(zyme);
			zymeScript.setDraw(true);
			zymeScript.setText("The stopwatch can be \nused to speed up or slow \ndown the flow of food!");
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

