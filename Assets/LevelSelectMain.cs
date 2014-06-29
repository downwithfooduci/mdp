using UnityEngine;
using System.Collections;

public class LevelSelectMain : MonoBehaviour 
{
	private bool showSI, showMouth;

	// for drawing stars
	public Texture filledStar;
	public Texture emptyStar;

	// for high scores
	private int mouthLevel1HS;
	private int mouthLevel2HS;
	private int smallIntestineLevel1HS;
	private int smallIntestineLevel2HS;
	private int smallIntestineLevel3HS;
	private int smallIntestineLevel4HS;
	private int smallIntestineLevel5HS;
	private int smallIntestineLevel6HS;

	// for unlocked games
	private bool mouthUnlocked;
	private bool smallIntestineUnlocked;

	// for selecting a specific SI level
	public GameObject desiredSILevel;
	private GameObject desiredSILevelObj;
	private DesiredSILevel levelSI;

	// for selecting a specific mouth level	
	public GameObject desiredMouthLevel;
	private GameObject desiredMouthLevelObj;
	private DesiredMouthLevel levelMouth;

	// Use this for initialization
	void Start () 
	{
		getUnlockedGames ();
		populateHighScores ();
	}

	// get the unlocked games
	void getUnlockedGames()
	{
		mouthUnlocked = (PlayerPrefs.GetInt ("PlayedMouthStory") == 1) ? true : false;
		smallIntestineUnlocked = (PlayerPrefs.GetInt ("PlayedSIStory") == 1) ? true : false;
	}

	// get all the high scores
	void populateHighScores()
	{
		mouthLevel1HS = PlayerPrefs.GetInt("Mouth1");
		mouthLevel2HS = PlayerPrefs.GetInt("Mouth2");
		smallIntestineLevel1HS = PlayerPrefs.GetInt("SI1");
		smallIntestineLevel2HS = PlayerPrefs.GetInt("SI2");
		smallIntestineLevel3HS = PlayerPrefs.GetInt("SI3");
		smallIntestineLevel4HS = PlayerPrefs.GetInt("SI4");
		smallIntestineLevel5HS = PlayerPrefs.GetInt("SI5");
		smallIntestineLevel6HS = PlayerPrefs.GetInt("SI6");
	}

