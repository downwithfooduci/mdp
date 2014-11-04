using UnityEngine;
using System.Collections;

public class MainCell : MonoBehaviour 
{
	public Texture[] cellFaces;
	private StomachCell cellController;

	private CellButtons cellMenu;

	// Use this for initialization
	void Start () 
	{
		cellMenu = new CellButtons ();
		cellMenu.initializeMenu ();
		cellController = gameObject.GetComponent<StomachCell> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
			GUI.depth = GUI.depth - 10;

			// draw face
			switch (cellController.getCellState ()) 
			{
			case ("normal"):
				{
					GUI.DrawTexture (new Rect (.43f * Screen.width, .15f * Screen.height, .2f * Screen.width, 
                          .2f * Screen.height), cellFaces [0]);
					break;
				}
			case ("blinking"):
				{
					GUI.DrawTexture (new Rect (.43f * Screen.width, .15f * Screen.height, .2f * Screen.width, 
                          .2f * Screen.height), cellFaces [1]);
					break;
				}
			case ("slimed"):
				{
					break;
				}
			case ("burning"):
				{
					GUI.DrawTexture (new Rect (.43f * Screen.width, .15f * Screen.height, .2f * Screen.width, 
                          .2f * Screen.height), cellFaces [2]);
					break;
				}
			case ("dead"):
				{
					GUI.DrawTexture (new Rect (.43f * Screen.width, .15f * Screen.height, .2f * Screen.width, 
                          .2f * Screen.height), cellFaces [3]);
					break;
				}
			case ("question"):
				{
					GUI.DrawTexture (new Rect (.43f * Screen.width, .15f * Screen.height, .2f * Screen.width, 
                          .2f * Screen.height), cellFaces [4]);
					break;
				}
			case ("sleeping"):
				{
					GUI.DrawTexture (new Rect (.43f * Screen.width, .15f * Screen.height, .2f * Screen.width, 
                          .2f * Screen.height), cellFaces [5]);
					break;
				}
			default:
				{
					break;
				}
			}
		}
}
