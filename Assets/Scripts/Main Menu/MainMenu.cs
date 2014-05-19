using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public GameObject skipStoryEnabler;
	public Texture background;
	public GUIStyle startBtn;

	void Start()
	{
		// don't redefine if there is already one of these
		if (GameObject.Find("SkipStoryEnabler") == null)
		{
			Instantiate (skipStoryEnabler);
		}
	}

	void OnGUI()
    {
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), background);

		if (GUI.Button(new Rect(Screen.width * 0.8f, Screen.height * 0.9f,
		                        Screen.width * 0.2f, Screen.height * 0.1f), "", startBtn))
        {
			Application.LoadLevel("IntroStoryboard");
        }
    }
}
