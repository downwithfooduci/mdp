using UnityEngine;
using System.Collections;

public class MouthGameManager : MonoBehaviour 
{
	// for holding the tracker
	private GameObject statTracker;
	private TrackMouthVariables trackStatVariables;

	// Use this for initialization
	void Start () 
	{
		resetStatTracker ();
	}
	
	// Update is called once per frame
	void Update () {}

	void resetStatTracker()
	{
		statTracker = GameObject.Find ("MouthStatTracker(Clone)");
		trackStatVariables = statTracker.GetComponent<TrackMouthVariables>();
		trackStatVariables.reset();
	}
}
