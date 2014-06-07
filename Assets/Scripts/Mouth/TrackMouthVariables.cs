using UnityEngine;
using System.Collections;

public class TrackMouthVariables : MonoBehaviour {
	int longestStreak;
	int timesCoughed;
	int foodLost;
	int foodSwallowed;
	int highestMultiplier;
	int score;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setLongestStreak(int newStreak)
	{
		longestStreak = newStreak > longestStreak ? newStreak : longestStreak;
		if(longestStreak >= 8)
			highestMultiplier = 16;
		else if(longestStreak >= 4)
			highestMultiplier = 4;
	}

	public int getLongestStreak()
	{
		return longestStreak;
	}

	public void cough()
	{
		timesCoughed++;
	}

	public int getTimesCoughed()
	{
		return timesCoughed;
	}

	public void loseFood()
	{
		foodLost++;
	}

	public int getFoodLost()
	{
		return foodLost;
	}

	public void swallowFood()
	{
		foodSwallowed++;
	}

	public int getFoodSwallowed()
	{
		return foodSwallowed;
	}

	public int getHighestMultiplier()
	{
		return highestMultiplier;
	}

	public void setScore(int score)
	{
		this.score = score;
	}

	public int getScore()
	{
		return score;
	}

	public void reset()
	{
		longestStreak = 0;
		timesCoughed = 0;
		foodLost = 0;
		foodSwallowed = 0;
		highestMultiplier = 0;
		score = 0;
	}
	
	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
	}
}
