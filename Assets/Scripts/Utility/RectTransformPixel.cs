using UnityEngine;
public static class RectTransformPixel
{
    public static void SetBottomLeftRect(this RectTransform rt, Rect r)
    {
        rt.anchorMin = rt.anchorMax = new Vector2(0f, 0f);
        rt.pivot     = new Vector2(0f, 0f);

        rt.sizeDelta        = r.size;
        rt.anchoredPosition = r.position;
    }
}
