using UnityEngine;
using System.Collections;

public class SmallIntestineTutorialManager : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		PlayerPrefs.SetInt("SISpeedTutorial", 0);
		PlayerPrefs.Save();
	}
	
	// Update is called once per frame
	void Update () {}
}
