using UnityEngine;
using System.Collections;

public class GrowAndDie : MonoBehaviour {
	float timeAlive = 0;
	Vector3 originalScale;
	// Use this for initialization
	void Start () 
	{
		originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		timeAlive += Time.deltaTime;
		if (timeAlive < 1.0f) 
		{
			transform.localScale = originalScale + new Vector3(timeAlive, timeAlive, timeAlive);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
}
