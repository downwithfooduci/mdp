using UnityEngine;
using System.Collections;

public class DrawHealthBar : MonoBehaviour 
{
	private Rect healthRect;
	private float percent;

	// Use this for initialization
	void Start () 
	{
		healthRect = new Rect (Screen.width * 0.952f, Screen.height * (1f - 0.8622f) - Screen.height * 0.0948f, Screen.width * 0.032f, Screen.height * 0.0948f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		guiTexture.pixelInset = new Rect(healthRect.xMin, healthRect.yMin, 
		                                 healthRect.width, percent*healthRect.height);
	}

	public void setPercent(float percent)
	{
		this.percent = percent;
	}
}
