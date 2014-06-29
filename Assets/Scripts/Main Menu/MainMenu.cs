using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public Texture background;
	public GUIStyle startBtn;

	void Start()
	{
	}

	void OnGUI()
    {
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), background);

		if (GUI.Button(new Rect(Screen.width * 0.8f, Screen.height * 0.9f,
		                        Screen.width * 0.2f, Screen.height * 0.1f), "", startBtn))
        {
			Application.LoadLevel("IntroStoryboard");
        }

		if (GUI.Button(new Rect(0, Screen.height * 0.9f,
		                        Screen.width * 0.2f, Screen.height * 0.1f), "Levels"))
		{
			Application.LoadLevel("LevelSelection");
		}
	}
}
