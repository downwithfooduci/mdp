using UnityEngine;
using System.Collections;

public class LoadSmallIntestine : MonoBehaviour 
{

	public GameObject counter;
	public Texture[] backgrounds;
	private SmallIntestineLoadLevelCounter level;
	private const float timer = 3.0f;	// how long to hold background image
	private float timePassed = 0.0f;

	void Start()
	{
		timePassed = timer;
	}

	void OnGUI()
	{
		counter = GameObject.Find ("ChooseBackground");
		level = counter.GetComponent<SmallIntestineLoadLevelCounter> ();
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), backgrounds [Mathf.Clamp(level.getLevel() - 1, 0, level.getMaxLevels())]);
	}

	void Update()
	{

		timePassed -= Time.deltaTime;
		if (timePassed < 0) 
		{
			Application.LoadLevel("SmallIntestine");
		}
	}
}

