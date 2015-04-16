using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Manager for stomach food
 */
public class StomachFoodManager : MonoBehaviour 
{
	public GameObject stomachFoodBlob;				//!< to hold the gameobject for stomach food blobs
	
	// create a list to hold all the stomach food blobs currently in the game
	private List<StomachFoodBlob> spawnedFoodBlobs = new List<StomachFoodBlob>();
	
	public float timeBetweenFoodSpawns;				//!< for the time between food spawns
	private float elapsedTime;						//!< to count elapsed time to see if we should create a new food blob

	private int foodflag;

	/**
	 * Update is called once per frame
	 */
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
	
	/**
	 * Returns the number of food blobs current in the list
	 */
	public int getNumFoodBlobs()
	{
		return spawnedFoodBlobs.Count;
	}

	public int getFoodFlag()
	{
		return foodflag;
	}

	/**
	 * Returns if there is any food blobs or not
	 */
	public bool noFoodBlobs()
	{
		if (getNumFoodBlobs()<=foodflag) {
			return true;
		} 
		else
			return false;
	}

	/*Add the foodflag every time a food blob is deleted*/
	
	public void FlagAdded()
	{
		foodflag++;
	}

	/*
	 * Returns the location of the first food blob
	 */
	public Vector2 locFirstFoodBolb()
	{
		Vector2 p;
		int i = 0;
		if (noFoodBlobs()){
			p = new Vector3(0f,0f);
			Debug.Log("No FoodBlobs");
		} 
		else {
			Debug.Log("Total Count:"+ getNumFoodBlobs());
			Debug.Log("Current Count:"+ foodflag);
			
			p = spawnedFoodBlobs[foodflag].transform.position;
			
		}
		
		return p;
	}

	
	//TODO: implement
	public void removeFoodBlob()
	{
	}
}