using UnityEngine;
using System.Collections.Generic;

public class TowerSpawner : MonoBehaviour
{
	// Randomly selects a tower model upon creation
	public GameObject[] Towers;
	public GameObject SpawnIndicator;
	DebugConfig debugConfig;

	// Set available tower colors in editor
	public Color[] AvailableColors;
	public GUIStyle ButtonStyle;
	public Rect Dimensions;
	public bool IsMouseOverWall;		
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
	private float timePassed = 0.0f;
		
	void Start ()
	{
		debugConfig = ((GameObject)GameObject.Find("Debug Config")).GetComponent<DebugConfig>();
		TOWER_BASE_COST = debugConfig.TOWER_BASE_COST;
		m_IsSpawnActive = false;

		float totalWidth = Dimensions.width * AvailableColors.Length;

		Dimensions.x = (GuiUtility.ORIG_SCREEN_WIDTH - totalWidth) / 2;
		Dimensions.y = GuiUtility.ORIG_SCREEN_HEIGHT - Dimensions.height;
		m_ButtonSize = Dimensions;

		m_GameManager = GameObject.Find ("Managers").GetComponent<IntestineGameManager> ();

	//	GameObject spawnAreaObject = GameObject.FindGameObjectWithTag ("SpawnArea");
	//	m_SpawnAreas = new List<GameObject> ();
	//	foreach (Transform child in spawnAreaObject.transform) {
	//		m_SpawnAreas.Add (child.gameObject);
	//	}
	}

	void Update ()
	{
		TOWER_BASE_COST = debugConfig.TOWER_BASE_COST;
		// Handle valid spawn locations if player is spawning a tower
		if (m_IsSpawnActive) {
			if (Input.GetMouseButtonUp (0)) {
				m_IsSpawnActive = false;

				DestroyImmediate (m_Indicator.renderer.material);
				Destroy (m_Indicator);
				
				if (m_IsMouseOverWallLastFrame && m_GameManager.Nutrients - TOWER_BASE_COST >= 0) {
					
					m_SpawnedTower.GetComponent<Tower> ().enabled = true;
					m_SpawnedTower.transform.position = MDPUtility.MouseToWorldPosition () + new Vector3 (0, 0.5f, 0);
					m_SpawnedTower.GetComponent<TowerMenu> ().Initialize ();
					m_GameManager.Nutrients = m_GameManager.Nutrients - TOWER_BASE_COST;  // cost nutrients for testing
                
				} else {
					Destroy (m_SpawnedTower);
					m_SpawnedTower = null;
				}
			} else {
				m_SpawnedTower.transform.position = MDPUtility.MouseToWorldPosition ();
				m_Indicator.transform.position = MDPUtility.MouseToWorldPosition () + Vector3.up;
				Color color = m_IsMouseOverWallLastFrame ? Color.green : Color.red;
				color.a = 0.5f;
				m_Indicator.renderer.material.color = color;
			}
		}
		
		m_IsMouseOverWallLastFrame = IsMouseOverWall;
	}

	void OnGUI ()
	{
		Matrix4x4 orig = GUI.matrix;
		GUI.matrix = GuiUtility.CachedScaledMatrix;
		
		if (timePassed > 0)
		{
			timePassed -= Time.deltaTime;
			GUIStyle style = new GUIStyle();
			style.fontSize = 30;
			style.alignment = TextAnchor.UpperCenter;
			style.normal.textColor = Color.white;
			GUI.Label(new Rect(Screen.width/2 + 50, Screen.height*.9f - 20, 200, 40), "Not enough nutrients!", style);
		}
		
		for (int i = 0; i < AvailableColors.Length; i++) {
			GUI.backgroundColor = AvailableColors [i];
			m_ButtonSize.x = Dimensions.x + i * m_ButtonSize.width;
			
			// if the user clicks a button
			if (GUI.RepeatButton (m_ButtonSize, "", ButtonStyle)) 
			{
				// check all conditions for creating a tower before creating it
				if (!m_IsSpawnActive && m_GameManager.Nutrients - TOWER_BASE_COST >= 0) 
				{
					SpawnTower (AvailableColors [i]);
					m_SpawnedTower.GetComponent<Tower> ().enabled = false;
					return;
				} else if (m_GameManager.Nutrients - TOWER_BASE_COST < 0) 
				{
					// if there was not enough nutrients to create the tower let the user know
					timePassed = timer;		
				}
			}
		}

		GUI.matrix = orig;
	}

	private void SpawnTower (Color color)
	{
		GameObject towerType = Towers [MDPUtility.RandomInt (Towers.Length)];
		m_SpawnedTower = Instantiate (towerType) as GameObject;
		Tower tower = m_SpawnedTower.GetComponent<Tower> ();
		tower.SetColor (color);

		// Set up spawn indicator
		float range = tower.FiringRange;
		m_Indicator = Instantiate (SpawnIndicator) as GameObject;
		m_Indicator.transform.localScale = new Vector3 (range * 2, 1, range * 2);

		m_IsSpawnActive = true;
	}
}

