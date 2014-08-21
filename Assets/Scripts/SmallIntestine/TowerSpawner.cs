using UnityEngine;
using System.Collections.Generic;

// script that handles most of the basic functionality of the tower spawner
public class TowerSpawner : MonoBehaviour
{
	// Randomly selects a tower model upon creation
	public GameObject[] Towers;				// an array to store towers
	public GameObject SpawnIndicator;		// creates the spawn indicator (the red or green circle around the tower)
	DebugConfig debugConfig;				// to hold a reference to the debugconfig script

	// Set available tower colors in editor
	public Color[] AvailableColors;			// an array that holds a list of possible tower colors

	// for sounds
	public GameObject placementSound;		// to hold the sound that will be played when a tower is placed

	public bool IsMouseOverWall;			// a flag that is set to indicate the tower is currently over a wall
	public GameObject wall;					// a reference to the wall that the tower is hovering over

	// Need to poll from last frame, otherwise
	// will return false as soon as user releases mouse
	private bool m_IsMouseOverWallLastFrame;		// to hold a flag to indicate if the mouse was over a wall in the last update
	private bool m_IsSpawnActive;					// to flag whether or not the spawn is active

	private GameObject m_SpawnedTower;				// a reference to the current spawned tower
	private GameObject m_Indicator;					// the gameobject that creates the spawn indicator (red or green circle)
	private IntestineGameManager m_GameManager;		// holds a reference to the game manager

	public int TOWER_BASE_COST = 20;				// the tower base placement cost
	private const float timer = 2.0f;				// a timer
		
	void Start ()
	{
		// make sure we aren't in tutorial
		if (Application.loadedLevelName != "SmallIntestineTutorial")
		{
			// if we aren't in the tutorial get a reference to the debugger
			debugConfig = ((GameObject)GameObject.Find("Debug Config")).GetComponent<DebugConfig>();

			// if we are using the debugger values get the tower base cost from there
			if (debugConfig.debugActive)
			{
				TOWER_BASE_COST = debugConfig.TOWER_BASE_COST;
			}
		}

		m_IsSpawnActive = false;		// the spawn active should default to false

		// find a reference to the current intestine game manager
		m_GameManager = GameObject.Find ("Managers").GetComponent<IntestineGameManager> ();
	}

	void Update ()
	{
		// check if the game is paused we destroy any spawned tower that isn't currently placed
		if(Time.timeScale <= 0.001f)
		{
			// this handles the cleanup of variables that need to be reassigned based on destroying unplaced tower
			if(m_IsSpawnActive)
			{
				m_IsSpawnActive = false;							// set that isspawnactive flag to false
				DestroyImmediate (m_Indicator.renderer.material);	// destroy the indicator material
				Destroy (m_Indicator);								// destroy the indicator
				Destroy (m_SpawnedTower);							// destroy the spawned tower
				m_SpawnedTower = null;								// set the spawnedtower reference to null
			}
		}

		// if we are not in the tutorial and we are using the debugger, check for updates to the tower base cost
		if (Application.loadedLevelName != "SmallIntestineTutorial")
		{
			if (debugConfig.debugActive)
			{
				TOWER_BASE_COST = debugConfig.TOWER_BASE_COST;
			}
		}

		// Handle valid spawn locations if player is spawning a tower
		if (m_IsSpawnActive) 
		{
			// check that the mouse button is not currently pressed
			if (Input.GetMouseButtonUp (0)) 
			{
				m_IsSpawnActive = false;				// set the spawn active flag to false

				DestroyImmediate (m_Indicator.renderer.material);	// destroy the spawn indicator material
				Destroy (m_Indicator);								// destroy the spawn indicator
			
				// check if the user has enough nutrients to spawn a tower
				if (m_IsMouseOverWallLastFrame && m_GameManager.nutrients - TOWER_BASE_COST >= 0) 
				{
					// if they do have enough nutrients
					m_SpawnedTower.GetComponent<Tower> ().enabled = true;
					m_SpawnedTower.transform.position = wall.transform.position + new Vector3 (0, 0.5f, 0);
					m_SpawnedTower.GetComponent<Tower>().wall = wall;
					m_SpawnedTower.GetComponent<TowerMenu> ().Initialize ();
					m_GameManager.nutrients = m_GameManager.nutrients - TOWER_BASE_COST;  // cost nutrients for testing

					// play placement sound
					Instantiate (placementSound);

					// track stats
					PlayerPrefs.SetInt ("SIStats_towersPlaced", PlayerPrefs.GetInt("SIStats_towersPlaced") + 1);
					PlayerPrefs.SetInt ("SIStats_nutrientsSpent", PlayerPrefs.GetInt("SIStats_nutrientsSpent") + TOWER_BASE_COST);
					PlayerPrefs.Save();
				} else 
				{
					Destroy (m_SpawnedTower);
					m_SpawnedTower = null;
				}
			} else 
			{
				m_SpawnedTower.transform.position = MDPUtility.MouseToWorldPosition () + Vector3.up;

				m_Indicator.transform.position = MDPUtility.MouseToWorldPosition () + Vector3.up;
				Color color = m_IsMouseOverWallLastFrame ? Color.green : Color.red;
				color.a = 0.5f;
				m_Indicator.renderer.material.color = color;
			}
		}
		
		m_IsMouseOverWallLastFrame = IsMouseOverWall;
	}

	public void SpawnTower (Color color)
	{
		GameObject towerType = Towers [MDPUtility.RandomInt (Towers.Length)];
		m_SpawnedTower = Instantiate (towerType) as GameObject;
		Tower tower = m_SpawnedTower.GetComponent<Tower> ();
		tower.SetColor (color);
		tower.SetActiveModel ("Base");

		// Set up spawn indicator
		float range = tower.FiringRange;
		m_Indicator = Instantiate (SpawnIndicator) as GameObject;
		m_Indicator.transform.localScale = new Vector3 (range * 2, 1, range * 2);

		m_IsSpawnActive = true;
	}

	// function that can be called to determine if the spawn is currently active or not
	public bool getIsSpawnActive()
	{
		return m_IsSpawnActive;
	}

	// function that can be called that will return a reference to the currently spawned tower
	public GameObject getSpawnedTower()
	{
		return m_SpawnedTower;
	}

	// function that can be called to return the gamemanager instance stored in this script
	public IntestineGameManager getGameManager()
	{
		return m_GameManager;
	}
}
