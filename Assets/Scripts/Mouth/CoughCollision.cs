using UnityEngine;
using System.Collections;

public class CoughCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(UnityEngine.Collider other)
	{
		if(other.gameObject.name.Contains ("foodstuff"))
		{
			openFlap flap = transform.parent.gameObject.GetComponent<openFlap>();
			flap.setCough();
		}
	}
}
