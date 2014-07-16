using UnityEngine;
using System.Collections.Generic;

public class TowerSpawner : MonoBehaviour
{
	// Randomly selects a tower model upon creation
	public GameObject[] Towers;
	public GameObject SpawnIndicator;
	DebugConfig debugConfig;

	// texture for bottom bar area
	public Texture bottomBar;

	// Set available tower colors in editor
	public Color[] AvailableColors;
	public GUIStyle ButtonStyle;

	// for sounds
	public GameObject placementSound;
	
	public Rect Dimensions;
	public bool IsMouseOverWall;
	public GameObject wall;

	// Need to poll from last frame, otherwise
	// will return false as soon as user releases mouse
	private bool m_IsMouseOverWallLastFrame;
	private List<GameObject> m_SpawnAreas;
	private Rect m_ButtonSize;
	private bool m_IsSpawnActive;
	private GameObject m_SpawnedTower;
	private GameObject m_Indicator;
	private IntestineGameManager m_GameManager;
	public int TOWER_BASE_COST = 20;
	private const float timer = 2.0f;
		
	void Start ()
	{
		// make sure we aren't in tutorial
		if (Application.loadedLevelName != "SmallIntestineTutorial")
		{
			debugConfig = ((GameObject)GameObject.Find("Debug Config")).GetComponent<DebugConfig>();
			TOWER_BASE_COST = debugConfig.TOWER_BASE_COST;
		}
		m_IsSpawnActive = false;

		m_GameManager = GameObject.Find ("Managers").GetComponent<IntestineGameManager> ();
	}

	void Update ()
	{
		if(Time.timeScale <= 0.001f)
		{
			if(m_IsSpawnActive)
			{
				m_IsSpawnActive = false;
				DestroyImmediate (m_Indicator.renderer.material);
				Destroy (m_Indicator);
				Destroy (m_SpawnedTower);
				m_SpawnedTower = null;
			}
		}

		if (Application.loadedLevelName != "SmallIntestineTutorial")
		{
			TOWER_BASE_COST = debugConfig.TOWER_BASE_COST;
		}

		// Handle valid spawn locations if player is spawning a tower
		if (m_IsSpawnActive) 
		{
			if (Input.GetMouseButtonUp (0)) 
			{
				m_IsSpawnActive = false;

				DestroyImmediate (m_Indicator.renderer.material);
				Destroy (m_Indicator);
			
				if (m_IsMouseOverWallLastFrame && m_GameManager.nutrients - TOWER_BASE_COST >= 0) 
				{
					
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

	public bool getIsSpawnActive()
	{
		return m_IsSpawnActive;
	}

	public GameObject getSpawnedTower()
	{
		return m_SpawnedTower;
	}

	public IntestineGameManager getGameManager()
	{
		return m_GameManager;
	}
}

