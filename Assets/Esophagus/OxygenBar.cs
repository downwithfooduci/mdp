using UnityEngine;
using System.Collections;

public class OxygenBar : MonoBehaviour {
	Vector2 position;
	Vector2 originalSize;
	public Texture oxygenBar;
	private float percent;
	openFlap flap;
	// Use this for initialization
	void Start () {
		percent = 1f;
		GameObject flaps = GameObject.Find("Flaps");
		flap = flaps.GetComponent<openFlap>();
	}
	
	// Update is called once per frame
	void Update () {
		if(flap.isEpiglotisOpen())
			percent -= .05f * Time.deltaTime;
		else
			percent += .05f * Time.deltaTime;
		percent = Mathf.Clamp(percent, 0, 1f);
	}

	void OnGUI()
	{
		position.x = (2760f / 3072f) * Screen.width;
		position.y = (847f / 2304f) * Screen.height + (1f-percent) * (610f / 2304f) * Screen.height;
		originalSize.x = (126f / 3072f) * Screen.width;
		originalSize.y = (610f / 2304f) * Screen.height * percent;
		GUI.DrawTexture(new Rect(position.x, position.y, originalSize.x, originalSize.y), oxygenBar);
	}

	public float getPercent()
	{
		return percent;
	}

}
