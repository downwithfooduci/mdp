using UnityEngine;
using System.Collections;

public class openFlap : MonoBehaviour {
	GameObject bottomFlap, topFlap;
	Vector3 originalPositionBottomFlap, originalPositionTopFlap, center;
	float moved = 0;
	bool isOpen;
	// Use this for initialization
	void Start () {
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

			Vector3 topTouchPos = Camera.main.ScreenToWorldPoint(topTouch.position);
			Vector3 bottomTouchPos = Camera.main.ScreenToWorldPoint(bottomTouch.position);
			topTouchPos = new Vector3(topTouchPos.x, topTouchPos.y, center.z);
			bottomTouchPos = new Vector3(bottomTouchPos.x, bottomTouchPos.y, center.z);

			Vector3 diffVect = bottomTouchPos - topTouchPos;
			diffVect /= 2;
			Vector3 touchCenter = topTouchPos + diffVect;

			if(Vector3.Distance(touchCenter, center) < 4)
			{
				moved = Mathf.Clamp(moved + 
				                    topTouch.deltaPosition.y / 20f - 
				                    bottomTouch.deltaPosition.y / 20f, 0, .22f);
			}
		}
		if(Input.GetKey(KeyCode.A))
		{
			moved = Mathf.Clamp(moved - .3f * Time.deltaTime, 0, .22f);
		}
		else if(Input.GetKey(KeyCode.D))
		{
			moved = Mathf.Clamp(moved + .3f * Time.deltaTime, 0, .22f);
		}
		isOpen = moved > .15f;
		bottomFlap.transform.localPosition = originalPositionBottomFlap - bottomFlap.transform.up * moved;
		topFlap.transform.localPosition = originalPositionTopFlap + topFlap.transform.up * moved;
	}

	public bool isEpiglotisOpen()
	{
		return isOpen;
	}
}
