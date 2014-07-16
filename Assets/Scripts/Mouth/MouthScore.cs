using UnityEngine;
using System.Collections;

public class MouthScore : MonoBehaviour {
	public int score, foodChain;
	public int FourMultCount, SixteenMultCount;
	public Texture FourMultTexture, SixteenMulTexture;
	openFlap flapScript;

	// Use this for initialization
	void Start () 
	{
		flapScript = GameObject.Find("Flaps").GetComponent<openFlap>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(flapScript.isCough())
			foodChain = 0;
	}

	public void collectFood()
	{
		int scoreToAdd = 1;
		scoreToAdd *= foodChain >= FourMultCount ? 4 : 1;
		scoreToAdd *= foodChain >= SixteenMultCount ? 4 : 1;
		score += scoreToAdd;
		foodChain++;

		// track stats
		PlayerPrefs.SetInt ("MouthStats_score", score);
		PlayerPrefs.SetInt ("MouthStats_longestStreak", foodChain);
		PlayerPrefs.SetInt ("MouthStats_foodSwallowed", PlayerPrefs.GetInt("MouthStats_foodSwallowed") + 1);

		if (foodChain >= SixteenMultCount) 
		{
			PlayerPrefs.SetInt ("MouthStats_highestMultiplier", 16);
		} else if (foodChain >= FourMultCount)
		{
			if (PlayerPrefs.GetInt("MouthStats_highestMultiplier") < 4)
			{
				PlayerPrefs.SetInt("MouthStats_highestMultiplier", 4);
			}
		}

		PlayerPrefs.Save();
	}

	void OnGUI()
	{
		GUI.depth--;
		if(foodChain >= SixteenMultCount)
		{
			GUI.DrawTexture(new Rect(Screen.width * .91f, Screen.height * .85f, Screen.height * .08f,
			                         Screen.height * .08f), SixteenMulTexture);
		} else if(foodChain >= FourMultCount)
		{
			GUI.DrawTexture(new Rect(Screen.width * .91f, Screen.height * .85f, Screen.height * .08f,
			                         Screen.height * .08f), FourMultTexture);
		}

		GUIStyle scoreStyle = GUI.skin.label;
		scoreStyle.alignment = TextAnchor.MiddleCenter;
		scoreStyle.fontSize = (int)(34f / 597f * Screen.height);
		scoreStyle.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		scoreStyle.normal.textColor = new Color (206f / 255f, 39f / 255f, 115f / 255f);

		GUI.Label(new Rect(Screen.width * .89f,Screen.height * .93f, Screen.width * .1f, Screen.height * .07f), "" + score);
	}
}
