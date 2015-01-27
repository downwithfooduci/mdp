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

	private CellManager cellManager;

	// record click data
	private int slimeClicks;
	private int singClicks;
	private int dieClicks;

	void Start()
	{
		cellManager = FindObjectOfType (typeof(CellManager)) as CellManager;

		buttonSize.x = Screen.width * (186f / 1024f);
		buttonSize.y = Screen.height * (253f / 768f);
	}

	// Update is called once per frame
	void Update () 
	{
		if (Time.timeScale == 0)
		{
			isEnabled = false;
			return;
		}

		wasMouseClicked = Input.GetMouseButton (0);

		// check if the mouse was down last frame, but is not currently pressed
		if (mouseDownLastFrame && !wasMouseClicked)
		{
			mouseClickLocation.x = Input.mousePosition.x;
			mouseClickLocation.y = Input.mousePosition.y;
		}

		mouseDownLastFrame = wasMouseClicked;

		if (menuSemaphore > 0)
		{
			menuSemaphore--;
		}
	}
	
	public void checkMouseClick(int cell)
	{	
		if (menuSemaphore <= 0 &&
		    !isEnabled &&
		    cell == 2) 
		{
			if (showBucket || showScythe)
			{
				showBucket = false;
				showScythe = false;
			} else
			{
				isEnabled = true;
			}
		} else if (menuSemaphore <= 0 &&
		           showBucket)
		{
			cellManager.cellScripts[cell - 1].setCellState("slimed");
			slimeClicks++;
		} else if (menuSemaphore <= 0 &&
		           showScythe)
		{
			cellManager.cellScripts[cell - 1].setCellState("dead");
			dieClicks++;
		} else
		{
			isEnabled = false;
			menuSemaphore = 10;
		}
	}

	/**
	 * Handles drawing of related gui components
	 */
	void OnGUI()
	{
		GUI.depth = GUI.depth - 20;	// for gui layering

		// if we clicked on the "make mucous" button, show the mucous bucket
		if (showBucket)
		{
			GUI.RepeatButton(new Rect (Input.mousePosition.x, Screen.height - Input.mousePosition.y, buttonSize.x, buttonSize.y),
			                 "",
			                 bucket);
		}

		// if we clicked on the "die" button, show the scythe
		if (showScythe)
		{
			GUI.RepeatButton(new Rect (Input.mousePosition.x, Screen.height - Input.mousePosition.y, buttonSize.x, buttonSize.y),
			                 "",
			                 scythe);
		}

		// check if we should draw the menu
		if (!isEnabled)	// we shouldn't
		{
			return;
		} else 			// we should
		{
			// get the 3 buttons
			showButton1(mouseClickLocation.x, Screen.height - mouseClickLocation.y);
			showButton2(mouseClickLocation.x, Screen.height - mouseClickLocation.y);
			showButton3(mouseClickLocation.x, Screen.height - mouseClickLocation.y);
		}
	}

	/**
	 * Function to find location of and create the "sing" button
	 */
	private void showButton1(float mouseX, float mouseY)
	{
		if (GUI.Button (new Rect (mouseX - buttonSize.x - .02f * Screen.width, mouseY, buttonSize.x, buttonSize.y), "", singButton))
		{

		}
	}

	/**
	 * Function to find location of and create the "mucous" button
	 */
	private void showButton2(float mouseX, float mouseY)
	{
		if (GUI.Button (new Rect (mouseX, mouseY, buttonSize.x, buttonSize.y), "", mucousButton))
		{
			// for proper menu behavior
			isEnabled = false;
			menuSemaphore = 10;
			// show the bucket icon
			showScythe = false;
			showBucket = true;

			//slime main cell
			if (cellManager.cellScripts[1].getCellState() != "dead")
			{
				cellManager.cellScripts[1].setCellState("slimed");
			}
		}
	}

	/**
	 * Function to find location of and create the "die" button
	 */
	private void showButton3(float mouseX, float mouseY)
	{
		if (GUI.Button (new Rect (mouseX + buttonSize.x + .02f * Screen.width, mouseY, buttonSize.x, buttonSize.y), "", dieButton))
		{
			// for proper menu behavior
			isEnabled = false;
			menuSemaphore = 10;
			// show the bucket icon
			showBucket = false;
			showScythe = true;

			//kill main cell
			cellManager.cellScripts[1].setCellState("dead");
		}
	}
}
