using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	void OnGUI()
    {
        Matrix4x4 orig = GUI.matrix;
        GUI.matrix = GuiUtility.CachedScaledMatrix;

        if (GUI.Button(GuiUtility.CenteredXRect(0.4f, 0.2f, 0.1f), "Enzyme Game"))
        {
            Application.LoadLevel("BounceDemo");
        }

        if (GUI.Button(GuiUtility.CenteredXRect(0.55f, 0.2f, 0.1f), "Small Intestine Game"))
        {
            Application.LoadLevel("SmallIntestine");
        }

        GUI.matrix = orig;
    }
}
