using UnityEngine;
using System.Collections;

public class PageTurn : MonoBehaviour 
{
	public Texture corner;
	private GameObject skipStory; 
	private bool canSkip = false;

	// Use this for initialization
	void Start () 
	{
		skipStory = GameObject.Find("SkipStoryEnabler(Clone)");
		SkipStoryEnablerScript skipStoryScript = skipStory.GetComponent<SkipStoryEnablerScript> ();
		if (skipStoryScript != null)
		{
			canSkip = skipStoryScript.getSkipStory();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.depth--;
		if (!audio.isPlaying || canSkip)
			GUI.DrawTexture(new Rect(Screen.width * .84f, 0, Screen.width * .16f, Screen.width * .16f), corner);
	}
}
