using UnityEngine;
using System.Collections;

public class LoadSmallIntestine : MonoBehaviour 
{
	private GameObject counter;			// to keep track of levels
	public GameObject statsTracker;	// to keep track of stats

	public Texture[] backgrounds;
	private SmallIntestineLoadLevelCounter level;
	private const float timer = 3.0f;	// how long to hold background image
	private float timePassed = 0.0f;

	void Start()
	{
		timePassed = timer;

		// check if a stats tracker exists
		GameObject existingStatsTracker = GameObject.Find ("SIStatTracker(Clone)");

		// if one doesn't create it
		if (existingStatsTracker == null) 
		{
			Instantiate(statsTracker);
		}
	}

	void OnGUI()
	{
		counter = GameObject.Find ("ChooseBackground");
		level = counter.GetComponent<SmallIntestineLoadLevelCounter> ();
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), backgrounds [Mathf.Clamp(level.getLevel(), 0, level.getMaxLevels())]);
	}

	void Update()
	{

		timePassed -= Time.deltaTime;
		if (timePassed < 0) 
		{
			if (level.getLevel() == 0)
			{
				Application.LoadLevel("SmallIntestineTutorial");
			} else if (level.getLevel() % 2 == 0)
			{
				Application.LoadLevel("SmallIntestineEven");
			} else
			{
				Application.LoadLevel("SmallIntestineOdd");
			}
		}
	}
}

