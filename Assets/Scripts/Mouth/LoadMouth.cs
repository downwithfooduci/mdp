using UnityEngine;
using System.Collections;

public class LoadMouth : MonoBehaviour 
{
	private GameObject counter;			// to keep track of levels
//	public GameObject statsTracker;	// to keep track of stats	//TODO: add for mouth game
	
	public Texture[] backgrounds;
	private MouthLoadLevelCounter level;
	private const float timer = 3.0f;	// how long to hold background image
	private float timePassed = 0.0f;


	// Use this for initialization
	void Start () 
	{
		timePassed = timer;
		
		// check if a stats tracker exists 	//TODO: for mouth game
		//GameObject existingStatsTracker = GameObject.Find ("SIStatsTracker(Clone)");
		
		// if one doesn't create it
		//if (existingStatsTracker == null) 
		//{
		//	Instantiate(statsTracker);
		//}
	}
	
	// Update is called once per frame
	void Update () 
	{
		timePassed -= Time.deltaTime;
		if (timePassed < 0) 
		{
			Application.LoadLevel("Mouth");
		}
	}

	void OnGUI()
	{
		counter = GameObject.Find ("MouthChooseBackground");
		level = counter.GetComponent<MouthLoadLevelCounter> ();
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), backgrounds [Mathf.Clamp(level.getLevel() - 1, 0, level.getMaxLevels())]);
	}
}
