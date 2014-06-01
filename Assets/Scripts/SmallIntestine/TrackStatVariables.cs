using UnityEngine;
using System.Collections;

public class TrackStatVariables : MonoBehaviour 
{
	// list desired stats for tracking here
	private int nutrientsEarned;
	private int nutrientsSpent;
	private int foodLost;
	private int towersPlaced;
	private int towersSold;
	private int towersUpgraded;
	private int enzymesFired;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void increaseNutrientsEarned(int amount)
	{
		nutrientsEarned += amount;
	}

	public int getNutrientsEarned()
	{
		return nutrientsEarned;
	}

	public void increaseNutrientsSpent(int amount)
	{
		nutrientsSpent += amount;
	}
	
	public int getNutrientsSpent()
	{
		return nutrientsSpent;
	}

	public void increaseFoodLost(int amount)
	{
		foodLost += amount;
	}

	public int getFoodLost()
	{
		return foodLost;
	}

	public void increaseTowersPlaced()
	{
		towersPlaced++;
	}
	
	public int getTowersPlaced()
	{
		return towersPlaced;
	}

	public void increaseTowersSold()
	{
		towersSold++;
	}
	
	public int getTowersSold()
	{
		return towersSold;
	}

	public void increaseTowersUpgraded()
	{
		towersUpgraded++;
	}
	
	public int getTowersUpgraded()
	{
		return towersUpgraded;
	}

	public void increaseEnzymesFired()
	{
		enzymesFired++;
	}

	public int getEnzymesFired()
	{
		return enzymesFired;
	}

	public void reset()
	{
		nutrientsEarned = 0;
		nutrientsSpent = 0;
		foodLost = 0;
		towersPlaced = 0;
		towersSold = 0;
		towersUpgraded = 0;
		enzymesFired = 0;
	}

	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
	}
}
