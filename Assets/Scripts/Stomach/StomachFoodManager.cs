using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StomachFoodManager : MonoBehaviour 
{
	public GameObject stomachFoodBlob;
	private List<StomachFoodBlob> spawnedFoodBlobs = new List<StomachFoodBlob>();

	public float timeBetweenFoodSpawns;
	private float elapsedTime;
	
	// Update is called once per frame
	void Update () 
	{
		elapsedTime += Time.deltaTime;

		// keeps track of food blobs
		// when a food blob is digested it will need to be removed from the list of spawned blobs
		if (elapsedTime > timeBetweenFoodSpawns)
		{
			GameObject temp = (GameObject)Instantiate (stomachFoodBlob);
			temp.GetComponent<StomachFoodBlob>().parent = temp;
			spawnedFoodBlobs.Add(temp.GetComponent<StomachFoodBlob>());
			elapsedTime = 0f;
		}
	}

	public int getNumFoodBlobs()
	{
		return spawnedFoodBlobs.Count;
	}

	//TODO: implement
	public void removeFoodBlob()
	{
	}
}
