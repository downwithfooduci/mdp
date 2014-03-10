using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {
	public GameObject food;
	public Vector3 startingSpawn;
	public float spawnDelay = 1f;
	float timer = 0;
	EsophagusDebugConfig debugConfig;
	// Use this for initialization
	void Start () {
		GameObject debugger = GameObject.Find("Debugger");
		debugConfig = debugger.GetComponent<EsophagusDebugConfig>();
	}
	
	// Update is called once per frame
	void Update () {
		if(debugConfig.debugActive)
			spawnDelay = debugConfig.foodSpawnDelay;
		else
			spawnDelay = 1f;
		if(timer > 0)
		{
			timer -= Time.deltaTime;
		}
		else
		{
			timer = spawnDelay;
			Instantiate(food, startingSpawn, Quaternion.identity);
		}
	}
}
