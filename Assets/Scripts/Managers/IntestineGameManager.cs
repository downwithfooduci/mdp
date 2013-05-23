using UnityEngine;
using System.Collections;

public class IntestineGameManager : MonoBehaviour {

    public GameObject GameOverScript;
    public GUIStyle FontStyle;
	
	public int Health;
    public int Nutrients;

    // Points gained for hitting a nutrient
    public int NutrientHitScore;

    void Update()
    {
        if (Health <= 0)
        {
            Instantiate(GameOverScript);
        }
    }

    public void OnNutrientHit()
    {
        Nutrients += NutrientHitScore;
    }

    public void OnFoodBlobFinish()
    {
        Health--;
    }

    void OnGUI()
    {
        Matrix4x4 orig = GUI.matrix;
		GUI.matrix = GuiUtility.CachedScaledMatrix;

        GUI.Label(new Rect(1500, 50, 100, 100), "Health: " + Health, FontStyle);
        GUI.Label(new Rect(1500, 100, 100, 100), "Nutrients: " + Nutrients, FontStyle);

        GUI.matrix = orig;
    }
}
