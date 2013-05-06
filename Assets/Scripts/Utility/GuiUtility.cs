using UnityEngine;
using System.Collections;

public static class GuiUtility
{
    public static float ORIG_SCREEN_WIDTH = 2048f;
    public static float ORIG_SCREEN_HEIGHT = 1536f;

    // Given percentages as input, produces
    // Rect with adjusted values
    public static Rect PercRect(float x, float y, float width = 0.1f, float height = 0.1f)
    {
        Rect rect = new Rect(ORIG_SCREEN_WIDTH * x, ORIG_SCREEN_HEIGHT * y, ORIG_SCREEN_WIDTH * width, ORIG_SCREEN_HEIGHT * height);
        return rect;
    }

    public static Matrix4x4 ScaledMatrix()
    {
        Vector3 scale = new Vector3(0, 0, 1);
        scale.x = Screen.width / ORIG_SCREEN_WIDTH;
        scale.y = Screen.height / ORIG_SCREEN_HEIGHT;

        return Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
    }
}
