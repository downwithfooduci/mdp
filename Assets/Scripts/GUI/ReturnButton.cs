using UnityEngine;
using System.Collections;

public class ReturnButton : MonoBehaviour {
	public GUIStyle mainMenuStyle;
	void OnGUI()
    {
		if (GUI.Button(new Rect(Screen.width * .89f, 
		                        Screen.height * 0.01822916f,
		                        Screen.width * .09f,
		                        Screen.height * .06f), "", mainMenuStyle))
        {
			Time.timeScale = 1;
            Application.LoadLevel("MainMenu");
        }
    }
}
