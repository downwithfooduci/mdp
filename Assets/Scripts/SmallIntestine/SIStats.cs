using UnityEngine;
using System.Collections;

public class SIStats : MonoBehaviour 
{
	// for drawing stars
	public Texture filledStar;
	public Texture emptyStar;

	// for drawing next level button
	public GUIStyle nextLevelButton;

	private int numStars = 1;

	// for holding the tracker
	private GameObject statTracker;
	private TrackStatVariables trackStatVariables;

	// for holding level 
	private GameObject counter;
	private SmallIntestineLoadLevelCounter level;

	// variables to hold stats, should coincide with variables in TrackStatVariables.cs
	// list desired stats for tracking here
	private int nutrientsEarned;
	private int nutrientsSpent;
	private int foodLost;
	private int towersPlaced;
	private int towersSold;
	private int towersUpgraded;
	private int enzymesFired;

	// for high scores
	int prevHighScore;
	
	// Use this for initialization
	void Start () 
	{
		// pull up the stats tracker
		statTracker = GameObject.Find ("SIStatTracker(Clone)");
		trackStatVariables = statTracker.GetComponent<TrackStatVariables>();

		// pull up the level
		counter = GameObject.Find ("ChooseBackground");
		level = counter.GetComponent<SmallIntestineLoadLevelCounter> ();

		if(statTracker != null)
			populateStats();
		calculateStars();
	}

	void populateStats()
	{
		nutrientsEarned = trackStatVariables.getNutrientsEarned();
		nutrientsSpent = trackStatVariables.getNutrientsSpent();
		foodLost = trackStatVariables.getFoodLost();
		towersPlaced = trackStatVariables.getTowersPlaced();
		towersSold = trackStatVariables.getTowersSold();
		towersUpgraded = trackStatVariables.getTowersUpgraded();
		enzymesFired = trackStatVariables.getEnzymesFired();
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
	
		saveHighScore();
	}
	
	void saveHighScore()
	{
		prevHighScore = PlayerPrefs.GetInt ("SI" + (level.getLevel() - 1));
		
		// check if high score
		if (prevHighScore < numStars)
		{
			// if it is the high score save it
			PlayerPrefs.SetInt("SI" + (level.getLevel() - 1), numStars);
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
		          "Nutrients Earned:\n" +
		          "Nutrients Spent:\n" +
		          "Food Lost:\n" +
		          "Towers Placed:\n" +
		          "Towers Sold:\n" +
		          "Towers Upgraded:\n" +
		          "Enzymes Released:\n" +
		          "\n" +						//TODO: move this somewhere?
		          "Previous\n" +				//TODO: move this somehwere?
		          " High Score:",				//TODO: move this somewhere?
		          statsStyle);
		GUI.Label(new Rect((820f/1024f)*Screen.width, (90f/768f)*Screen.height, (((961f-27f)-600f)/1024f)*Screen.width,
		                   ((520f-90f)/768f)*Screen.height), 
		          ""   + nutrientsEarned + "\n" +
		          ""  + nutrientsSpent  + "\n" +
		          ""  + foodLost 	    + "\n" +
		          ""  + towersPlaced    + "\n" +
		          ""  + towersSold      + "\n" +
		          ""	  + towersUpgraded  + "\n" +
		          ""  + enzymesFired    + "\n"+
		          "\n" +						//TODO: move this somewhere?
		          "\n" + 						//TODO: move this somewhere?
		          "" + prevHighScore,			//TODO: move this somewhere?
		          statsStyle);

		// draw the button for next level
		if (GUI.Button(new Rect((635f/1024f)*Screen.width, (535f/768f)*Screen.height,
		                        ((905f-635f)/1024f)*Screen.width, ((665f-535f)/768f)*Screen.height), "", nextLevelButton))
		{
			trackStatVariables.reset();
			Application.LoadLevel("LoadLevelSmallIntestine");
		}
	}
}