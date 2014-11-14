using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StomachFoodManager : MonoBehaviour 
{
	public GameObject stomachFoodBlob;
	private List<StomachFoodBlob> spawnedFoodBlobs = new List<StomachFoodBlob>();

	public float timeBetweenFoodSpawns;
	private float elapsedTime;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		elapsedTime += Time.deltaTime;

		if (elapsedTime > timeBetweenFoodSpawns)
		{
			GameObject temp = (GameObject)Instantiate (stomachFoodBlob);
			spawnedFoodBlobs.Add(stomachFoodBlob.GetComponent<StomachFoodBlob>());
			elapsedTime = 0f;
		}
	}
}
