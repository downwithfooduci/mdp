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
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// ignore if the bottom menu is clicked on
			if (ray.origin.z < -11.6)
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

		// for ipad
		foreach (Touch touch in Input.touches) 
		{
			if (touch.phase == TouchPhase.Began)
			{
				Ray ray = Camera.main.ScreenPointToRay(touch.position);
				RaycastHit hit;
				
				// ignore if the bottom menu is clicked on
				if (ray.origin.z < -11.6)
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
		}
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
