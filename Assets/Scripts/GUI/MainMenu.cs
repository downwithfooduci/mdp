using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Texture background;
	void OnGUI()
    {
		Debug.Log(Screen.width);
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), background);
		if (GUI.Button(new Rect(Screen.width * 0.15f, Screen.height * 0.8f, 
		                        Screen.width * 0.2f, Screen.height * 0.1f), "Enzyme Game"))
        {
            Application.LoadLevel("Enzyme");
        }

		if (GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.8f,
		                        Screen.width * 0.2f, Screen.height * 0.1f), "Small Intestine Game"))
        {
            Application.LoadLevel("SmallIntestine");
        }
		
		if (GUI.Button(new Rect(Screen.width * 0.65f, Screen.height * 0.8f, 
		                        Screen.width * 0.2f, Screen.height * 0.1f), "Pinch to Zoom Test"))
        {
            Application.LoadLevel("pinch");
        }
    }
}
