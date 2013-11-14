using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	void OnGUI()
    {
		Debug.Log(Screen.width);
		if (GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.4f, 
		                        Screen.width * 0.2f, Screen.height * 0.1f), "Enzyme Game"))
        {
            Application.LoadLevel("Enzyme");
        }

		if (GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.55f,
		                        Screen.width * 0.2f, Screen.height * 0.1f), "Small Intestine Game"))
        {
            Application.LoadLevel("SmallIntestine");
        }
		
		if (GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.7f, 
		                        Screen.width * 0.2f, Screen.height * 0.1f), "Pinch to Zoom Test"))
        {
            Application.LoadLevel("pinch");
        }
    }
}
