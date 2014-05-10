using UnityEngine;
using System.Collections;

/*
 * Remembers whether we have played through a game.
 * */
public class SkipStoryEnablerScript : MonoBehaviour 
{
	private bool skipStory;

	// Use this for initialization
	void Start () 
	{
		skipStory = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void setSkipStory(bool enable)
	{
		skipStory = enable;
	}

	public bool getSkipStory()
	{
		return skipStory;
	}

	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
	}
}
