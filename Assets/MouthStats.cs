using UnityEngine;
using System.Collections;

public class MouthStats : MonoBehaviour {
	// for drawing stars
	public Texture filledStar;
	public Texture emptyStar;
	
	// for drawing next level button
	public GUIStyle nextLevelButton;
	
	private int numStars = 1;
	
	// for holding the tracker
	private GameObject statTracker;
	private TrackMouthVariables trackMouthVariables;
	// variables to hold stats, should coincide with variables in TrackStatVariables.cs
	// list desired stats for tracking here
	int longestStreak;
	int timesCoughed;
	int foodLost;
	int foodSwallowed;
	int highestMultiplier;
	int score;
	
	// Use this for initialization
	void Start () 
	{
		statTracker = GameObject.Find ("MouthStatTracker(Clone)");
		trackMouthVariables = statTracker.GetComponent<TrackMouthVariables>();
		if(statTracker != null)
			populateStats();
		calculateStars();
	}
	
	void populateStats()
	{
		longestStreak = trackMouthVariables.getLongestStreak();
		timesCoughed = trackMouthVariables.getTimesCoughed();
		foodLost = trackMouthVariables.getFoodLost();
		foodSwallowed = trackMouthVariables.getFoodSwallowed();
		highestMultiplier = trackMouthVariables.getHighestMultiplier();
		score = trackMouthVariables.getScore();
	}
	
	// placeholder algorithm
	void calculateStars()
	{
		if (foodLost == 0)
		{
			numStars = 5;
		} else if (foodLost <= 5)
		{
			numStars = 4;
		} else if (foodLost <= 10)
		{
			numStars = 3;
		} else if (foodLost <= 15)
		{
			numStars = 2;
		} else
		{
			numStars = 1;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnGUI()
	{
		// Draw the number of stars text
		GUIStyle starStyle = new GUIStyle ();
		starStyle.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		starStyle.normal.textColor = Color.yellow;
		starStyle.fontSize = (int)(34f / 597f * Screen.height);
		GUI.Label(new Rect((290f/1024f)*Screen.width, (138f/768f)*Screen.height, (100f/1024f)*Screen.width,
		                   (100f/768f)*Screen.height), "" + numStars, starStyle);
		
		// draw the actual stars
		if (numStars == 1)
		{
			GUI.DrawTexture(new Rect((48f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect((142f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), emptyStar);
			GUI.DrawTexture(new Rect((236f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), emptyStar);
			GUI.DrawTexture(new Rect((330f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), emptyStar);
			GUI.DrawTexture(new Rect((424f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), emptyStar);
		} else if (numStars == 2)
		{
			GUI.DrawTexture(new Rect((48f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect((142f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect((236f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), emptyStar);
			GUI.DrawTexture(new Rect((330f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), emptyStar);
			GUI.DrawTexture(new Rect((424f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), emptyStar);
		} else if (numStars == 3)
		{
			GUI.DrawTexture(new Rect((48f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect((142f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect((236f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect((330f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), emptyStar);
			GUI.DrawTexture(new Rect((424f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), emptyStar);
		} else if (numStars == 4)
		{
			GUI.DrawTexture(new Rect((48f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect((142f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect((236f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect((330f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect((424f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), emptyStar);
		} else if (numStars == 5)
		{
			GUI.DrawTexture(new Rect((48f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect((142f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect((236f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect((330f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), filledStar);
			GUI.DrawTexture(new Rect((424f/1024f)*Screen.width, (236f/768f)*Screen.height, (74f/1024f)*Screen.width,
			                         (74f/768f)*Screen.height), filledStar);
		}
		
		
		// Draw the stats text
		GUIStyle statsStyle = new GUIStyle ();
		statsStyle.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		statsStyle.normal.textColor = Color.yellow;
		statsStyle.fontSize = (int)(20f / 597f * Screen.height);
		
		GUI.Label(new Rect((600f/1024f)*Screen.width, (90f/768f)*Screen.height, (((961f-27f)-600f)/1024f)*Screen.width,
		                   ((520f-90f)/768f)*Screen.height), 
		          "Longest Streak:\n" +
		          "Coughs:\n" +
		          "Food Lost:\n" +
		          "Food Swallowed:\n" +
		          "Highest Multiplier:\n" +
		          "Score:\n",
		          statsStyle);
		GUI.Label(new Rect((820f/1024f)*Screen.width, (90f/768f)*Screen.height, (((961f-27f)-600f)/1024f)*Screen.width,
		                   ((520f-90f)/768f)*Screen.height), 
		          "" + longestStreak + "\n" +
		          "" + timesCoughed + "\n" +
		          "" + foodLost + "\n" +
		          "" + foodSwallowed + "\n" +
		          "" + highestMultiplier + "x\n" +
		          "" + score + "\n",
		          statsStyle);
		// draw the button for next level
		if (GUI.Button(new Rect((635f/1024f)*Screen.width, (535f/768f)*Screen.height,
		                        ((905f-635f)/1024f)*Screen.width, ((665f-535f)/768f)*Screen.height), "", nextLevelButton))
		{
			trackMouthVariables.reset();
			Application.LoadLevel("LoadLevelMouth");
		}
	}
}
