using UnityEngine;
using System.Collections;

public class SpawnManagerTutorial : MonoBehaviour 
{
	public GameObject SpawnType;
	public Vector3 SpawnPoint;
	// In seconds
	public float SpawnInterval;
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
		GameObject counter = GameObject.Find ("ChooseBackground");
		SmallIntestineLoadLevelCounter level = counter.GetComponent<SmallIntestineLoadLevelCounter> ();

		// load script and add in information
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
	
	// Update is called once per frame
	void Update () 
	{
		if(waveDelay < 0 && !end)
		{
			waveTime -= Time.deltaTime;
			if(waveTime > 0)
			{
				m_TimeSinceLastSpawn += Time.deltaTime;
				
				if (m_TimeSinceLastSpawn >= SpawnInterval)
				{
					SpawnBlob();
					m_TimeSinceLastSpawn = 0;
				}
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
		FoodBlobTutorial blobScript = blob.GetComponent<FoodBlobTutorial>();
		blobScript.GenerateEnzymes(minNutrients, maxNutrients, availableColors);
	}
}
