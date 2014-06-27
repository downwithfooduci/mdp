using UnityEngine;
using System.Collections;

public class openFlap : MonoBehaviour 
{
	GameObject bottomFlap, topFlap;
	float moved = 0;
	bool isOpen;
	Plane plane;
	bool cough = false;
	float coughTimer, coughTime;

	// swipe varaibles
	private float xStart = 0.0f;
	private float xEnd = 0.0f;
	private float yStart = 0.0f;
	private float yEnd = 0.0f;
	private bool swipe = false;

	// Use this for initialization
	void Start () 
	{
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
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(coughTimer > 0)
		{
			coughTimer -= Time.deltaTime;
			return;
		}
	
		cough = false;

		foreach (Touch touch in Input.touches) 
		{
			if (touch.phase == TouchPhase.Began) 
			{
				Debug.Log("began (x,y): " + touch.position.x + "," + touch.position.y);
				if ((touch.position.x >= .5f*Screen.width && touch.position.x <= Screen.width) && 
					(touch.position.y <= .3f*Screen.height && touch.position.y >= .9f*Screen.height))
				{
					xStart = touch.position.x;
					yStart = touch.position.y;
				}
			}
			if (touch.phase == TouchPhase.Moved) 
			{
				Debug.Log("end (x,y): " + touch.position.x + "," + touch.position.y);
				if ((touch.position.x >= .5f*Screen.width && touch.position.x <= Screen.width) && 
				    (touch.position.y <= .3f*Screen.height && touch.position.y >= .9f*Screen.height))
				{
					xEnd = touch.position.x;
					yEnd = touch.position.y;
				}
				
				if (Mathf.Sqrt((xStart - xEnd)*(xStart - xEnd)+(yStart - yEnd)*(yStart - yEnd)) > 20) 
				{
					swipe = true;
				}
			}
		}

		// for PC/MAC version
		if(Input.GetKey(KeyCode.A))
		{
			isOpen = false;
			bottomFlap.GetComponent<BoxCollider>().enabled = true;
			topFlap.GetComponent<BoxCollider>().enabled = true;
		}
		else if(Input.GetKey(KeyCode.D))
		{
			isOpen = true;
			bottomFlap.GetComponent<BoxCollider>().enabled = false;
			topFlap.GetComponent<BoxCollider>().enabled = false;
		}

		if (swipe)
		{
			isOpen = !isOpen;
			bottomFlap.GetComponent<BoxCollider>().enabled = !bottomFlap.GetComponent<BoxCollider>().enabled;
			topFlap.GetComponent<BoxCollider>().enabled = !topFlap.GetComponent<BoxCollider>().enabled;

			// reset variables
			xStart = 0.0f;
			xEnd = 0.0f;
			yStart = 0.0f;
			yEnd = 0.0f;
			swipe = false;
		}
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
		coughTimer = .950f;
		cough = true;
	}

	public bool isCough()
	{
		return cough;
	}
}