	void drawStars(float y, int highScore)
	{
		// draw the actual stars
		if (highScore == 0)
		{
			GUI.DrawTexture(new Rect(((450f + 0*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), emptyStar);
			GUI.DrawTexture(new Rect(((450f + 1*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), emptyStar);
			GUI.DrawTexture(new Rect(((450f + 2*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), emptyStar);
			GUI.DrawTexture(new Rect(((450f + 3*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), emptyStar);
			GUI.DrawTexture(new Rect(((450f + 4*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), emptyStar);
		} else if (highScore == 1)
		{
			GUI.DrawTexture(new Rect(((450f + 0*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect(((450f + 1*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), emptyStar);
			GUI.DrawTexture(new Rect(((450f + 2*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), emptyStar);
			GUI.DrawTexture(new Rect(((450f + 3*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), emptyStar);
			GUI.DrawTexture(new Rect(((450f + 4*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), emptyStar);
		} else if (highScore == 2)
		{
			GUI.DrawTexture(new Rect(((450f + 0*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect(((450f + 1*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect(((450f + 2*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), emptyStar);
			GUI.DrawTexture(new Rect(((450f + 3*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), emptyStar);
			GUI.DrawTexture(new Rect(((450f + 4*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), emptyStar);
		} else if (highScore == 3)
		{
			GUI.DrawTexture(new Rect(((450f + 0*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect(((450f + 1*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect(((450f + 2*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect(((450f + 3*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), emptyStar);
			GUI.DrawTexture(new Rect(((450f + 4*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), emptyStar);
		} else if (highScore == 4)
		{
			GUI.DrawTexture(new Rect(((450f + 0*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect(((450f + 1*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect(((450f + 2*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect(((450f + 3*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect(((450f + 4*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), emptyStar);
		} else if (highScore == 5)
		{
			GUI.DrawTexture(new Rect(((450f + 0*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect(((450f + 1*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect(((450f + 2*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect(((450f + 3*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect(((450f + 4*82f)/1024f)*Screen.width, y, (64f/1024f)*Screen.width,
			                         (64f/768f)*Screen.height), filledStar);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnGUI()
	{
		// text style for regular text
		GUIStyle textStyle = new GUIStyle ();
		textStyle.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		textStyle.normal.textColor = Color.yellow;
		textStyle.fontSize = (int)(30f / 597f * Screen.height);
		textStyle.alignment = TextAnchor.MiddleCenter;

		// text style for active buttons
		GUIStyle activeStyle = new GUIStyle (GUI.skin.button);
		activeStyle.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		activeStyle.normal.textColor = Color.yellow;
		activeStyle.fontSize = (int)(22f / 597f * Screen.height);
		activeStyle.alignment = TextAnchor.MiddleLeft;

		// text style for inactive buttons
		GUIStyle inactiveStyle = new GUIStyle (GUI.skin.button);
		inactiveStyle.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		inactiveStyle.normal.textColor = Color.gray;
		inactiveStyle.fontSize = (int)(22f / 597f * Screen.height);
		inactiveStyle.alignment = TextAnchor.MiddleLeft;

		// display the main menu only
		if (!showMouth && !showSI)
		{
			GUI.Label(new Rect(0, 0, Screen.width,
			                   (100f/768f)*Screen.height), 
			          "Select a Game", textStyle);

			// show active or inactive mouth level selection
			if (mouthUnlocked)
			{
				if (GUI.Button(new Rect(Screen.width * .2f, Screen.height*.2f, 
				                        Screen.width * 0.35f, Screen.height * 0.1f), "Mouth Game", activeStyle))
				{
					showMouth = true;
				}
			} else
			{
				if (GUI.Button(new Rect(Screen.width * .2f, Screen.height*.2f, 
				                        Screen.width * 0.35f, Screen.height * 0.1f), "Mouth Game", inactiveStyle))
				{
				}
			}

			// show active or inactive SI level selection
			if(smallIntestineUnlocked)
			{
				if (GUI.Button(new Rect(Screen.width * .2f, Screen.height*.3f, 
				                        Screen.width * 0.35f, Screen.height * 0.1f), "Small Intestine Game", activeStyle))
				{
					showSI = true;
				}
			} else
			{
				if (GUI.Button(new Rect(Screen.width * .2f, Screen.height*.3f, 
				                        Screen.width * 0.35f, Screen.height * 0.1f), "Small Intestine Game", inactiveStyle))
				{
				}
			}
		}

		// allow selection between mouth game levels
		if (showMouth)
		{
			GUI.Label(new Rect(0, 0, Screen.width,
			                   (100f/768f)*Screen.height), "Select a Level to Play", textStyle);

			// draw stars by buttons
			drawStars (Screen.height*.2f, mouthLevel1HS);
			drawStars (Screen.height*.3f, mouthLevel2HS);

			// if the game is unlocked the first level will be available so we don't need to check here
			if (GUI.Button(new Rect(Screen.width * .2f, Screen.height*.2f, 
			                        Screen.width * 0.2f, Screen.height * 0.1f), "Level 1", activeStyle))
			{
				desiredMouthLevelObj = (GameObject)Instantiate (desiredMouthLevel);
				levelMouth = desiredMouthLevelObj.GetComponent<DesiredMouthLevel>();
				levelMouth.setDesiredLevel(1);
				Application.LoadLevel("LoadLevelMouth");
			}

			// check if next level is unlocked by checking if previous was beaten
			if (mouthLevel1HS > 0)
			{
				if (GUI.Button(new Rect(Screen.width * .2f, Screen.height*.3f, 
				                        Screen.width * 0.2f, Screen.height * 0.1f), "Level 2", activeStyle))
				{
					desiredMouthLevelObj = (GameObject)Instantiate (desiredMouthLevel);
					levelMouth = desiredMouthLevelObj.GetComponent<DesiredMouthLevel>();
					levelMouth.setDesiredLevel(2);
					Application.LoadLevel("LoadLevelMouth");
				}
			} else
			{
				if (GUI.Button(new Rect(Screen.width * .2f, Screen.height*.3f, 
				                        Screen.width * 0.2f, Screen.height * 0.1f), "Level 2", inactiveStyle))
				{

				}
			}
		} else if (showSI)
		{
			GUI.Label(new Rect(0, 0, Screen.width,
			                   (100f/768f)*Screen.height), "Select a Level to Play", textStyle);

			// draw the stars by each level
			drawStars (Screen.height*.2f, smallIntestineLevel1HS);
			drawStars (Screen.height*.3f, smallIntestineLevel2HS);
			drawStars (Screen.height*.4f, smallIntestineLevel3HS);
			drawStars (Screen.height*.5f, smallIntestineLevel4HS);
			drawStars (Screen.height*.6f, smallIntestineLevel5HS);
			drawStars (Screen.height*.7f, smallIntestineLevel6HS);

			// if the game is unlocked the first level will be available so we don't need to check here
			if (GUI.Button(new Rect(Screen.width * .2f, Screen.height*.2f, 
			                        Screen.width * 0.2f, Screen.height * 0.1f), "Level 1", activeStyle))
			{
				desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
				levelSI = desiredSILevelObj.GetComponent<DesiredSILevel>();
				levelSI.setDesiredLevel(1);
				Application.LoadLevel("LoadLevelSmallIntestine");
			}

			// check if next level is unlocked by checking if previous was beaten
			if (smallIntestineLevel1HS > 0)
			{
				if (GUI.Button(new Rect(Screen.width * .2f, Screen.height*.3f, 
				                        Screen.width * 0.2f, Screen.height * 0.1f), "Level 2", activeStyle))
				{
					desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
					levelSI = desiredSILevelObj.GetComponent<DesiredSILevel>();
					levelSI.setDesiredLevel(2);
					Application.LoadLevel("LoadLevelSmallIntestine");
				}
			} else
			{
				if (GUI.Button(new Rect(Screen.width * .2f, Screen.height*.3f, 
				                        Screen.width * 0.2f, Screen.height * 0.1f), "Level 2", inactiveStyle))
				{
					
				}
			}

			if (smallIntestineLevel2HS > 0)
			{
				if (GUI.Button(new Rect(Screen.width * .2f, Screen.height*.4f, 
				                        Screen.width * 0.2f, Screen.height * 0.1f), "Level 3", activeStyle))
				{
					desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
					levelSI = desiredSILevelObj.GetComponent<DesiredSILevel>();
					levelSI.setDesiredLevel(3);
					Application.LoadLevel("LoadLevelSmallIntestine");
				}
			} else
			{
				if (GUI.Button(new Rect(Screen.width * .2f, Screen.height*.4f, 
				                        Screen.width * 0.2f, Screen.height * 0.1f), "Level 3", inactiveStyle))
				{
					
				}
			}

			if (smallIntestineLevel3HS > 0)
			{
				if (GUI.Button(new Rect(Screen.width * .2f, Screen.height*.5f, 
				                        Screen.width * 0.2f, Screen.height * 0.1f), "Level 4", activeStyle))
				{
					desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
					levelSI = desiredSILevelObj.GetComponent<DesiredSILevel>();
					levelSI.setDesiredLevel(4);
					Application.LoadLevel("LoadLevelSmallIntestine");
				}
			} else
			{
				if (GUI.Button(new Rect(Screen.width * .2f, Screen.height*.5f, 
				                        Screen.width * 0.2f, Screen.height * 0.1f), "Level 4", inactiveStyle))
				{
					
				}
			}

			if (smallIntestineLevel4HS > 0)
			{
				if (GUI.Button(new Rect(Screen.width * .2f, Screen.height*.6f, 
				                        Screen.width * 0.2f, Screen.height * 0.1f), "Level 5", activeStyle))
				{
					desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
					levelSI = desiredSILevelObj.GetComponent<DesiredSILevel>();
					levelSI.setDesiredLevel(5);
					Application.LoadLevel("LoadLevelSmallIntestine");
				}
			} else
			{
				if (GUI.Button(new Rect(Screen.width * .2f, Screen.height*.6f, 
				                        Screen.width * 0.2f, Screen.height * 0.1f), "Level 5", inactiveStyle))
				{
					
				}
			}

			if (smallIntestineLevel5HS > 0)
			{
				if (GUI.Button(new Rect(Screen.width * .2f, Screen.height*.7f, 
				                        Screen.width * 0.2f, Screen.height * 0.1f), "Level 6", activeStyle))
				{
					desiredSILevelObj = (GameObject)Instantiate (desiredSILevel);
					levelSI = desiredSILevelObj.GetComponent<DesiredSILevel>();
					levelSI.setDesiredLevel(6);
					Application.LoadLevel("LoadLevelSmallIntestine");
				}
			} else
			{
				if (GUI.Button(new Rect(Screen.width * .2f, Screen.height*.7f, 
				                        Screen.width * 0.2f, Screen.height * 0.1f), "Level 6", inactiveStyle))
				{
					
				}
			}
		}
	}
}
