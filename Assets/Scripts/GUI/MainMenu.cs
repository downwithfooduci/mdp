using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	void OnGUI()
    {
        Matrix4x4 orig = GUI.matrix;
        GUI.matrix = GuiUtility.CachedScaledMatrix;

        if (GUI.Button(new Rect((GuiUtility.ORIG_SCREEN_WIDTH - 300) / 2, (GuiUtility.ORIG_SCREEN_HEIGHT - 150) / 2, 300, 100), "Enzyme Game"))
        {
            Application.LoadLevel("BounceDemo");
        }

        if (GUI.Button(new Rect((GuiUtility.ORIG_SCREEN_WIDTH - 300) / 2, (GuiUtility.ORIG_SCREEN_HEIGHT + 100) / 2, 300, 100), "Small Intestine Game"))
        {
            Application.LoadLevel("SmallIntestine");
        }

        GUI.matrix = orig;
    }
}
