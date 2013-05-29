using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	void OnGUI()
    {
        Matrix4x4 orig = GUI.matrix;
        GUI.matrix = GuiUtility.CachedScaledMatrix;


        GUI.Label(new Rect((GuiUtility.ORIG_SCREEN_WIDTH - 250) / 2, (GuiUtility.ORIG_SCREEN_HEIGHT - 200) / 2, 250, 100), "GAME OVER");

        if (GUI.Button(new Rect((GuiUtility.ORIG_SCREEN_WIDTH - 100) / 2, (GuiUtility.ORIG_SCREEN_HEIGHT + 150) / 2, 100, 50), "Restart"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        GUI.matrix = orig;
    }
}
