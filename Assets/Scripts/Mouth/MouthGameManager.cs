using UnityEngine;
using System.Collections;

public class MouthGameManager : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		resetStats ();
	}

	void resetStats()
	{
		PlayerPrefs.DeleteKey("MouthStats_longestStreak");
		PlayerPrefs.DeleteKey("MouthStats_timesCoughed");
		PlayerPrefs.DeleteKey("MouthStats_foodLost");
		PlayerPrefs.DeleteKey("MouthStats_foodSwallowed");
		PlayerPrefs.DeleteKey("MouthStats_highestMultiplier");
		PlayerPrefs.DeleteKey("MouthStats_score");
		PlayerPrefs.Save();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
