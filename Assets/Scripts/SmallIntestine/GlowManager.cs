using UnityEngine;
using System.Collections;

public class GlowManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Fire1")) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			GameObject closestSegment = FindClosestSegment(ray.origin);
			GlowSegment glowScript = closestSegment.GetComponent<GlowSegment> ();
			glowScript.onTouch ();
		}
	}

	GameObject FindClosestSegment(Vector3 pos) 
	{
		GameObject[] segment;
		segment = GameObject.FindGameObjectsWithTag("glow");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = pos;
		Debug.Log ("position of click: " + position);

		foreach (GameObject seg in segment) 
		{
			Debug.Log ("Distance : " + distance);
			Vector3 diff = seg.transform.position - position;
			Debug.Log (seg.transform.position);
			float curDistance = diff.sqrMagnitude;
			Debug.Log("curDist: " + curDistance);
			if (curDistance < distance) 
			{
				closest = seg;
				Debug.Log("current closest: " + closest.gameObject.name);
				distance = curDistance;
			}
		}

		return closest;
	}
}
