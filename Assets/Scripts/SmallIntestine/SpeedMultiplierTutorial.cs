using UnityEngine;
using System.Collections;

public class SpeedMultiplierTutorial : MonoBehaviour  
{
	public Texture zyme;
	float ratio = 1.4250681198910081743869209809264f;

	public GUIStyle gotIt;

	bool value;
	public GUIStyle speedButtonOff;
	public GUIStyle speedButtonOn;

	private bool showTutorial = false;
	private bool page1Shown = false;
	private bool tutorialOver = false;

	public GameObject light;
	private GameObject spawnedLight;
	private bool lightOn = false;
	private bool lightSpawned = false;

	public float tutorialDelay;
	private float elapsedTime;
	
	// Use this for initialization
	void Start () 
	{
		value = false;
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
		if (lightSpawned)
		{
			return;
		}

		Vector3 newLightLoc = new Vector3 (-23f, 5f, -11.5f);
		
		spawnedLight = (GameObject)Instantiate(light);
		spawnedLight.transform.position = newLightLoc;
		
		lightOn = true;
	}

	void OnGUI()
	{
		GUIStyle style = new GUIStyle ();
		style.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		style.normal.textColor = new Color(248f/255f, 157f/255f, 48f/255f);
		style.fontSize = (int)(18f / 597f * Screen.height);
		style.wordWrap = true;

		gotIt.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		gotIt.fontSize = (int)(20f / 597f * Screen.height);
		gotIt.alignment = TextAnchor.MiddleCenter;

		if(value && 
		   GUI.Button(new Rect(Screen.width * .01f, Screen.height * .745f, Screen.width * .05f, Screen.width * .05f), "", speedButtonOn))
		{
			value = false;
		}
		if(!value && 
		   GUI.Button(new Rect(Screen.width * .01f, Screen.height * .745f, Screen.width * .05f, Screen.width * .05f), "", speedButtonOff))
		{
			value = true;
		}
		
		// this changes the speed by altering the time scale
		if (value && Time.timeScale == 1)
			Time.timeScale = 2;
		else if(!value && Time.timeScale == 2)
			Time.timeScale = 1;

		if (showTutorial)
		{
			GUI.DrawTexture(new Rect(Screen.width - (.4f * Screen.height * ratio), 
			                         (Screen.height * 0.82421875f) - (.4f * Screen.height),
			                         (.4f * Screen.height * ratio),
			                         (.4f * Screen.height)), zyme);
			GUI.Label(new Rect(.58f*Screen.width, .42f*Screen.height, .8f*Screen.width, .8f*Screen.height),
			          "The stopwatch can be \nused to speed up or slow \ndown the flow of food!",
			          style);
			Time.timeScale = .01f;
			
			if (GUI.Button(new Rect(Screen.width - (.36f * Screen.height * ratio), 
			                        (Screen.height * 0.82421875f) - (.15f * Screen.height),
			                        (.12f * Screen.width),
			                        (.1f * Screen.height)), "Got it!", gotIt))
			{
				showTutorial = false;
				tutorialOver = true;
				Time.timeScale = 1;
			}
		}
	}
}

