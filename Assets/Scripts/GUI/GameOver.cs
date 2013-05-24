using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    public GUIStyle FontStyle;
    public GUIStyle ButtonStyle;

    void Start()
    {
        Time.timeScale = 0;
    }

    void OnGUI()
    {
        Matrix4x4 orig = GUI.matrix;
        GUI.matrix = GuiUtility.CachedScaledMatrix;


        GUI.Label(new Rect((GuiUtility.ORIG_SCREEN_WIDTH - 500) / 2, (GuiUtility.ORIG_SCREEN_HEIGHT - 400) / 2, 500, 200), "GAME OVER", FontStyle);

        if (GUI.Button(new Rect((GuiUtility.ORIG_SCREEN_WIDTH - 200) / 2, (GuiUtility.ORIG_SCREEN_HEIGHT + 300) / 2, 200, 100), "Restart", ButtonStyle))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        GUI.matrix = orig;
    }
}
