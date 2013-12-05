using UnityEngine;
using System.Collections;

public class createPlus : MonoBehaviour {
	public GameObject plus;
	float spawnTime = 1.2f;
	float totalTime = 0;
	// Use this for initialization
	void Start () {
	}

	
	// Update is called once per frame
	void Update () {
		totalTime += Time.deltaTime;
		if(totalTime > spawnTime)
		{
			Instantiate(plus, this.transform.position + this.transform.forward * 3.5f + new Vector3(0,1,0), plus.transform.rotation);
			totalTime = 0;
		}
	}
}
