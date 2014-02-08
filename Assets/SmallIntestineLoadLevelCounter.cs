using UnityEngine;
using System.Collections;

public class SmallIntestineLoadLevelCounter : MonoBehaviour {

	public int level;
	// Use this for initialization
	void Start () 
	{
		if (GameObject.FindGameObjectsWithTag ("backgroundChooser").Length > 1)
						Destroy (gameObject);
		level = 0;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		string scene = Application.loadedLevelName;
		if (scene != "LoadLevelSmallIntestine" && scene != "SmallIntestine")
						Destroy (gameObject);
	}

	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
	}

}
