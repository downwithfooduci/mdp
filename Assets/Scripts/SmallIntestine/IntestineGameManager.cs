using UnityEngine;
using System.Collections;

public class IntestineGameManager : MonoBehaviour 
{
	public int MAX_HEALTH = 20;
	
	private SpawnManager spawnScript;

    public GameObject GameOverScript;
    public GUIStyle FontStyle;
	
	public int health;
    public int nutrients;

    // Points gained for hitting a nutrient
    public int NutrientHitScore;
	
	public Color NutrientTextColor;
	private Color m_OriginalTextColor;

    private bool m_IsGameOver;

	public GameObject nutrientsCounter;
	private NutrientsText nutrientsText;

	public GameObject healthFace;
	private DrawHealthFace drawHealthFace;

	public GameObject healthBar;
	private DrawHealthBar drawHealthBar;
	
	void Start()
	{
		resetStats ();		// reset the vars in player prefs for later

		spawnScript = gameObject.GetComponent<SpawnManager> ();

		m_OriginalTextColor = NutrientTextColor = FontStyle.normal.textColor;

		nutrientsText = nutrientsCounter.GetComponent<NutrientsText> ();
		nutrientsText.setOriginalColor (m_OriginalTextColor);

		drawHealthFace = healthFace.GetComponent<DrawHealthFace> ();

		drawHealthBar = healthBar.GetComponent<DrawHealthBar> ();
	}
		
	// reset player prefs vars
	void resetStats()
	{
		PlayerPrefs.DeleteKey("SIStats_nutrientsEarned");
		PlayerPrefs.DeleteKey("SIStats_nurrientsSpent");
		PlayerPrefs.DeleteKey("SIStats_foodLost");
		PlayerPrefs.DeleteKey("SIStats_towersPlaced");
		PlayerPrefs.DeleteKey("SIStats_towersSold");
		PlayerPrefs.DeleteKey("SIStats_towersUpgraded");
		PlayerPrefs.DeleteKey("SIStats_enzymesFired");
		PlayerPrefs.Save();
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

		if(GameObject.FindWithTag("foodBlobParent") == null && spawnScript.end ||
		   Application.loadedLevelName == "SmallIntestineTutorial" && GameObject.FindWithTag("foodBlobParentTutorial") == null && spawnScript.end)
		{
			GameObject chooseBackground = GameObject.Find("ChooseBackground");
			SmallIntestineLoadLevelCounter  level = chooseBackground.GetComponent<SmallIntestineLoadLevelCounter>();

			level.nextLevel();
			Application.LoadLevel("SmallIntestineStats");
		}


		// draw nutrients text
		FontStyle.normal.textColor = NutrientTextColor;
		nutrientsText.updateText (nutrients, NutrientTextColor);
		FontStyle.normal.textColor = m_OriginalTextColor;

		// choose face to draw	
		if (health > .8 * MAX_HEALTH)
		{
			drawHealthFace.setFace(0);
		} else if (health > .6 * MAX_HEALTH)
		{
			drawHealthFace.setFace(1);
		} else if (health > .4 * MAX_HEALTH)
		{
			drawHealthFace.setFace(2);
		} else if (health > .2 * MAX_HEALTH)
		{
			drawHealthFace.setFace(3);
		} else 
		{
			drawHealthFace.setFace(4);
		}

		// for drawing the health bar
		drawHealthBar.setPercent(((float)health / (float)MAX_HEALTH));
    }

    public void OnNutrientHit()
    {
		// track nutrients earned
		PlayerPrefs.SetInt ("SIStats_nutrientsEarned", PlayerPrefs.GetInt("SIStats_nutrientsEarned") + 1);
		PlayerPrefs.Save();

		nutrients += NutrientHitScore;
		NutrientTextColor = Color.green;
	}



    public void OnFoodBlobFinish(int numNutrientsAlive)
    {
		if (numNutrientsAlive > 0) 
		{
			// track the food particles left at the end
			PlayerPrefs.SetInt("SIStats_foodLost", PlayerPrefs.GetInt("SIStats_foodLost") + numNutrientsAlive);
			PlayerPrefs.Save();

			health = Mathf.Clamp(health - numNutrientsAlive, 0, MAX_HEALTH);
		} 
	}
}
