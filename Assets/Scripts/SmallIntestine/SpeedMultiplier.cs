using UnityEngine;
using System.Collections;

public class SpeedMultiplier : MonoBehaviour {
	bool value;
	// Use this for initialization
	void Start () {
		value = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		value = GUI.Toggle (new Rect (Screen.width * 0.895546875f, Screen.height * 0.79417f, Screen.width * 0.159296875f, Screen.height * 0.03f),
		              value,
		                   "2x Speed");
		if (value && Time.timeScale == 1)
			Time.timeScale = 2;
		else if(!value && Time.timeScale == 2)
			Time.timeScale = 1;

	}
}
