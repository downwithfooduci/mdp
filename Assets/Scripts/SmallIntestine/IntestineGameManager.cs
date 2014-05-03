using UnityEngine;
using System.Collections;

public class IntestineGameManager : MonoBehaviour 
{
	public int MAX_HEALTH = 20;
	private bool showWinScreen;
	private SpawnManager spawnScript;

	public Texture gameWinPopup;
	public GUIStyle mainMenu;
	public GUIStyle quit;

    public GameObject GameOverScript;
    public GUIStyle FontStyle;

	public Texture[] faces;
	public Texture healthBar;
	private Rect faceRect;
	private Rect healthRect;
	
	public int health;
    public int nutrients;

    // Points gained for hitting a nutrient
    public int NutrientHitScore;
	
	public Color NutrientTextColor;
	private Color m_OriginalTextColor;
	
	private Color m_HealthTextColor;

    private bool m_IsGameOver;
	
	void Start()
	{
		showWinScreen = false;
		spawnScript = gameObject.GetComponent<SpawnManager> ();

		m_OriginalTextColor = m_HealthTextColor = NutrientTextColor = FontStyle.normal.textColor;

		faceRect = new Rect (Screen.width * 0.83203125f, Screen.height * 0.8489583f, Screen.width * 0.078125f, Screen.height * 0.102864583f);
		healthRect = new Rect (Screen.width * 0.935546875f, Screen.height * 0.85417f, Screen.width * 0.029296875f, Screen.height * 0.092447917f);
	}

    void Update()
    {
        if (m_IsGameOver)
            return;

        if (health <= 0)
        {
            Instantiate(GameOverScript);
            m_IsGameOver = true;
        }
		
		if (!NutrientTextColor.Equals(m_OriginalTextColor))
		{
			NutrientTextColor = Color.Lerp(NutrientTextColor, m_OriginalTextColor, Time.deltaTime);
		}
		
		if (!m_HealthTextColor.Equals(m_OriginalTextColor))
		{
			m_HealthTextColor = Color.Lerp(m_HealthTextColor, m_OriginalTextColor, Time.deltaTime);
		}
		if(GameObject.FindWithTag("foodBlobParent") == null && spawnScript.end && !showWinScreen)
		{
			GameObject chooseBackground = GameObject.Find("ChooseBackground");
			SmallIntestineLoadLevelCounter  level = chooseBackground.GetComponent<SmallIntestineLoadLevelCounter>();
			if(level.level == 2)
			{
				Time.timeScale = 0;
				showWinScreen = true;
			}
			else
			{
				level.level++;
				Application.LoadLevel("LoadLevelSmallIntestine");
			}
		}
    }

    public void OnNutrientHit()
    {
        nutrients += NutrientHitScore;
		NutrientTextColor = Color.green;
	}



    public void OnFoodBlobFinish(bool isAlive)
    {
		if (isAlive) 
		{
			health--;
			m_HealthTextColor = Color.red;
		} 
	}

    void OnGUI()
    {
		GUI.depth--;
		if(showWinScreen)
		{
			GUI.DrawTexture(new Rect(Screen.width * 0.3193359375f, 
			                         Screen.height * 0.28515625f, 
			                         Screen.width * 0.3603515625f, 
			                         Screen.height * 0.248697917f), gameWinPopup);
			
			// draw yes button
			if (GUI.Button(new Rect(Screen.width * 0.41015625f, 
			                        Screen.height * 0.41927083f,
			                        Screen.width * 0.0654296875f,
			                        Screen.height * 0.06640625f), "", mainMenu))
			{
				Time.timeScale = 1;
				GameObject chooseBackground = GameObject.Find("ChooseBackground");
				SmallIntestineLoadLevelCounter  level = chooseBackground.GetComponent<SmallIntestineLoadLevelCounter>();
				level.level = 0;
				Application.LoadLevel("MainMenu");
			}
			
			// draw no button
			if (GUI.Button(new Rect(Screen.width * 0.53125f, 
			                        Screen.height * 0.41927083f,
			                        Screen.width * 0.0654296875f,
			                        Screen.height * 0.06640625f), "", quit))
			{
				Time.timeScale = 1;
				Application.Quit();
			}
		}

		// draw nutrients text
		FontStyle.normal.textColor = NutrientTextColor;
		FontStyle.fontSize = 16;
		GUI.Label(new Rect((Screen.width / 2) - 50, 0, 40, 40), "Nutrients: " + nutrients, FontStyle);			
		FontStyle.normal.textColor = m_OriginalTextColor;

		// choose face to draw
		if (health > .8 * MAX_HEALTH)
		{
			GUI.DrawTexture (faceRect, faces [0]);
		} else if (health > .6 * MAX_HEALTH)
		{
			GUI.DrawTexture (faceRect, faces [1]);
		} else if (health > .4 * MAX_HEALTH)
		{
			GUI.DrawTexture (faceRect, faces [2]);
		} else if (health > .2 * MAX_HEALTH)
		{
			GUI.DrawTexture (faceRect, faces [3]);
		} else 
		{
			GUI.DrawTexture (faceRect, faces [4]);
		}

		// change drawing of health bar
		GUI.DrawTexture (new Rect(healthRect.xMin, healthRect.yMin + (1-(float)health/(float)MAX_HEALTH)*healthRect.height, 
		                          healthRect.width, ((float)health/(float)MAX_HEALTH)*healthRect.height), healthBar);

    }
}
