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

	public Texture zymePopupImageSpeed;
	public Texture zymePopupImagePower;

	bool showZymeSpeed;
	bool showZymePower;

	// a timer for how long to wait before showing the upgrade tutorial
	public float maxUpgradeTimeSpeed;
	public float maxUpgradeTimePower;
	private float elapsedTime;
	private bool speedUpgraded;
	private bool powerUpgraded;

	// for spawning an arrow
	public Texture arrow1light;
	public Texture arrow2light;
	private Rect drawArrowRect;
	private bool drawArrow;
	private bool drawArrowDown;
	private bool drawLightArrow;

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
		   && !drawArrow)
		{
			elapsedTime += Time.deltaTime;
		}

		// if the time has passed spawn an indicator spotlight on the tower to upgrade
		if (elapsedTime > maxUpgradeTimeSpeed && !drawArrow) 
		{
			//give nutrients to upgrade and tell to upgrade
			intestineGameManager.nutrients += 50;
			spawnArrowOnTower();
			showZymeSpeed = true;
			elapsedTime = 0f;
		}

		// destroy the light once the tower is upgraded and count to next upgrade
		if (PlayerPrefs.GetInt("SIStats_towersUpgraded") == 1 && !speedUpgraded)
		{
			speedUpgraded = true;
			showZymeSpeed = false;
			zymeScript.setDraw(false);
			zymeScript.setDrawZymeRight();
			drawArrow = false;
		}

		// update elapsed time for 2nd upgrade
		if (speedUpgraded && PlayerPrefs.GetInt("SIStats_towersUpgraded") == 1)
		{
			Time.timeScale = 1;
			elapsedTime += Time.deltaTime;
		}

		// if the time has passed spawn an indicator spotlight on the tower to upgrade
		if (elapsedTime > maxUpgradeTimePower && !drawArrow && speedUpgraded) 
		{
			//give nutrients to upgrade and tell to upgrade
			intestineGameManager.nutrients += 50;
			spawnArrowOnTower();
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
			drawArrow = false;
		}
	}

	void spawnArrowOnTower()
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

		// check which arrow to draw and define region
		if (towers[currentTower].transform.position.z <= 0)
		{
			drawArrowDown = true;
			drawArrowRect = new Rect ((towers [currentTower].transform.position.x + 26)/52f * Screen.width - .5f *  75f/1024f * Screen.width, 
			                          Screen.height - ((towers [currentTower].transform.position.z + 19)/38f * Screen.height + 1.75f * 150f/1024f * Screen.height), 
			                          75f/1024f * Screen.width, 150f/1024f * Screen.height); 
		} else
		{
			drawArrowDown = false;
			drawArrowRect = new Rect ((towers [currentTower].transform.position.x + 26)/52f * Screen.width - .5f *  75f/1024f * Screen.width, 
			                          Screen.height - ((towers [currentTower].transform.position.z + 19)/38f * Screen.height - .25f * 150f/1024f * Screen.height), 
			                          75f/1024f * Screen.width, 150f/1024f * Screen.height); 
		}

		// check if the zyme script will be covering the tower and if it is switch the sides
		if (towers [currentTower].transform.position.x > 0)
		{
			zymeScript.setDrawZymeLeft ();
		}

		drawArrow = true;
		currentTower++;
	}

	void OnGUI() 
	{		
		if(showZymeSpeed)
		{
			zymeScript.setDraw(true);
			zymeScript.setImage(zymePopupImageSpeed);
			Time.timeScale = .01f;
		}
		
		if(showZymePower)
		{
			zymeScript.setDraw(true);
			zymeScript.setImage(zymePopupImagePower);
			Time.timeScale = .01f;
		}

		if (drawArrow)
		{
			if (drawArrowDown)
			{
				GUI.DrawTexture(drawArrowRect, arrow2light);
			} else
			{
				GUI.DrawTexture(drawArrowRect, arrow1light);
			}
		}
	}
}
