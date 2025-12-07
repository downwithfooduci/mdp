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
	void Start () 
	{
		// set the pixel inset relative to screen size
		//GetComponent<Image>().pixelInset = new Rect(0, 0, Screen.width, Screen.height * 0.17578125f);
		RectTransform rt = GetComponent<RawImage>().GetComponent<RectTransform>();
		rt.anchoredPosition = new Vector2(0, 0);
		rt.sizeDelta = new Vector2(Screen.width, Screen.height * 0.17578125f);
	} 
}
