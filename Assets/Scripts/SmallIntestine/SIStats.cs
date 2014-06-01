using UnityEngine;
using System.Collections;

public class SIStats : MonoBehaviour 
{
	private int numStars = 0;

	// Use this for initialization
	void Start () 
	{
		populateStats ();
		calculateStars ();
	}

	void populateStats()
	{
	}

	void calculateStars()
	{
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		// Draw the number of stars
		GUIStyle starStyle = new GUIStyle ();
		starStyle.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		starStyle.normal.textColor = Color.yellow;
		starStyle.fontSize = (int)(34f / 597f * Screen.height);
		GUI.Label(new Rect((290f/1024f)*Screen.width, (138f/768f)*Screen.height, (100f/1024f)*Screen.width,
		                   (100f/768f)*Screen.height), "" + numStars, starStyle);


		// Draw the stats text
		GUIStyle statsStyle = new GUIStyle ();
		statsStyle.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		statsStyle.normal.textColor = Color.yellow;
		statsStyle.fontSize = (int)(20f / 597f * Screen.height);

		GUI.Label(new Rect((600f/1024f)*Screen.width, (90f/768f)*Screen.height, (((961f-27f)-600f)/1024f)*Screen.width,
		                   ((520f-90f)/768f)*Screen.height), "Testing", statsStyle);
	}
}
