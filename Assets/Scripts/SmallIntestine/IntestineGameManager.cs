using UnityEngine;
using System.Collections;

public class IntestineGameManager : MonoBehaviour 
{
	// for holding the tracker
	private GameObject statTracker;
	private TrackStatVariables trackStatVariables;

	public int MAX_HEALTH = 20;
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
		statTracker = GameObject.Find ("SIStatTracker(Clone)");
		trackStatVariables = statTracker.GetComponent<TrackStatVariables>();

		spawnScript = gameObject.GetComponent<SpawnManager> ();

		m_OriginalTextColor = m_HealthTextColor = NutrientTextColor = FontStyle.normal.textColor;

		faceRect = new Rect (Screen.width * .864f, Screen.height * 0.86f, Screen.width * 0.078125f, Screen.height * 0.102864583f);
		healthRect = new Rect (Screen.width * 0.952f, Screen.height * 0.8622f, Screen.width * 0.032f, Screen.height * 0.0948f);
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
		if(GameObject.FindWithTag("foodBlobParent") == null && spawnScript.end)
		{
			GameObject chooseBackground = GameObject.Find("ChooseBackground");
			SmallIntestineLoadLevelCounter  level = chooseBackground.GetComponent<SmallIntestineLoadLevelCounter>();

			if(level.getLevel() == level.getMaxLevels())
			{
				level.resetLevel();
				Application.LoadLevel("EndScreen");
			}
			else
			{
				level.nextLevel();
				Application.LoadLevel("SmallIntestineStats");
			}
		}
    }

    public void OnNutrientHit()
    {
		// track nutrients earned
		trackStatVariables.increaseNutrientsEarned (NutrientHitScore);

		nutrients += NutrientHitScore;
		NutrientTextColor = Color.green;
	}



    public void OnFoodBlobFinish(int numNutrientsAlive)
    {
		if (numNutrientsAlive > 0) 
		{
			// track the food particles left at the end
			trackStatVariables.increaseFoodLost(numNutrientsAlive);

			health = Mathf.Clamp(health - numNutrientsAlive, 0, MAX_HEALTH);
			m_HealthTextColor = Color.red;
		} 
	}

    void OnGUI()
    {
		GUI.depth--;
		// draw nutrients text
		FontStyle.normal.textColor = NutrientTextColor;
		FontStyle.fontSize = (int)(Screen.width * .02f) + 1;
		GUI.Label(new Rect(Screen.width * .38f, Screen.height * .833f, Screen.width * .047f, Screen.height * .063f), "NUTRIENTS: " + nutrients, FontStyle);			
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
