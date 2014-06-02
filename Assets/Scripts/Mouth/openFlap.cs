using UnityEngine;
using System.Collections;

public class openFlap : MonoBehaviour {
	GameObject bottomFlap, topFlap;
	Vector3 originalPositionBottomFlap, originalPositionTopFlap, center;
	float moved = 0;
	bool isOpen;
	Plane plane;
	bool cough = false;
	float coughTimer, coughTime;
	// Use this for initialization
	void Start () {
		plane = new Plane( new Vector3(0, 0, -1), new Vector3(0, 0, -1));
		coughTime = 3f;
		coughTimer = 0;
		foreach(Transform child in transform)
		{
			if(child.gameObject.name == "flap1")
			{
				bottomFlap = child.gameObject;
			}
			else
			{
				topFlap = child.gameObject;
			}
		}
		originalPositionBottomFlap = bottomFlap.transform.localPosition;
		originalPositionTopFlap = topFlap.transform.localPosition;
		Vector3 diffVect = topFlap.transform.position - bottomFlap.transform.position;
		diffVect /= 2;
		center = bottomFlap.transform.position + diffVect;
	}
	
	// Update is called once per frame
	void Update () {
		if(coughTimer > 0)
		{
			coughTimer -= Time.deltaTime;
			moved = .35f;
			bottomFlap.transform.localPosition = originalPositionBottomFlap - bottomFlap.transform.up * moved;
			topFlap.transform.localPosition = originalPositionTopFlap + topFlap.transform.up * moved;
			return;
		}
		cough = false;
		if(Input.touches.Length == 2)
		{
			Touch topTouch, bottomTouch;
			if(Input.touches[0].position.y > Input.touches[1].position.y)
			{
				topTouch = Input.touches[0];
				bottomTouch = Input.touches[1];
			}
			else
			{
				topTouch = Input.touches[1];
				bottomTouch = Input.touches[0];
			}

			Ray topRay = Camera.main.ScreenPointToRay(topTouch.position);
			Ray bottomRay = Camera.main.ScreenPointToRay(bottomTouch.position);
			float topDist;
			float bottomDist;
			Vector3 topTouchPos = Vector3.zero;
			Vector3 bottomTouchPos = Vector3.zero;
			if (plane.Raycast(topRay, out topDist)){
				topTouchPos = topRay.GetPoint(topDist); // get the plane point hit
			}
			if (plane.Raycast(bottomRay, out bottomDist)){
				bottomTouchPos = bottomRay.GetPoint(bottomDist); // get the plane point hit
			}
			Vector3 diffVect = bottomTouchPos - topTouchPos;
			diffVect /= 2;
			Vector3 touchCenter = topTouchPos + diffVect;

			if(Vector3.Distance(touchCenter, center) < .5)
			{
				moved = Mathf.Clamp(moved + 
				                    topTouch.deltaPosition.y / 20f - 
				                    bottomTouch.deltaPosition.y / 20f, 0, .55f);
			}
		}
		if(Input.GetKey(KeyCode.A))
		{
			moved = Mathf.Clamp(moved - .3f * Time.deltaTime, 0, .55f);
		}
		else if(Input.GetKey(KeyCode.D))
		{
			moved = Mathf.Clamp(moved + .3f * Time.deltaTime, 0, .55f);
		}
		isOpen = moved >= .35f;
		bottomFlap.transform.localPosition = originalPositionBottomFlap - bottomFlap.transform.up * moved;
		topFlap.transform.localPosition = originalPositionTopFlap + topFlap.transform.up * moved;
	}

	public bool isEpiglotisOpen()
	{
		return isOpen;
	}

	public void setCough()
	{
		if(!audio.isPlaying)
		{
			audio.Play();
		}
		coughTimer = coughTime;
		cough = true;
	}

	public bool isCough()
	{
		return cough;
	}

}
