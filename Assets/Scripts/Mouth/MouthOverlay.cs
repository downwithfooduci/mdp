using UnityEngine;
using System.Collections;

public class MouthOverlay : MonoBehaviour {
	public Texture mouthOverlay, sideBar;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), mouthOverlay);
		GUI.DrawTexture(new Rect(Screen.width * .87f, 0, Screen.width * .13f, Screen.height), sideBar);
	}
}
