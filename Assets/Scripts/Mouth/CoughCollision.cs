using UnityEngine;
using System.Collections;

public class CoughCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name.Contains ("foodstuff"))
		{
			openFlap flap = transform.parent.gameObject.GetComponent<openFlap>();
			flap.setCough();
		}
	}
}
