using UnityEngine;
using System.Collections;

public class IntestineGameManager : MonoBehaviour {
    public GameObject GameOverScript;
    public GUIStyle FontStyle;
	
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
		m_OriginalTextColor = m_HealthTextColor = NutrientTextColor = FontStyle.normal.textColor;
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
    }

    public void OnNutrientHit()
    {
        Nutrients += NutrientHitScore;
		NutrientTextColor = Color.green;
    }

    public void OnFoodBlobFinish()
    {
        Health--;
		m_HealthTextColor = Color.red;
    }

    void OnGUI()
    {
        Matrix4x4 orig = GUI.matrix;
		GUI.matrix = GuiUtility.CachedScaledMatrix;

		FontStyle.normal.textColor = m_HealthTextColor;
        GUI.Label(new Rect(750, 25, 50, 50), "Health: " + Health, FontStyle);
		FontStyle.normal.textColor = m_OriginalTextColor;
		
		FontStyle.normal.textColor = NutrientTextColor;
        GUI.Label(new Rect(750, 50, 50, 50), "Nutrients: " + Nutrients, FontStyle);			
		FontStyle.normal.textColor = m_OriginalTextColor;

        GUI.matrix = orig;
    }
}
