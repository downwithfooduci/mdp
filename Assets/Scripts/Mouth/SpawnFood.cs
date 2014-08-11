using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {
	public GameObject food;
	public Vector3 startingSpawn;
	public float SpawnInterval;
	EsophagusDebugConfig debugConfig;
	LoadScript loadScript;
	MouthWave[] waves;
	int currentWave;
	float waveDelay;
	float waveTime;
	float speed;
	openFlap flap;
	private float m_TimeSinceLastSpawn;
	public bool end = false;

	// Use this for initialization
	void Start () 
	{
		MouthLoadLevelCounter level = null;

		debugConfig = GameObject.Find("Debugger").GetComponent<EsophagusDebugConfig>();
		if (debugConfig == null)	// if we are starting the game directly we need to add debugger
		{
			debugConfig = gameObject.AddComponent("EsophagusDebugConfig") as EsophagusDebugConfig;
		}

		GameObject chooseBackground = GameObject.Find ("MouthChooseBackground");
		if (chooseBackground != null)
		{
			level = chooseBackground.GetComponent<MouthLoadLevelCounter>();
		} else // in this case we started the game load game properly
		{
			PlayerPrefs.SetInt("DesiredMouthLevel", 1);
			PlayerPrefs.Save();
			Application.LoadLevel("LoadLevelMouth");
		}

		// we also need to find the references to the flaps
		GameObject flaps = GameObject.Find("Flaps");
		flap = flaps.GetComponent<openFlap>();

		if (level != null)	// guard for if level was null since this will still execute before the load
		{
			// finally load the script
			loadScript = new LoadScript();
			waves = loadScript.loadMouthLevel(level.getLevel());
			currentWave = 0;
			waveDelay = waves[0].startDelay;
			waveTime = waves[0].runTime;
			SpawnInterval = waves[0].foodSpawnInterval;
			speed = waves[0].foodSpeed;
			m_TimeSinceLastSpawn = 0f;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(flap.isCough())
		{
			return;
		}
		if(waveDelay < 0 && !end)
		{
			waveTime -= Time.deltaTime;
			if(waveTime > 0)
			{
				if(debugConfig.debugActive)
					SpawnInterval = debugConfig.foodSpawnInterval;
				m_TimeSinceLastSpawn += Time.deltaTime;
				
				if (m_TimeSinceLastSpawn >= SpawnInterval)
				{
					GameObject foodInstance = (GameObject)Instantiate(food, startingSpawn, Quaternion.identity);
					MoveFood moveFoodScript = foodInstance.GetComponent<MoveFood>();
					moveFoodScript.foodSpeed = speed;
					m_TimeSinceLastSpawn = 0;
				}
			}
			else
			{
				if(debugConfig.debugActive)
				{
					waveDelay = debugConfig.waveDelay;
					waveTime = debugConfig.waveTime;
					SpawnInterval = debugConfig.foodSpawnInterval;
					speed = debugConfig.foodSpeed;
					m_TimeSinceLastSpawn = 0;
				}
				else
				{
					currentWave++;
					if(currentWave == waves.Length)
						end = true;
					else
					{
						waveDelay = waves[currentWave].startDelay;
						waveTime = waves[currentWave].runTime;
						SpawnInterval = waves[currentWave].foodSpawnInterval;
						speed = waves[currentWave].foodSpeed;
						m_TimeSinceLastSpawn = 0;
					}
				}
			}
		}
		else
		{
			waveDelay -= Time.deltaTime;
		}
	}
}
