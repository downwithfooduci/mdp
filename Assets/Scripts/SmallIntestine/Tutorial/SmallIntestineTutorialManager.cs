using UnityEngine;
using System.Collections;

/**
 * Handles small intestine tutorial management
 */
public class SmallIntestineTutorialManager : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		PlayerPrefs.SetInt("SISpeedTutorial", 0);
		PlayerPrefs.SetInt("SIFatsTutorial", 0);
		PlayerPrefs.Save();
	}
}
