using UnityEngine;
using System.Collections;

public class OxygenBar : MonoBehaviour {
	Vector2 position;
	Vector2 originalSize;
	public Texture oxygenBar;
	public float percent;
	openFlap flap;
	EsophagusDebugConfig config;
	float depletionRate = .05f;
	float gainRate = .05f;

	// Use this for initialization
	void Start () {
		percent = 1f;
		GameObject flaps = GameObject.Find("Flaps");
		flap = flaps.GetComponent<openFlap>();
		GameObject debugger = GameObject.Find("Debugger");
		config = debugger.GetComponent<EsophagusDebugConfig>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(config.debugActive)
		{
			depletionRate = config.oxygenDeplete;
			gainRate = config.oxygenGain;
		}
		if(flap.isEpiglotisOpen() || flap.isCough())
			percent -= depletionRate * Time.deltaTime;
		else
			percent += gainRate * Time.deltaTime;
		percent = Mathf.Clamp(percent, 0, 1f);
	}

	void OnGUI()
	{
		position.x = (2779f / 3072f) * Screen.width;
		position.y = (395f / 2304f) * Screen.height + (1f-percent) * (673f / 2304f) * Screen.height;
		originalSize.x = (190f / 3072f) * Screen.width;
		originalSize.y = (673f / 2304f) * Screen.height * percent;
		GUI.DrawTexture(new Rect(position.x, position.y, originalSize.x, originalSize.y), oxygenBar);
	}

	public float getPercent()
	{
		return percent;
	}

}
