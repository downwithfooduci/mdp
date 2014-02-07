using UnityEngine;
using System.Collections;

public class SmallIntestineLoadLevelCounter : MonoBehaviour {

	public int level;
	// Use this for initialization
	void Start () 
	{
		level = 0;	
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
	}

}
