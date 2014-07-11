using UnityEngine;
using System.Collections;

public class NutrientsTutorial : MonoBehaviour 
{
	public Texture zyme;
	float ratio = 1.4250681198910081743869209809264f;

	private bool showTutorial = false;
	private bool page1Shown = false;
	private bool tutorialOver = false;

	public GUIStyle gotIt;

	public GameObject light;
	private GameObject spawnedLight;
	private bool lightOn = false;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () 
	{
		if (PlayerPrefs.GetInt("SIStats_towersUpgraded") > 1)
		{ 
			showTutorial = true;
			if (!lightOn)
			{
				spawnLightOnNutrients ();
			}
		}
	}

	void spawnLightOnNutrients()
	{
		// set the light location to be on the tower
//		Vector3 newLightLoc = new Vector3 (-2.46, 5, -14.22);
		
		spawnedLight = (GameObject)Instantiate(light);
	//	spawnedLight.transform.position = newLightLoc;
		
		lightOn = true;
	}

	void OnGUI()
	{
		// font
		GUIStyle style = new GUIStyle ();
		style.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		style.normal.textColor = new Color(248f/255f, 157f/255f, 48f/255f);
		style.fontSize = (int)(18f / 597f * Screen.height);
		style.wordWrap = true;

		if (showTutorial && !page1Shown)
		{
			GUI.DrawTexture(new Rect(Screen.width - (.4f * Screen.height * ratio), 
			                         (Screen.height * 0.82421875f) - (.4f * Screen.height),
			                         (.4f * Screen.height * ratio),
			                         (.4f * Screen.height)), zyme);
			GUI.Label(new Rect(.58f*Screen.width, .42f*Screen.height, .8f*Screen.width, .8f*Screen.height),
			          "Nutrients are used to purchase and upgrade enzyme towers!",
			          style);
		}

		if (showTutorial && page1Shown)
		{
			GUI.DrawTexture(new Rect(Screen.width - (.4f * Screen.height * ratio), 
			                         (Screen.height * 0.82421875f) - (.4f * Screen.height),
			                         (.4f * Screen.height * ratio),
			                         (.4f * Screen.height)), zyme);
			GUI.Label(new Rect(.58f*Screen.width, .42f*Screen.height, .8f*Screen.width, .8f*Screen.height),
			          "Nutrients are earned by absorbing nutrients!",
			          style);
		}

	}
}
