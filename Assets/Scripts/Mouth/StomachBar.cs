using UnityEngine;
using System.Collections;

public class StomachBar : MonoBehaviour 
{
	Vector2 position;
	Vector2 originalSize;
	public Texture stomachBar;
	private float percent;
	EsophagusDebugConfig config;
	private float depletionRate = .005f;
	private float gainRate = .075f;
	
	// Use this for initialization
	void Start () 
	{
		percent = 0f;			// stomach bar starts off empty
		GameObject debugger = GameObject.Find("Debugger");
		config = debugger.GetComponent<EsophagusDebugConfig>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// get values from debugger if active
		if(config.debugActive)
		{
			depletionRate = config.stomachDeplete;
			gainRate = config.stomachGain;
		}

		// update the stomach bar
		percent -= depletionRate * Time.deltaTime;
		percent = Mathf.Clamp(percent, 0, 1f);
	}
	
	void OnGUI()
	{
		position.x = (2779f / 3072f) * Screen.width;
		position.y = (1535f / 2304f) * Screen.height + (1f-percent) * (673f / 2304f) * Screen.height;
		originalSize.x = (190f / 3072f) * Screen.width;
		originalSize.y = (673f / 2304f) * Screen.height * percent;
		GUI.DrawTexture(new Rect(position.x, position.y, originalSize.x, originalSize.y), stomachBar);
	}
	
	public float getPercent()
	{
		return percent;
	}

	public void increaseStomachPercent()
	{
		percent += gainRate;
	}

}
