using UnityEngine;
using System.Collections;

public class EndScreen : MonoBehaviour {
	public Texture background;
	public GUIStyle mainMenu;
	public GUIStyle restart;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);
		if(GUI.Button(new Rect(Screen.width * .25f, .45f * Screen.height, Screen.width * .2f, Screen.height * .1f),
		                "", mainMenu))
		{
			Application.LoadLevel("MainMenu");
		}
		if(GUI.Button(new Rect(Screen.width * .55f, .45f * Screen.height, Screen.width * .2f, Screen.height * .1f),
		           "", restart))
		{
			Application.LoadLevel("LoadLevelSmallIntestine");
		}
	}
}
