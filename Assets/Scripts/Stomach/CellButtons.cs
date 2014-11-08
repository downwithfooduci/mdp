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
	
	public Texture bucket;
	public Texture scythe;

	private bool wasMouseClicked;
	private bool mouseDownLastFrame;
	private bool isEnabled;
	private Vector2 mouseClickLocation;

	private Vector2 buttonSize;
	private Vector2 button1SpawnLocation;
	private Vector2 button2SpawnLocation;
	private Vector2 button3SpawnLocation;

	void Start()
	{
		buttonSize.x = Screen.width * (311f / 1024f);
		buttonSize.y = Screen.height * (423f / 768f);
	}

	// Update is called once per frame
	void Update () 
	{
		wasMouseClicked = Input.GetMouseButton (0);
		if (wasMouseClicked && !isEnabled) 
		{
			mouseClickLocation.x = Input.mousePosition.x;
			mouseClickLocation.y = Input.mousePosition.y;
		}

		// check if the mouse was down last frame, but is not currently pressed
		if (mouseDownLastFrame && !wasMouseClicked)
		{
			StartCoroutine(CheckMouseClick());		// need to use startcoroutine because the function is of type 
													// ienumerator so we can delay the thread
													// without this delay the menu DOES NOT function properly due 
													// to the execution order of functions
		}

		mouseDownLastFrame = wasMouseClicked;
	}

	/**
	 * asynchronous function that checks mouse clicks to see if it brings up the tower menu or closes a tower menu
	 */
	private IEnumerator CheckMouseClick()
	{	
		Debug.Log (mouseClickLocation.x + "," + mouseClickLocation.y);

		if (mouseClickLocation.x > (290f/800f)*Screen.width && mouseClickLocation.x < .7*Screen.width) 
		{
			isEnabled = true;
		} else
		{
			// otherwise if we clicked in a random place cancel the menu
			yield return new WaitForSeconds(.1f);		// wait for .1 seconds
			if (isEnabled)
			{
				isEnabled = false;						//change the value in this class
			}
		}
		yield return new WaitForSeconds(.0f);
	}

	void OnGUI()
	{
		GUI.depth = GUI.depth - 20;

		if (!isEnabled)
		{
			return;
		} else
		{
			showButton1(mouseClickLocation.x, mouseClickLocation.y);
			showButton2(mouseClickLocation.x, mouseClickLocation.y);
			showButton3(mouseClickLocation.x, mouseClickLocation.y);
		}
	}

	private void showButton1(float mouseX, float mouseY)
	{

	}

	private void showButton2(float mouseX, float mouseY)
	{
		GUI.Button (new Rect (mouseX, mouseY, buttonSize.x, buttonSize.y), "", mucousButton);
	}

	private void showButton3(float mouseX, float mouseY)
	{
	}
}
