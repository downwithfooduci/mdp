using UnityEngine;
using System.Collections;

/**
 * Tutorial stuff for upgrading towers
 */
public class TowerUpgradeTutorial : MonoBehaviour 
{
	// for zyme
	public GameObject zyme;
	private ZymePopupScript zymeScript;

	bool showZymeSpeed;
	bool showZymePower;

	// a timer for how long to wait before showing the upgrade tutorial
	public float maxUpgradeTimeSpeed;
	public float maxUpgradeTimePower;
	private float elapsedTime;
	private bool speedUpgraded;
	private bool powerUpgraded;

	// for spawning a spotlight
	public GameObject spotLight;
	private GameObject spawnedLight;
	private bool lightOn;

	// for finding the first two towers
	private GameObject[] towers;
	private int currentTower = 0;

	// for adding to nutrients
	private IntestineGameManager intestineGameManager;

	// Use this for initialization
	void Start () 
	{
		intestineGameManager = FindObjectOfType(typeof(IntestineGameManager)) as IntestineGameManager;
		zymeScript = ((GameObject)Instantiate(zyme)).GetComponent<ZymePopupScript> ();
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
			zymeScript.setDraw(false);

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
			Time.timeScale = 1;
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
			Time.timeScale = 1;
			powerUpgraded = true;
			showZymePower = false;
			zymeScript.setDraw(false);
			
			// destroy the light if it exists
			if (spotLight != null)
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
		float towerPositionY = spotLight.transform.position.y;
		float towerPositionZ = towers[currentTower].transform.position.z;

		// set the light location to be on the tower
		Vector3 newLightLoc = new Vector3 (towerPositionX, towerPositionY, towerPositionZ);

		spawnedLight = (GameObject)Instantiate(spotLight);
		spawnedLight.transform.position = newLightLoc;

		lightOn = true;
		currentTower++;
	}

	void OnGUI() 
	{		
		if(showZymeSpeed)
		{
			zymeScript.setDraw(true);
			zymeScript.setText("Tap a tower to upgrade! \nSpeed makes a tower \nrelease enzymes faster!");
			Time.timeScale = .01f;
		}
		
		if(showZymePower)
		{
			zymeScript.setDraw(true);
			zymeScript.setText("Tap a tower to upgrade! \nPower makes a tower \nrelease more enzymes at \na time!");
			Time.timeScale = .01f;
		}
	}
}
