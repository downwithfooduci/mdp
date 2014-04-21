using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {
	public GameObject food;
	public Vector3 startingSpawn;
	public float spawnDelay = 1f;
	float timer = 0;
	EsophagusDebugConfig debugConfig;
	openFlap flap;
	// Use this for initialization
	void Start () {
		GameObject flaps = GameObject.Find("Flaps");
		flap = flaps.GetComponent<openFlap>();
		startingSpawn = new Vector3 (-4.696645f, 3.66696f, -0.9300022f);
		GameObject debugger = GameObject.Find("Debugger");
		debugConfig = debugger.GetComponent<EsophagusDebugConfig>();
	}
	
	// Update is called once per frame
	void Update () {
		if(flap.isCough())
		{
			return;
		}
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
