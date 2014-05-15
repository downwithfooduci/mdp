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
	string waveTimer;
	string waveDelay;
	string minBlobs;
	string maxBlobs;
	string colors;
	bool FPSActive;
	bool debugActive = false;
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
		waveTimer = "" + debugConfig.waveTimer;
		waveDelay = "" + debugConfig.waveDelay;
		minBlobs = "" + debugConfig.minBlobs;
		maxBlobs = "" + debugConfig.maxBlobs;
		colors = "";
		if(debugConfig.colors.Contains(Color.red))
			colors += "R";
		if(debugConfig.colors.Contains(Color.yellow))
			colors += "Y";
		if(debugConfig.colors.Contains(Color.green))
			colors += "G";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		//TODO: Change back to width-100/+100 to enable/disable debugger
		if(GUI.Button(new Rect(Screen.width + 100, Screen.height - 50, 100, 50), "Debug"))
		{
			showGUI = !showGUI;
			Time.timeScale = showGUI ? 0 : 1;
		}
		if(showGUI)
		{
			GUI.Label(new Rect(100, 10, 100, 50), "Nutrient Speed");
			speed = GUI.TextField(new Rect(200, 10, 100, 50),
				speed);
			float nutrientSpeedOut;
			if(float.TryParse(speed, out nutrientSpeedOut))
			{
				debugConfig.NutrientSpeed = nutrientSpeedOut;
			}
			
			GUI.Label(new Rect(100, 60, 100, 50), "Nutrient Interval");
			spawnTime = GUI.TextField(new Rect(200, 60, 100, 50),
				spawnTime);
			float nutrientSpawnIntervalOut;
			if(float.TryParse(spawnTime, out nutrientSpawnIntervalOut))
			{
				debugConfig.NutrientSpawnInterval = nutrientSpawnIntervalOut;
			}
			
			GUI.Label(new Rect(100, 110, 100, 50), "Tower Base Cost");
			towerBaseCost = GUI.TextField(new Rect(200, 110, 100, 50),
				towerBaseCost);
			int towerBaseCostOut;
			if(int.TryParse(towerBaseCost, out towerBaseCostOut))
			{
				debugConfig.TOWER_BASE_COST = towerBaseCostOut;
			}
			
			GUI.Label(new Rect(100, 160, 100, 50), "Tower Lvl 1 Cost");
			towerLvl1Cost = GUI.TextField(new Rect(200, 160, 100, 50),
				towerLvl1Cost);
			int towerLvl1CostOut;
			if(int.TryParse(towerLvl1Cost, out towerLvl1CostOut))
			{
				debugConfig.TOWER_UPGRADE_LEVEL_1_COST = towerLvl1CostOut;
			}
			
			GUI.Label(new Rect(100, 210, 100, 50), "Tower Lvl 2 Cost");
			towerLvl2Cost = GUI.TextField(new Rect(200, 210, 100, 50),
				towerLvl2Cost);
			int towerLvl2CostOut;
			if(int.TryParse(towerLvl2Cost, out towerLvl2CostOut))
			{
				debugConfig.TOWER_UPGRADE_LEVEL_2_COST = towerLvl2CostOut;
			}
			
			GUI.Label(new Rect(350, 10, 100, 50), "Tower Base CD");
			towerBaseCD = GUI.TextField(new Rect(450, 10, 100, 50),
				towerBaseCD);
			float towerBaseCDOut;
			if(float.TryParse(towerBaseCD, out towerBaseCDOut))
			{
				debugConfig.BaseCooldown = towerBaseCDOut;
			}
			
			GUI.Label(new Rect(350, 60, 100, 50), "Tower Lvl 1 CD");
			towerLvl1CD = GUI.TextField(new Rect(450, 60, 100, 50),
				towerLvl1CD);
			float towerLvl1CDOut;
			if(float.TryParse(towerLvl1CD, out towerLvl1CDOut))
			{
				debugConfig.Level1Cooldown = towerLvl1CDOut;
			}
			
			GUI.Label(new Rect(350, 110, 100, 50), "Tower Lvl 2 CD");
			towerLvl2CD = GUI.TextField(new Rect(450, 110, 100, 50),
				towerLvl2CD);
			float towerLvl2CDOut;
			if(float.TryParse(towerLvl2CD, out towerLvl2CDOut))
			{
				debugConfig.Level2Cooldown = towerLvl2CDOut;
			}

			FPSActive = GUI.Toggle(new Rect(350, 160, 100, 20), FPSActive, "Toggle FPS");
			if (FPSActive)
			{
				debugConfig.FPSActive = true;
			} else
			{
				debugConfig.FPSActive = false;
			}

			debugActive = GUI.Toggle(new Rect(350, 180, 100, 20), debugActive, "Debug Active");
			if (debugActive)
			{
				debugConfig.debugActive = true;
			} else
			{
				debugConfig.debugActive = false;
			}

			GUI.Label(new Rect(350, 210, 100, 50), "Wave Timer");
			waveTimer = GUI.TextField(new Rect(450, 210, 100, 50),
			                          waveTimer);
			float waveTimerOut;
			if(float.TryParse(waveTimer, out waveTimerOut))
			{
				debugConfig.waveTimer = waveTimerOut;
			}

			GUI.Label(new Rect(550, 60, 100, 50), "Wave Delay");
			waveDelay = GUI.TextField(new Rect(650, 60, 100, 50),
			                          waveDelay);
			float waveDelayOut;
			if(float.TryParse(waveDelay, out waveDelayOut))
			{
				debugConfig.waveDelay = waveDelayOut;
			}

			GUI.Label(new Rect(550, 110, 100, 50), "Min Blobs");
			minBlobs = GUI.TextField(new Rect(650, 110, 100, 50),
			                          minBlobs);
			int minBlobsOut;
			if(int.TryParse(minBlobs, out minBlobsOut))
			{
				debugConfig.minBlobs = minBlobsOut;
			}

			GUI.Label(new Rect(550, 160, 100, 50), "Max Blobs");
			maxBlobs = GUI.TextField(new Rect(650, 160, 100, 50),
			                          maxBlobs);
			int maxBlobsOut;
			if(int.TryParse(maxBlobs, out maxBlobsOut))
			{
				debugConfig.maxBlobs = maxBlobsOut;
			}

			GUI.Label(new Rect(550, 210, 100, 50), "Colors (RYG)");
			colors = GUI.TextField(new Rect(650, 210, 100, 50),
			                         colors);
			ArrayList colorsOut = new ArrayList();
			colors = colors.ToLower();
			if(colors.Contains("r"))
			{
				colorsOut.Add(Color.red);
			}

			if(colors.Contains("y"))
			{
				colorsOut.Add(Color.yellow);
			}

			if(colors.Contains("g"))
			{
				colorsOut.Add(Color.green);
			}

			debugConfig.colors = colorsOut;
		}
	}
}
