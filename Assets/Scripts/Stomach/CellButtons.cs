using UnityEngine;
using System.Collections;

/**
 * Handles the menu functions for when a cell is clicked on
 */
public class CellButtons : MonoBehaviour 
{
	public GUIStyle singButton;
	public GUIStyle mucousButton;
	public GUIStyle dieButton;
	
	public GUIStyle bucket;
	public GUIStyle scythe;
	private bool showBucket;
	private bool showScythe;

	private bool wasMouseClicked;
	private bool mouseDownLastFrame;
	private bool isEnabled;
	private Vector2 mouseClickLocation;

	private Vector2 buttonSize;
	private Vector2 button1SpawnLocation;
	private Vector2 button2SpawnLocation;
	private Vector2 button3SpawnLocation;

	private int menuSemaphore;

	void Start()
	{
		buttonSize.x = Screen.width * (186f / 1024f);
		buttonSize.y = Screen.height * (253f / 768f);
	}

	// Update is called once per frame
	void Update () 
	{
		wasMouseClicked = Input.GetMouseButton (0);

		// check if the mouse was down last frame, but is not currently pressed
		if (mouseDownLastFrame && !wasMouseClicked)
		{
			mouseClickLocation.x = Input.mousePosition.x;
			mouseClickLocation.y = Input.mousePosition.y;
			checkMouseClick();	
		}

		mouseDownLastFrame = wasMouseClicked;

		if (menuSemaphore > 0)
		{
			menuSemaphore--;
		}
	}
	
	private void checkMouseClick()
	{	
		if (menuSemaphore <= 0 &&
		    !isEnabled &&
		    (mouseClickLocation.x > .3f*Screen.width && mouseClickLocation.x < .7f*Screen.width) &&
		    (mouseClickLocation.y < Screen.height && mouseClickLocation.y > .5f*Screen.height)) 
		{
			isEnabled = true;
		} else
		{
			isEnabled = false;
			menuSemaphore = 10;
		}
	}

	void OnGUI()
	{
		GUI.depth = GUI.depth - 20;

		if (showBucket)
		{
			GUI.RepeatButton(new Rect (Input.mousePosition.x, Screen.height - Input.mousePosition.y, buttonSize.x, buttonSize.y),
			                 "",
			                 bucket);
		}

		if (showScythe)
		{
			GUI.RepeatButton(new Rect (Input.mousePosition.x, Screen.height - Input.mousePosition.y, buttonSize.x, buttonSize.y),
			                 "",
			                 scythe);
		}

		if (!isEnabled)
		{
			return;
		} else
		{
			showButton1(mouseClickLocation.x, Screen.height - mouseClickLocation.y);
			showButton2(mouseClickLocation.x, Screen.height - mouseClickLocation.y);
			showButton3(mouseClickLocation.x, Screen.height - mouseClickLocation.y);
		}
	}

	private void showButton1(float mouseX, float mouseY)
	{
		if (GUI.Button (new Rect (mouseX - buttonSize.x - .02f * Screen.width, mouseY, buttonSize.x, buttonSize.y), "", singButton))
		{

		}
	}

	private void showButton2(float mouseX, float mouseY)
	{
		if (GUI.Button (new Rect (mouseX, mouseY, buttonSize.x, buttonSize.y), "", mucousButton))
		{
			isEnabled = false;
			menuSemaphore = 10;
			showScythe = false;
			showBucket = true;
		}
	}

	private void showButton3(float mouseX, float mouseY)
	{
		if (GUI.Button (new Rect (mouseX + buttonSize.x + .02f * Screen.width, mouseY, buttonSize.x, buttonSize.y), "", dieButton))
		{
			isEnabled = false;
			menuSemaphore = 10;
			showBucket = false;
			showScythe = true;
		}
	}
}
