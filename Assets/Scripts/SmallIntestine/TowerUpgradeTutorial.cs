using UnityEngine;
using System.Collections;

public class TowerUpgradeTutorial : MonoBehaviour 
{
	// for zyme helper box
	public Texture zyme;
	float ratio = 1.4250681198910081743869209809264f;
	bool showZymeSpeed = false;
	bool showZymePower = false;

	// a timer for how long to wait before showing the upgrade tutorial
	public float maxUpgradeTimeSpeed;
	public float maxUpgradeTimePower;
	private float elapsedTime;
	private bool speedUpgraded = false;
	private bool powerUpgraded = false;

	// for spawning a spotlight
	public GameObject light;
	private GameObject spawnedLight;
	private bool lightOn = false;

	// for finding the first two towers
	private GameObject[] towers;
	private int currentTower = 0;

	// for adding to nutrients
	private IntestineGameManager intestineGameManager;

	// Use this for initialization
	void Start () 
	{
		intestineGameManager = FindObjectOfType(typeof(IntestineGameManager)) as IntestineGameManager;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// if we are done just exit this function
		if (powerUpgraded)
		{
			return;
		}

		// don't start counting the upgrade time until they have placed 2 towers
		if(PlayerPrefs.GetInt("SIStats_towersPlaced") > 1 && !(PlayerPrefs.GetInt("SIStats_towersUpgraded") > 0) 
		   && !lightOn)
		{
			elapsedTime += Time.deltaTime;
		}

		// if the time has passed spawn an indicator spotlight on the tower to upgrade
		if (elapsedTime > maxUpgradeTimeSpeed && !lightOn) 
		{
			//give nutrients to upgrade and tell to upgrade
			intestineGameManager.nutrients += 50;
			spawnLightOnTower();
			showZymeSpeed = true;
			elapsedTime = 0f;
		}

		// destroy the light once the tower is upgraded and count to next upgrade
		if (PlayerPrefs.GetInt("SIStats_towersUpgraded") == 1 && !speedUpgraded)
		{
			speedUpgraded = true;
			showZymeSpeed = false;

			// turn off the light if it exists
			if (spawnedLight != null)
			{
				Destroy (spawnedLight.gameObject);
				lightOn = false;
			}
		}

		// update elapsed time for 2nd upgrade
		if (speedUpgraded && PlayerPrefs.GetInt("SIStats_towersUpgraded") == 1)
		{
			elapsedTime += Time.deltaTime;
		}

		// if the time has passed spawn an indicator spotlight on the tower to upgrade
		if (elapsedTime > maxUpgradeTimePower && !lightOn && speedUpgraded) 
		{
			//give nutrients to upgrade and tell to upgrade
			intestineGameManager.nutrients += 50;
			spawnLightOnTower();
			showZymePower = true;
			elapsedTime = 0f;
		}

		// destroy the light once the tower is upgraded and count to next upgrade
		if (PlayerPrefs.GetInt("SIStats_towersUpgraded") == 2)
		{
			powerUpgraded = true;
			showZymePower = false;
			
			// destroy the light if it exists
			if (light != null)
			{
				Destroy (spawnedLight.gameObject);
			}
		}
	}

	void spawnLightOnTower()
	{
		//exit if the user is taking too long
		if (currentTower == 2)
		{
			return;
		}

		// find the first two towers
		if (towers == null)
		{
			towers = GameObject.FindGameObjectsWithTag ("tower");
		}

		float towerPositionX = towers[currentTower].transform.position.x;
		float towerPositionY = light.transform.position.y;
		float towerPositionZ = towers[currentTower].transform.position.z;

		// set the light location to be on the tower
		Vector3 newLightLoc = new Vector3 (towerPositionX, towerPositionY, towerPositionZ);

		spawnedLight = (GameObject)Instantiate(light);
		spawnedLight.transform.position = newLightLoc;

		lightOn = true;
		currentTower++;
	}

	void OnGUI() 
	{
		// font
		GUIStyle style = new GUIStyle ();
		style.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		style.normal.textColor = new Color(248f/255f, 157f/255f, 48f/255f);
		style.fontSize = (int)(18f / 597f * Screen.height);
		style.wordWrap = true;
		
		if(showZymeSpeed)
		{
			GUI.DrawTexture(new Rect(Screen.width - (.4f * Screen.height * ratio), 
		                         (Screen.height * 0.82421875f) - (.4f * Screen.height),
		                         (.4f * Screen.height * ratio),
		                         (.4f * Screen.height)), zyme);
			GUI.Label(new Rect(.58f*Screen.width, .42f*Screen.height, .8f*Screen.width, .8f*Screen.height),
			          "Tap a tower to upgrade! \nSpeed makes a tower \nrelease enzymes faster!",
			          style);
		}
		
		if(showZymePower)
		{
			GUI.DrawTexture(new Rect(Screen.width - (.4f * Screen.height * ratio), 
			                         (Screen.height * 0.82421875f) - (.4f * Screen.height),
			                         (.4f * Screen.height * ratio),
			                         (.4f * Screen.height)), zyme);
			GUI.Label(new Rect(.58f*Screen.width, .42f*Screen.height, .8f*Screen.width, .8f*Screen.height),
			          "Tap a tower to upgrade! \nPower makes a tower \nrelease more enzymes at \na time!",
			          style);
		}
	}
}
