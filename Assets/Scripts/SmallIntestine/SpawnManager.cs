using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public GameObject SpawnType;
    public Vector3 SpawnPoint;
    // In seconds
    public float SpawnInterval;
	DebugConfig debugConfig;
	LoadScript loadScript;
	Wave[] waves;
	int currentWave;
	float waveDelay;
	float waveTime;
	float speed;
	int minNutrients;
	int maxNutrients;
	public bool end = false;
	Color[] availableColors;

    private float m_TimeSinceLastSpawn;

	// Use this for initialization
	void Start () 
	{
		GameObject counter = GameObject.Find ("ChooseBackground");
		SmallIntestineLoadLevelCounter level = counter.GetComponent<SmallIntestineLoadLevelCounter> ();
		loadScript = ((GameObject)GameObject.Find("ScriptLoader")).GetComponent<LoadScript>();
		waves = loadScript.loadIntestineLevel(level.getLevel());
		currentWave = 0;
		waveDelay = waves[0].startDelay;
		waveTime = waves[0].runTime;
		SpawnInterval = waves[0].nutrientSpawnInterval;
		speed = waves[0].nutrientSpeed;
		availableColors = waves[0].colors;
		minNutrients = waves[0].minBlobs;
		maxNutrients = waves[0].maxBlobs;
        m_TimeSinceLastSpawn = 0f;
		debugConfig = ((GameObject)GameObject.Find("Debug Config")).GetComponent<DebugConfig>();
	}
	
	// Update is called once per frame
	void Update () {
		if(waveDelay < 0 && !end)
		{
			waveTime -= Time.deltaTime;
			if(waveTime > 0)
			{
				if(debugConfig.debugActive)
					SpawnInterval = debugConfig.NutrientSpawnInterval;
		        m_TimeSinceLastSpawn += Time.deltaTime;

		        if (m_TimeSinceLastSpawn >= SpawnInterval)
		        {
		            SpawnBlob();
		            m_TimeSinceLastSpawn = 0;
		        }
			}
			else
			{
				if(debugConfig.debugActive)
				{
					waveDelay = debugConfig.waveDelay;
					waveTime = debugConfig.waveTimer;
					SpawnInterval = debugConfig.NutrientSpawnInterval;
					speed = debugConfig.NutrientSpeed;
					availableColors = new Color[debugConfig.colors.Count];
					for(int i = 0; i < debugConfig.colors.Count; i++)
						availableColors[i] = (Color)debugConfig.colors[i];
					minNutrients = debugConfig.minBlobs;
					maxNutrients = debugConfig.maxBlobs;
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
						SpawnInterval = waves[currentWave].nutrientSpawnInterval;
						speed = waves[currentWave].nutrientSpeed;
						availableColors = waves[currentWave].colors;
						minNutrients = waves[currentWave].minBlobs;
						maxNutrients = waves[currentWave].maxBlobs;
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

    private void SpawnBlob()
    {
        GameObject blob = (GameObject)Instantiate(SpawnType, SpawnPoint, Quaternion.identity);
		FollowITweenPath path = blob.GetComponent<FollowITweenPath>();
		path.nutrientSpeed = speed;
		FoodBlob blobScript = blob.GetComponent<FoodBlob>();
		blobScript.GenerateEnzymes(minNutrients, maxNutrients, availableColors);
    }
}
