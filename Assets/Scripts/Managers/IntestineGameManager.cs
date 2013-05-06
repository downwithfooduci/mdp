using UnityEngine;
using System.Collections;

public class IntestineGameManager : MonoBehaviour {

    public GUIStyle FontStyle;

    public int PlayerScore;

    // Points gained for hitting a nutrient
    public int NutrientHitScore;

	// Use this for initialization
	void Start () {
        PlayerScore = 0;
	}

    public void OnNutrientHit()
    {
        PlayerScore += NutrientHitScore;
    }

    void OnGUI()
    {
        Matrix4x4 orig = GUI.matrix;
		GUI.matrix = GuiUtility.ScaledMatrix();

        GUI.Label(new Rect(1500, 100, 100, 100), "Nutrients: " + PlayerScore, FontStyle);

        GUI.matrix = orig;
    }
}
