using UnityEngine;
using System.Collections;

public class MouthScore : MonoBehaviour {
	public int score, foodChain;
	public int FourMultCount, SixteenMultCount;
	public Texture FourMultTexture, SixteenMulTexture;
	openFlap flapScript;
	TrackMouthVariables stats;
	// Use this for initialization
	void Start () {
		flapScript = GameObject.Find("Flaps").GetComponent<openFlap>();
		stats = GameObject.Find ("MouthStatTracker(Clone)").GetComponent<TrackMouthVariables>();
	}
	
	// Update is called once per frame
	void Update () {
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
		stats.setScore(score);
		stats.setLongestStreak(foodChain);
		stats.swallowFood();
	}

	void OnGUI()
	{
		if(foodChain >= SixteenMultCount)
		{
			GUI.DrawTexture(new Rect(Screen.width * .01f, Screen.height * .85f, Screen.height * .08f,
			                         Screen.height * .08f), SixteenMulTexture);
		} else if(foodChain >= FourMultCount)
		{
			GUI.DrawTexture(new Rect(Screen.width * .01f, Screen.height * .85f, Screen.height * .08f,
			                         Screen.height * .08f), FourMultTexture);
		}
		GUIStyle scoreStyle = GUI.skin.label;
		scoreStyle.alignment = TextAnchor.MiddleLeft;
		scoreStyle.fontSize = (int)(34f / 597f * Screen.height);
		scoreStyle.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		scoreStyle.normal.textColor = Color.yellow;

		GUI.Label(new Rect(Screen.width * .01f,Screen.height * .93f, Screen.width * .1f, Screen.height * .07f), "" + score);
	}
}
