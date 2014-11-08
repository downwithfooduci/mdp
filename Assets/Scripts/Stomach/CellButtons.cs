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

	private Vector2 buttonSize;
	private Vector2 button1SpawnLocation;
	private Vector2 button2SpawnLocation;
	private Vector2 button3SpawnLocation;

	// Update is called once per frame
	void Update () 
	{
		wasMouseClicked = Input.GetMouseButton (0);
		//TODO: also get click location

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
		Vector3 mousePos = MDPUtility.MouseToWorldPosition();	// get the mouse click position
		mousePos.y = 5;											// change the y position to 5 for proper hit detection
		RaycastHit hitInfo;										// storing raycast hits
		
		// check if we click on a tower by doing a raycast down to see if a tower was below it
		if (Physics.Raycast(mousePos, Vector3.down, out hitInfo, mousePos.y)) 
		{
			// if we click on tower, toggle whether menu is showed
			if (hitInfo.transform.position == transform.position)
			{
				isEnabled = !isEnabled;						// change the value in this class
			}
			else 		// if we didn't click directly on a tower disable a menu if it's up
			{
				if (isEnabled)
				{
					isEnabled = false;						// change the value in this class
				}
			}
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
		if (!isEnabled)
		{
			return;
		} else
		{
		}
	}
}
