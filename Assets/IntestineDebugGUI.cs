using UnityEngine;
using System.Collections;

public class IntestineDebugGUI : MonoBehaviour {
	
	DebugConfig debugConfig;
	bool showGUI = false;
	string speed;
	string spawnTime;
	string towerBaseCost;
	string towerLvl1Cost;
	string towerLvl2Cost;
	string towerBaseCD;
	string towerLvl1CD;
	string towerLvl2CD;
	bool FPSActive;
	// Use this for initialization
	void Start () {
		debugConfig = gameObject.GetComponent<DebugConfig>();
		speed = "" + debugConfig.NutrientSpeed;
		spawnTime = "" + debugConfig.NutrientSpawnInterval;
		towerBaseCost = "" + debugConfig.TOWER_BASE_COST;
		towerLvl1Cost = "" + debugConfig.TOWER_UPGRADE_LEVEL_1_COST;
		towerLvl2Cost = "" + debugConfig.TOWER_UPGRADE_LEVEL_2_COST;
		towerBaseCD = "" + debugConfig.BaseCooldown;
		towerLvl1CD = "" + debugConfig.Level1Cooldown;
		towerLvl2CD = "" + debugConfig.Level2Cooldown;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width - 100, Screen.height - 50, 100, 50), "Debug"))
		{
			showGUI = !showGUI;
			Time.timeScale = showGUI ? 0 : 1;
		}
		if(showGUI)
		{
			GUI.Label(new Rect(100, 10, 100, 50), "Nutrient Speed");
			speed = GUI.TextField(new Rect(200, 10, 100, 50),
				speed);
			float NutrientSpeed;
			if(float.TryParse(speed, out NutrientSpeed))
			{
				debugConfig.NutrientSpeed = NutrientSpeed;
			}
			
			GUI.Label(new Rect(100, 60, 100, 50), "Nutrient Interval");
			spawnTime = GUI.TextField(new Rect(200, 60, 100, 50),
				spawnTime);
			float NutrientSpawnInterval;
			if(float.TryParse(spawnTime, out NutrientSpawnInterval))
			{
				debugConfig.NutrientSpawnInterval = NutrientSpawnInterval;
			}
			
			GUI.Label(new Rect(100, 110, 100, 50), "Tower Base Cost");
			towerBaseCost = GUI.TextField(new Rect(200, 110, 100, 50),
				towerBaseCost);
			int TowerBaseCost;
			if(int.TryParse(towerBaseCost, out TowerBaseCost))
			{
				debugConfig.TOWER_BASE_COST = TowerBaseCost;
			}
			
			GUI.Label(new Rect(100, 160, 100, 50), "Tower Lvl 1 Cost");
			towerLvl1Cost = GUI.TextField(new Rect(200, 160, 100, 50),
				towerLvl1Cost);
			int TowerLvl1Cost;
			if(int.TryParse(towerLvl1Cost, out TowerLvl1Cost))
			{
				debugConfig.TOWER_UPGRADE_LEVEL_1_COST = TowerLvl1Cost;
			}
			
			GUI.Label(new Rect(100, 210, 100, 50), "Tower Lvl 2 Cost");
			towerLvl2Cost = GUI.TextField(new Rect(200, 210, 100, 50),
				towerLvl2Cost);
			int TowerLvl2Cost;
			if(int.TryParse(towerLvl2Cost, out TowerLvl2Cost))
			{
				debugConfig.TOWER_UPGRADE_LEVEL_2_COST = TowerLvl2Cost;
			}
			
			GUI.Label(new Rect(350, 10, 100, 50), "Tower Base CD");
			towerBaseCD = GUI.TextField(new Rect(450, 10, 100, 50),
				towerBaseCD);
			float TowerBaseCD;
			if(float.TryParse(towerBaseCD, out TowerBaseCD))
			{
				debugConfig.BaseCooldown = TowerBaseCD;
			}
			
			GUI.Label(new Rect(350, 60, 100, 50), "Tower Lvl 1 CD");
			towerLvl1CD = GUI.TextField(new Rect(450, 60, 100, 50),
				towerLvl1CD);
			float TowerLvl1CD;
			if(float.TryParse(towerLvl1CD, out TowerLvl1CD))
			{
				debugConfig.Level1Cooldown = TowerLvl1CD;
			}
			
			GUI.Label(new Rect(350, 110, 100, 50), "Tower Lvl 2 CD");
			towerLvl2CD = GUI.TextField(new Rect(450, 110, 100, 50),
				towerLvl2CD);
			float TowerLvl2CD;
			if(float.TryParse(towerLvl2CD, out TowerLvl2CD))
			{
				debugConfig.Level2Cooldown = TowerLvl2CD;
			}

			FPSActive = GUI.Toggle(new Rect(350, 160, 100, 50), FPSActive, "Toggle FPS");
			if (FPSActive)
			{
				debugConfig.FPSActive = true;
			} else
			{
				debugConfig.FPSActive = false;
			}
		}
	}
}
