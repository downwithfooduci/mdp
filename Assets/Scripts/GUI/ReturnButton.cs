using UnityEngine;
using System.Collections;

public class ReturnButton : MonoBehaviour {

	void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 75, 75), "Return"))
        {
			Time.timeScale = 1;
            Application.LoadLevel("MainMenu");
        }
    }
}
