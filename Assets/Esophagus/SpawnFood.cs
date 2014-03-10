using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {
	public GameObject food;
	public Vector3 startingSpawn;
	public int spawnDelay = 1;
	float timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(timer > 0)
		{
			timer -= Time.deltaTime;
		}
		else
		{
			timer = 1;
			Instantiate(food, startingSpawn, Quaternion.identity);
		}
	}
}
