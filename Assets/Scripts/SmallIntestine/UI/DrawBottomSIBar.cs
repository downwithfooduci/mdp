using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * script that handles drawing the bottom bar (without any overlays) in the si game
 */
public class DrawBottomSIBar : MonoBehaviour 
{
	/**
	 * Use this for initialization
	 * Sets the location to draw the bar
	 */
	void Start()
	{
		var rt  = GetComponent<RectTransform>();

		rt.anchorMin = rt.anchorMax = new Vector2(0f, 0f); // bottom-left
		rt.pivot     = new Vector2(0f, 0f);                // pivot bottom-left too

		rt.sizeDelta        = new Vector2(1024, 135);
		rt.anchoredPosition = new Vector2(0, 0);

	}
}