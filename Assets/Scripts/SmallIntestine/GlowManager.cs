using UnityEngine;
using System.Collections;

public class GlowManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// for on pc/mac
		if (Input.GetButtonDown("Fire1")) 
		{
			checkClickArea();

		}

		// for ipad
		foreach (Touch touch in Input.touches) 
		{
			if (touch.phase == TouchPhase.Began)
			{
				checkClickArea();
			}
		}
	}

	void checkClickArea()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.Log (ray.origin);
		RaycastHit hit;
		
		// ignore if the bottom menu is clicked on
		if (ray.origin.z < -11.6)
		{
			return;
		}
		
		// check for menu button click
		if (ray.origin.x > 19.7 && ray.origin.z > 16)
		{
			return;
		}
		
		// check for 2x speed click
		if (ray.origin.x < -22 && ray.origin.z < -8.8)
		{
			return;
		}
		
		// if menu box is up don't light
		if (Time.timeScale < .01f)
		{
			return;
		}
		
		// ignore if a tower is directly clicked on
		if (Physics.Raycast(ray, out hit, 20))
		{
			Debug.Log (hit.transform.gameObject.name);
			if (hit.transform.gameObject.name.Contains("Tower"))
			{
				return;
			}
		}
		
		GameObject closestSegment = FindClosestSegment(ray.origin);
		GlowSegment glowScript = closestSegment.GetComponent<GlowSegment> ();
		glowScript.onTouch ();
	}

	GameObject FindClosestSegment(Vector3 pos) 
	{
		GameObject[] segment;
		segment = GameObject.FindGameObjectsWithTag("glow");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = pos;

		foreach (GameObject seg in segment) 
		{
			Vector3 diff = seg.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) 
			{
				closest = seg;
				distance = curDistance;
			}
		}

		return closest;
	}
}
