using UnityEngine;
using System.Collections;

public class CoughCollision : MonoBehaviour 
{

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	void OnTriggerEnter(UnityEngine.Collider other)
	{
		if(other.gameObject.name.Contains ("foodstuff"))
		{
			// track stats
			PlayerPrefs.SetInt("MouthStats_timesCoughed", PlayerPrefs.GetInt("MouthStats_timesCoughed") + 1);
			PlayerPrefs.Save ();

			OxygenBar oxygen = GameObject.Find("MouthGUI").GetComponent<OxygenBar>();
			oxygen.percent -= .07f;
			openFlap flap = transform.parent.gameObject.GetComponent<openFlap>();
			flap.setCough();
		}
	}
}
