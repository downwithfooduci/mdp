using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour 
{
    public GameObject SpawnType;
    public Vector3 SpawnPoint;
    // In seconds
    public float SpawnInterval;
	DebugConfig debugConfig;
	LoadScript loadScript;
	SIWave[] waves;
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
		SmallIntestineLoadLevelCounter level = null;

		GameObject counter = GameObject.Find ("ChooseBackground");
	
		if (counter != null)
		{
			// if the counter was there we can just get the level
			level = counter.GetComponent<SmallIntestineLoadLevelCounter> ();
		} else // if we start the level from the game itself just start at level 0, 1, or 2 appropriately
		{ 
			// if the counter wasn't there reload properly
			if (Application.loadedLevelName == "SmallIntestineTutorial")
			{
				PlayerPrefs.SetInt("DesiredSILevel", 0);
				PlayerPrefs.Save();
				Application.LoadLevel("LoadLevelSmallIntestine");
			} else if (Application.loadedLevelName == "SmallIntestineOdd")
			{
				PlayerPrefs.SetInt("DesiredSILevel", 1);
				PlayerPrefs.Save();
				Application.LoadLevel("LoadLevelSmallIntestine");
			} else if (Application.loadedLevelName == "SmallIntestineEven")
			{
				PlayerPrefs.SetInt("DesiredSILevel", 2);
				PlayerPrefs.Save();
				Application.LoadLevel("LoadLevelSmallIntestine");;
			}
		}

		// load in the script info
		if (counter != null)	// guard check
		{
			loadScript = new LoadScript();
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
		}

		// we don't use debug config in the tutorial level
		if (Application.loadedLevelName != "SmallIntestineTutorial")
		{
			debugConfig = ((GameObject)GameObject.Find("Debug Config")).GetComponent<DebugConfig>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(waveDelay < 0 && !end)
		{
			waveTime -= Time.deltaTime;
			if(waveTime > 0)
			{
				if (Application.loadedLevelName != "SmallIntestineTutorial")
				{
					if(debugConfig.debugActive)
					{
						SpawnInterval = debugConfig.NutrientSpawnInterval;
					}
				}

				m_TimeSinceLastSpawn += Time.deltaTime;

		        if (m_TimeSinceLastSpawn >= SpawnInterval)
		        {
		            SpawnBlob();
		            m_TimeSinceLastSpawn = 0;
		        }
			}
			else
			{
				if(Application.loadedLevelName != "SmallIntestineTutorial" && debugConfig.debugActive)
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
