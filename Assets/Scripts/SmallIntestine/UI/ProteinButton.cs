using UnityEngine;
using System.Collections;

// Scripts for all buttons except protein are similar but have slight differences
public class ProteinButton : MonoBehaviour 
{
	public Texture activeTexture;
	public Texture pressedTexture;
	public Texture inactiveTexture;

	private float buttonTop;
	private float buttonLeft;
	private float buttonWidth;		// width of a button
	private float buttonHeight;
	private float buttonSpacing;
	
	private const int buttonColorCode = 2;	// this is from old legacy code to maintain the proper tower color
	
	private TowerSpawner towerSpawner;
	
	// Use this for initialization
	void Start () 
	{
		buttonWidth = Screen.width * 0.197f;
		buttonHeight = Screen.height * 0.091f;
		buttonTop =  (Screen.height * 0.11f) - buttonHeight;
		buttonSpacing = Screen.width * 0.0123f;
		buttonLeft = Screen.width * 0.0148f + 2*(buttonWidth + buttonSpacing);
		
		guiTexture.pixelInset = new Rect(buttonLeft, buttonTop, buttonWidth, buttonHeight);
		
		towerSpawner = GameObject.Find ("GUI").GetComponent<TowerSpawner> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (towerSpawner.getGameManager().nutrients - towerSpawner.TOWER_BASE_COST < 0 || 
		    Application.loadedLevelName == "SmallIntestineTutorial" && PlayerPrefs.GetInt("SIStats_towersPlaced") == 2 &&
		    PlayerPrefs.GetInt("SIStats_towersUpgraded") < 2)
		{
			guiTexture.texture = inactiveTexture;
			return;
		} else if (guiTexture.HitTest(Input.mousePosition) == true || 
		           Input.touches.Length > 0 && guiTexture.HitTest(Input.touches[0].position) == true)
		{	
			foreach (Touch touch in Input.touches) 
			{
				if (touch.phase == TouchPhase.Began) 
				{
					guiTexture.texture = pressedTexture;
					
					// code to spawn towers
					if (!towerSpawner.getIsSpawnActive())
					{
						towerSpawner.SpawnTower(towerSpawner.AvailableColors[buttonColorCode]);
						towerSpawner.getSpawnedTower().GetComponent<Tower> ().enabled = false;
						return;
					}
				}
				if (touch.phase == TouchPhase.Ended) 
				{
					guiTexture.texture = activeTexture;
				}
			}
			
			if(Input.GetMouseButtonDown(0))
			{
				guiTexture.texture = pressedTexture;
				
				// code to spawn towers
				if (!towerSpawner.getIsSpawnActive())
				{
					towerSpawner.SpawnTower(towerSpawner.AvailableColors[buttonColorCode]);
					towerSpawner.getSpawnedTower().GetComponent<Tower> ().enabled = false;
					return;
				}
			} else if (Input.GetMouseButtonUp(0)) 
			{
				guiTexture.texture = activeTexture;
			} else
			{
				guiTexture.texture = activeTexture;
			}
		} else
		{
			guiTexture.texture = activeTexture;
		}
	}
}
