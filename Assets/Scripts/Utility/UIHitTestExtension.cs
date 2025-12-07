using UnityEngine;
using UnityEngine.UI;

public static class UIHitTestExtensions
{
    // Closest equivalent to old GUIElement.HitTest(screenPosition)
    public static bool HitTest(this Graphic graphic, Vector3 screenPosition)
    {
        if (graphic == null || !graphic.gameObject.activeInHierarchy)
            return false;

        var rt = graphic.rectTransform;
        var canvas = graphic.canvas;

        // Determine which camera to use (like old HitTest did)
        Camera cam = null;
        if (canvas != null && canvas.renderMode != RenderMode.ScreenSpaceOverlay)
        {
            cam = canvas.worldCamera ?? Camera.main;
        }

        return RectTransformUtility.RectangleContainsScreenPoint(rt, screenPosition, cam);
    }

    // Overload with explicit camera, if you ever used that version
    public static bool HitTest(this Graphic graphic, Vector3 screenPosition, Camera camera)
    {
        if (graphic == null || !graphic.gameObject.activeInHierarchy)
            return false;

        return RectTransformUtility.RectangleContainsScreenPoint(
            graphic.rectTransform,
            screenPosition,
            camera
        );
    }
}
