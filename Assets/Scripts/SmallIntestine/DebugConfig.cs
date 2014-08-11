using UnityEngine;
using System.Collections;

public class DebugConfig : MonoBehaviour 
{
	public float NutrientSpeed = 2f;
	public float NutrientSpawnInterval = 3.5f;
	public float BaseCooldown = 2f;
	public float Level1Cooldown = 1f;
	public float Level2Cooldown = .5f;
	public int baseTargets = 1;
	public int level1Targets = 3;
	public int level2Targets = 6;
	public int TOWER_BASE_COST = 20;
	public int TOWER_UPGRADE_LEVEL_1_COST = 50;
	public int TOWER_UPGRADE_LEVEL_2_COST = 50;
	public bool FPSActive = false;
	public bool debugActive = false;
	public float waveTimer = 30;
	public float waveDelay = 10;
	public int minBlobs = 1;
	public int maxBlobs = 5;
	public ArrayList colors = new ArrayList();
	// Use this for initialization
	void Start () {
		colors.Add(Color.red);
		colors.Add(Color.yellow);
		colors.Add(Color.green);
	}
	
	// Update is called once per frame
	void Update () {}
}
