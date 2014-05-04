using UnityEngine;
using System.Collections;

public class PageTurn : MonoBehaviour 
{
	public Texture corner;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (!audio.isPlaying)
			GUI.DrawTexture(new Rect(Screen.width - 100, 0, 100, 100), corner);
	}
}
