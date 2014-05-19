using UnityEngine;
using System.Collections;

public class DesiredSILevel : MonoBehaviour 
{
	private int desiredLevel;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void setDesiredLevel(int level)
	{
		desiredLevel = level;
	}

	public int getDesiredLevel()
	{
		return desiredLevel;
	}

	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
	}
}
