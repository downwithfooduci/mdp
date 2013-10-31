using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public GameObject SpawnType;
    public Vector3 SpawnPoint;
    // In seconds
    public float SpawnInterval;
	DebugConfig debugConfig;

    private float m_TimeSinceLastSpawn;

	// Use this for initialization
	void Start () {
        m_TimeSinceLastSpawn = 0f;
		debugConfig = ((GameObject)GameObject.Find("Debug Config")).GetComponent<DebugConfig>();
	}
	
	// Update is called once per frame
	void Update () {
		SpawnInterval = debugConfig.NutrientSpawnInterval;
        m_TimeSinceLastSpawn += Time.deltaTime;

        if (m_TimeSinceLastSpawn >= SpawnInterval)
        {
            SpawnBlob();
            m_TimeSinceLastSpawn = 0;
        }
	}

    private void SpawnBlob()
    {
        Instantiate(SpawnType, SpawnPoint, Quaternion.identity);
    }
}
