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

		if (elapsedTime > timeBetweenFoodSpawns)
		{
			GameObject temp = (GameObject)Instantiate (stomachFoodBlob);
			temp.GetComponent<StomachFoodBlob>().parent = temp;
			spawnedFoodBlobs.Add(temp.GetComponent<StomachFoodBlob>());
			elapsedTime = 0f;
		}
	}
}
