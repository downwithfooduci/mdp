using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public Texture gameOverPopup;
	public GUIStyle restart;
	public GUIStyle mainMenu;

    void Start()
    {
        Time.timeScale = 0;
    }

    void OnGUI()
    {
		GUI.DrawTexture(new Rect(Screen.width * 0.3193359375f, 
		                         Screen.height * 0.28515625f, 
		                         Screen.width * 0.3603515625f, 
		                         Screen.height * 0.248697917f), gameOverPopup);
		
		// draw yes button
		if (GUI.Button(new Rect(Screen.width * 0.41015625f, 
		                        Screen.height * 0.41927083f,
		                        Screen.width * 0.0654296875f,
		                        Screen.height * 0.06640625f), "", restart))
		{
			Time.timeScale = 1;
			Application.LoadLevel("SmallIntestine");
		}
		
		// draw no button
		if (GUI.Button(new Rect(Screen.width * 0.53125f, 
		                        Screen.height * 0.41927083f,
		                        Screen.width * 0.0654296875f,
		                        Screen.height * 0.06640625f), "", mainMenu))
		{
			Time.timeScale = 1;
			GameObject chooseBackground = GameObject.Find("ChooseBackground");
			SmallIntestineLoadLevelCounter  level = chooseBackground.GetComponent<SmallIntestineLoadLevelCounter>();
			level.level = 0;
			Application.LoadLevel("MainMenu");
		}
    }
}
