using UnityEngine;
using System.Collections;

public class openFlap : MonoBehaviour 
{
	GameObject bottomFlap, topFlap;
	private bool isOpen;
	Plane plane;
	bool cough = false;
	float coughTimer, coughTime;

	// swipe varaibles
	private float xStart = 0.0f;
	private float xEnd = 0.0f;
	private float yStart = 0.0f;
	private float yEnd = 0.0f;
	private bool swipe = false;
	private bool swipeUp = false;
	private bool swipeDown = false;

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
		// update the coughing variable accordinly to maintain proper collision detection
		if (coughTimer > 0)
		{
			coughTimer -= Time.deltaTime;
		} else
		{
			cough = false;
		}

		// ipad touch detection
		foreach (Touch touch in Input.touches) 
		{
			if (touch.phase == TouchPhase.Began) 
			{
				if ((touch.position.x >= .3f*Screen.width && touch.position.x <= Screen.width) && 
				    (touch.position.y <= .8f*Screen.height && touch.position.y >= 0))
				{
					xStart = touch.position.x;
					yStart = touch.position.y;
				}
			}

			if (touch.phase == TouchPhase.Ended)
			{
				if ((touch.position.x >= .3f*Screen.width && touch.position.x <= Screen.width) && 
				    (touch.position.y <= .8f*Screen.height && touch.position.y >= 0))
				{
					xEnd = touch.position.x;
					yEnd = touch.position.y;
				}
				
				if (Mathf.Sqrt((xStart - xEnd)*(xStart - xEnd)+(yStart - yEnd)*(yStart - yEnd)) > 10) 
				{
					swipe = true;
					
					if (yStart < yEnd)
					{
						swipeUp = true;
					} else if (yStart > yEnd)
					{
						swipeDown = true;
					} else
					{
						swipeDown = !swipeDown;
						swipeUp = !swipeUp;
					}
				}
			}
		}

		// for PC/MAC version
		if(Input.GetMouseButtonDown(0))
		{
			if ((Input.mousePosition.x >= .3f*Screen.width && Input.mousePosition.x <= Screen.width) && 
			    (Input.mousePosition.y <= .8f*Screen.height && Input.mousePosition.y >= 0))
			{
				xStart = Input.mousePosition.x;
				yStart = Input.mousePosition.y;
			}
		}

		if(Input.GetMouseButtonUp(0))
		{
			if ((Input.mousePosition.x >= .3f*Screen.width && Input.mousePosition.x <= Screen.width) && 
			    (Input.mousePosition.y <= .8f*Screen.height && Input.mousePosition.y >= 0))
			{
				xEnd = Input.mousePosition.x;
				yEnd = Input.mousePosition.y;
			}

			if (Mathf.Sqrt((xStart - xEnd)*(xStart - xEnd)+(yStart - yEnd)*(yStart - yEnd)) > 10) 
			{
				swipe = true;
			
				if (yStart < yEnd)
				{
					swipeUp = true;
				} else if (yStart > yEnd)
				{
					swipeDown = true;
				} else
				{
					swipeDown = !swipeDown;
					swipeUp = !swipeUp;
				}
			}
		}
	
		if (swipe)
		{
			if (swipeUp)
			{
				isOpen = false;
				bottomFlap.GetComponent<BoxCollider>().enabled = true;
				topFlap.GetComponent<BoxCollider>().enabled = true;

				// reset variables
				xStart = 0.0f;
				xEnd = 0.0f;
				yStart = 0.0f;
				yEnd = 0.0f;
				swipeUp = false;
			} else if (swipeDown)
			{
				isOpen = true;
				bottomFlap.GetComponent<BoxCollider>().enabled = false;
				topFlap.GetComponent<BoxCollider>().enabled = false;
				
				// reset variables
				xStart = 0.0f;
				xEnd = 0.0f;
				yStart = 0.0f;
				yEnd = 0.0f;
				swipeDown = false;
			}
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
