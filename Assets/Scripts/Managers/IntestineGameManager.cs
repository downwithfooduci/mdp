using UnityEngine;
using System.Collections;

public class IntestineGameManager : MonoBehaviour 
{
	public int MAX_HEALTH = 20;

	private SpawnManager spawnScript;

    public GameObject GameOverScript;
    public GUIStyle FontStyle;

	public Texture[] faces;
	public Texture healthBar;
	private Rect faceRect;
	private Rect healthRect;
	
	public int Health;
    public int Nutrients;

    // Points gained for hitting a nutrient
    public int NutrientHitScore;
	
	public Color NutrientTextColor;
	private Color m_OriginalTextColor;
	
	private Color m_HealthTextColor;

    private bool m_IsGameOver;
	
	void Start()
	{
		spawnScript = gameObject.GetComponent<SpawnManager> ();

		m_OriginalTextColor = m_HealthTextColor = NutrientTextColor = FontStyle.normal.textColor;

		faceRect = new Rect (Screen.width * 0.83203125f, Screen.height * 0.8489583f, Screen.width * 0.078125f, Screen.height * 0.102864583f);
		healthRect = new Rect (Screen.width * 0.935546875f, Screen.height * 0.85417f, Screen.width * 0.029296875f, Screen.height * 0.092447917f);
	}

    void Update()
    {
        if (m_IsGameOver)
            return;

        if (Health <= 0)
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
			chooseBackground.GetComponent<SmallIntestineLoadLevelCounter>().level++;
			Application.LoadLevel("LoadLevelSmallIntestine");
		}
    }

    public void OnNutrientHit()
    {
        Nutrients += NutrientHitScore;
		NutrientTextColor = Color.green;
    }



    public void OnFoodBlobFinish(bool isAlive)
    {
		if (isAlive) 
		{
        	Health--;
			m_HealthTextColor = Color.red;
		} 
	}

    void OnGUI()
    {
		GUI.depth--;

		// draw nutrients text
		FontStyle.normal.textColor = NutrientTextColor;
		FontStyle.fontSize = 16;
		GUI.Label(new Rect(Screen.width * 0.837f, Screen.height * 0.955f, 40, 40), "Nutrients: " + Nutrients, FontStyle);			
		FontStyle.normal.textColor = m_OriginalTextColor;

		// choose face to draw
		if (Health > .8 * MAX_HEALTH)
		{
			GUI.DrawTexture (faceRect, faces [0]);
		} else if (Health > .6 * MAX_HEALTH)
		{
			GUI.DrawTexture (faceRect, faces [1]);
		} else if (Health > .4 * MAX_HEALTH)
		{
			GUI.DrawTexture (faceRect, faces [2]);
		} else if (Health > .2 * MAX_HEALTH)
		{
			GUI.DrawTexture (faceRect, faces [3]);
		} else 
		{
			GUI.DrawTexture (faceRect, faces [4]);
		}

		// change drawing of health bar
		GUI.DrawTexture (new Rect(healthRect.xMin, healthRect.yMin + (1-(float)Health/(float)MAX_HEALTH)*healthRect.height, 
		                          healthRect.width, ((float)Health/(float)MAX_HEALTH)*healthRect.height), healthBar);

    }
}
