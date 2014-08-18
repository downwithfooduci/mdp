using UnityEngine;
using System.Collections;

// script to handle cough collisions in the mouth game
public class CoughCollision : MonoBehaviour 
{
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	// on trigger enter is called when the object enters a collision
	void OnTriggerEnter(UnityEngine.Collider other)
	{
		if(other.gameObject.name.Contains ("foodstuff"))	// check to see if the flaps collided with something
															// with the tag "foodstuff"
		{
			// track stats
			PlayerPrefs.SetInt("MouthStats_timesCoughed", PlayerPrefs.GetInt("MouthStats_timesCoughed") + 1);
			PlayerPrefs.Save ();

			// find the oxygen bar to update it
			OxygenBar oxygen = GameObject.Find("MouthGUI").GetComponent<OxygenBar>();
			oxygen.percent -= .07f;			// on cough we decrease oxygen by a chunk amount as a penalty

			// get the script "openFlap" on the flaps
			openFlap flap = transform.parent.gameObject.GetComponent<openFlap>();	
			flap.setCough();				// set the cough indicate variable on the script
		}
	}
}
