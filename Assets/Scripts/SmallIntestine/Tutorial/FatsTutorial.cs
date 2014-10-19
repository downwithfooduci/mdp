using UnityEngine;
using System.Collections;

/**
 * Tutorial stuff for fats
 */
public class FatsTutorial : MonoBehaviour 
{
	// for zyme
	public GameObject zyme;
	private ZymePopupScript zymeScript;

	public Texture zymePopupImageFats1;
	public Texture zymePopupImageFats2;

	private bool showTutorialPart1;
	private bool part1Done;
	private bool showTutorialPart2;
	private bool part2Done;

	public float maxTimeSinceStart;
	private float elapsedTimeSinceStart;

	private IntestineGameManager gameManager;

	// Use this for initialization
	void Start () 
	{
		zymeScript = ((GameObject)Instantiate(zyme)).GetComponent<ZymePopupScript> ();
		// get a reference to the intestine game manager currently being used
		gameManager = GameObject.Find ("Managers").GetComponent<IntestineGameManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		elapsedTimeSinceStart += Time.deltaTime;
		
		if (!part1Done && PlayerPrefs.GetInt ("SIFatsTutorial") == 1 && elapsedTimeSinceStart > maxTimeSinceStart)
		{
			showTutorialPart1 = true;
		}

		if (PlayerPrefs.GetInt ("SIFatsTutorial") == 1 && !part2Done)
		{
			if (showTutorialPart1)
			{
				if (gameManager.nutrients < 20)
				{
					gameManager.nutrients += 20;
				}
				checkForTowerOfColor(Color.green);
			} else
			{
				if (gameManager.nutrients < 20)
				{
					gameManager.nutrients += 20;
				}
				checkForTowerOfColor(Color.white);
			}
		}
	}

	private bool checkForTowerOfColor(Color color)
	{
		GameObject[] towers;

		towers = GameObject.FindGameObjectsWithTag ("tower");
		for (int i = 0; i < towers.Length; i++)
		{
			if (towers[i].GetComponent<Tower>().enabled == true && 
			    towers[i].GetComponent<Tower>().getColor() == color)
			{
				if (color == Color.green)
				{
					zymeScript.setDraw(false);
					Time.timeScale = 1;
					showTutorialPart1 = false;
					showTutorialPart2 = true;
					part1Done = true;
					return true;
				} else if (color == Color.white)
				{
					zymeScript.setDraw(false);
					Time.timeScale = 1;
					PlayerPrefs.SetInt ("SIFatsTutorial", 0);
					PlayerPrefs.Save();
					showTutorialPart2 = false;
					part2Done = true;
					return true;
				}
			}
		}

		return false;
	}

	void OnGUI()
	{
		if (showTutorialPart1)
		{
			zymeScript.setDraw(true);
			zymeScript.setImage(zymePopupImageFats1);
			Time.timeScale = .01f;
		}

		if (showTutorialPart2 && part1Done)
		{
			zymeScript.setDraw(true);
			zymeScript.setImage(zymePopupImageFats2);
			Time.timeScale = .01f;
		}
	}
}
