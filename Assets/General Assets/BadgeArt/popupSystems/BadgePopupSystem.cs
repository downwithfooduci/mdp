using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgePopupSystem : MonoBehaviour {

	public bool isPopup;
	public Texture BadgePopupWindow;
	public Texture[] filledStar;
	public string badgeTriger;
	public string PassText;

	public GUIStyle restart;			//!< to hold the textures for the restart button
	public GUIStyle mainMenu;			//!< to hold the textures for the mainMenu button
	public GUIStyle continueGame;





	private GUIStyle statsStyle;
	public GUIStyle statsStyle2;
	public int trigerNum;
	private string[] badgeText;
	private string scence;
	private string loadLevel;
	private string[] sentence;

    private SmallIntestineLoadLevelCounter SIlevel;



    // Use this for initialization
    void Start () {
		isPopup = false;
		//Time.timeScale = 0;		// pause the game

		statsStyle = new GUIStyle ();									// create a new style
		statsStyle.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");		// set the font
		statsStyle.normal.textColor = Color.white;								// set the font color
		statsStyle.fontSize = (int)(16f / 768f * Screen.height);				// set the font relative size

		statsStyle2 = new GUIStyle ();									// create a new style
		statsStyle2.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");		// set the font
		statsStyle2.normal.textColor = Color.white;								// set the font color
		statsStyle2.fontSize = (int)(18f / 768f * Screen.height);				// set the font relative size
        statsStyle2.richText = true;

        trigerNum = PlayerPrefs.GetInt(badgeTriger);
		scence = Application.loadedLevelName;

		badgeText = new string[3];
		sentence = new string[3];

		if (scence == "Stomach") {
			badgeText [0] = "  Cells\n" +
							"> 3 died\n" ;
			badgeText [1] = "  Cells\n" +
							"< 3 died\n" ;
			badgeText [2] = "No cells died!" ;

			//loadLevel = "StomachStats";
			//loadLevel = "BadgeFridge";
			loadLevel = "StomachEndStoryboard";
			PlayerPrefs.SetString("lastLoadedGame", "Stomach");


			sentence[0] =   "You helped the chef digest her food and earned \n" +
				            "a <color=#E0A402>BRONZE</color> badge! Protect her stomach wall from acid \n" +
				            "so that it gets fewer holes to earn the silver badge.";
			sentence[1] =   "You helped the chef digest her food and earned \n" +
				            "a <color=#CCCCCC>SILVER</color> badge! Protect her stomach wall from \n" +
				            "acid so that it gets fewer holes to earn the gold";
			sentence[2] =   "You helped the chef digest her food and earned \n" +
				            "a <color=#FEE853>GOLD</color> badge! Great job protecting her stomach \n" +
				            "wall from acid so that it had no holes!";

		}
		else if (scence == "SmallIntestineOdd" || scence == "SmallIntestineEven"){
            statsStyle2.fontSize = (int)(17f / 768f * Screen.height);

            badgeText [0] = " A lot of food\n" + 
							" lost!";
			badgeText [1] = " Some food\n" + 
							" lost!";
			badgeText [2] = " No food\n" + 
							" lost!";
			//loadLevel = "SmallIntestineStats";
			//loadLevel = "BadgeFridge";
			loadLevel = "SmallIntestineEndStoryboard";
			PlayerPrefs.SetString("lastLoadedGame", "SI");

            GameObject counter = GameObject.Find("ChooseBackground");
            SIlevel = counter.GetComponent<SmallIntestineLoadLevelCounter>();

            sentence[0] =   "You helped the chef absorb nutrients from her food in \n" +
                            "the small intestine and earned a <color=#E0A402>BRONZE</color> badge! Get more \n" +
            	            "nutrients before they escape to earn the silver badge.";
			sentence[1] =   "You helped the chef absorb nutrients from her food in \n" +
                            "the small intestine and earned a <color=#CCCCCC>SILVER</color> badge! Get more \n" +
				            "nutrients before they escape to earn the silver badge.";
			sentence[2] =   "You helped the chef absorb nutrients from her food in \n" +
                            "the small intestine and earned a <color=#FEE853>GOLD</color> badge! Great job \n" +
				            "getting all those nutrients!\n";

		}
		else if (scence == "LargeIntestine"){
			badgeText [0] = "   Bacterias\n" + 
							">3 touched";
			badgeText [1] = "   Bacterias\n" + 
							"<3 touched";
			badgeText [2] = "No bacteria touched";
			//loadLevel = "LargeIntestineEndStoryboard";
			//loadLevel = "BadgeFridge";
			loadLevel = "LargeIntestineEndStoryboard";
			PlayerPrefs.SetString("lastLoadedGame", "LI");


			sentence[0] =   "You helped the chef absorb water from her food \n" +
                            "to make good poop and earned a <color=#E0A402>BRONZE</color> badge! \n" +
				            "Avoid the bacteria to earn the silver badge.";
			sentence[1] =   "You helped the chef absorb water from her food \n" +
                            "to make good poop and earned a <color=#CCCCCC>SILVER</color> badge! \n" +
				            "Avoid the bacteria to earn the gold badge.";
			sentence[2] =   "You helped the chef absorb water from her food \n" +
                            "to make good poop and earned a <color=#FEE853>GOLD</color> badge! Great \n" +
				            "job avoiding all those bacteria!";

		}


	}

	// Update is called once per frame
	void Update () {


		trigerNum = PlayerPrefs.GetInt(badgeTriger);
		//Debug.Log (badgeTriger + ": " + trigerNum);

	}


	void OnGUI()
	{


		float scale = 70f/138f;
		float buttonWidth = Screen.width * 0.134765625f;


		if (isPopup)		// determine if we should draw the game over popup box
		{
			// this draws the popup box in the middle of the screen
			Time.timeScale = 0;


			GUI.DrawTexture(new Rect(Screen.width * 0.26953125f, 
				Screen.height * 0.18359375f, 
				Screen.width * 0.4609375f, 
				Screen.height * 0.6328125f), BadgePopupWindow);



			GUI.DrawTexture(new Rect((546f/1024f)*Screen.width, (233f/768f)*Screen.height, (31f/1024f)*Screen.width,
				(31f/768f)*Screen.height), filledStar[0]);
			if (trigerNum < 3) {
				GUI.DrawTexture (new Rect ((546f / 1024f) * Screen.width, (312f / 768f) * Screen.height, (31f / 1024f) * Screen.width,
					(31f / 768f) * Screen.height), filledStar [1]);
			}
			if (trigerNum == 0) {
				GUI.DrawTexture (new Rect ((546f / 1024f) * Screen.width, (391f / 768f) * Screen.height, (31f / 1024f) * Screen.width,
					(31f / 768f) * Screen.height), filledStar [2]);
			}
			
			
			GUI.Label(new Rect((592f/1024f)*Screen.width, (230f/768f)*Screen.height, ((80f)/1024f)*Screen.width,
				((41f)/768f)*Screen.height), 
				badgeText [0],
				statsStyle);
			GUI.Label (new Rect ((592f / 1024f) * Screen.width, (309f / 768f) * Screen.height, ((80f) / 1024f) * Screen.width,
				((41f) / 768f) * Screen.height), 
				badgeText [1],
				statsStyle);
			GUI.Label (new Rect ((592f / 1024f) * Screen.width, (391f / 768f) * Screen.height, ((80f) / 1024f) * Screen.width,
				((103f) / 768f) * Screen.height), 
				badgeText [2],
				statsStyle);
			





			if (trigerNum == 0) {
				GUI.Label(new Rect(((276f + 20f)/1024f)*Screen.width, ((141f + 300f)/768f)*Screen.height, ((340f)/1024f)*Screen.width,
					((29f)/768f)*Screen.height), 
					sentence[2], 										//"You helped the chef swalllow!" ,
					statsStyle2);
			} else if (trigerNum < 3) {
				GUI.Label(new Rect(((276f + 20f)/1024f)*Screen.width, ((141f + 300f) /768f)*Screen.height, ((340f)/1024f)*Screen.width,
					((29f)/768f)*Screen.height), 
					sentence[1], 										//"You helped the chef swalllow!" ,
					statsStyle2);
			} else if (trigerNum >= 3) {
				GUI.Label(new Rect(((276f + 20f)/1024f)*Screen.width, ((141f + 300f) /768f)*Screen.height, ((340f)/1024f)*Screen.width,
					((29f)/768f)*Screen.height), 
					sentence[0], 										//"You helped the chef swalllow!" ,
					statsStyle2);
			}





			// draw restart button in proper condition
			if (GUI.Button (new Rect (Screen.width * 0.2822265625f, 
				Screen.height * 0.67578125f,
				buttonWidth,
				buttonWidth * scale), "", restart))
			{
				// if the restart button is pressed
				Time.timeScale = 1;                 // unpause the game
                                                    // restart from the correct level

                Application.LoadLevel(scence);		// reload the mouth game from the current level
			}

			// draw the main menu button
			if (GUI.Button (new Rect (Screen.width * 0.4345703125f, 
				Screen.height * 0.67578125f,
				buttonWidth,
				buttonWidth * scale), "", mainMenu))
			{
				// if the main menu button is pressed
				Time.timeScale = 1;					// unpause the game
				Application.LoadLevel("LevelSelection");	// load up the main menu
			}

            if (GUI.Button(new Rect(Screen.width * 0.5830078125f,
                Screen.height * 0.67578125f,
                buttonWidth,
                buttonWidth * scale), "", continueGame))
            {
                // if the go next button is pressed
                Time.timeScale = 1;                 // unpause the game
                if (scence == "SmallIntestineOdd" || scence == "SmallIntestineEven") {
                    Debug.Log("[Test] Current Level:" + SIlevel.getLevel());
                    SIlevel.nextLevel();
                    Debug.Log("[Test] Next Level:" + SIlevel.getLevel());

                    if (SIlevel.getLevel() > SIlevel.getMaxLevels())            // check if we've played all the levels
                    {
                        //Application.LoadLevel("LargeIntestineStoryBoard");                    // if we have load the end screen
                        loadLevel = "SmallIntestineEndStoryboard";
                    }
                    else
                    {
                        if (SIlevel.isTutorial())
                        {
                            loadLevel = "SmallIntestineTutorial";
                        }
                        else
                        {
                            loadLevel = "LoadLevelSmallIntestine";   // otherwise load the next level
                        }
                    }
                }
                Application.LoadLevel(loadLevel);   // load up the main menu

            }
		}
	}

	public void end(){
		isPopup = true;
	}
}

