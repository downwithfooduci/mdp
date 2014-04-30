using UnityEngine;
using System.Collections;

public class GrowAndDie : MonoBehaviour {
	float timeAlive = 0;
	Vector3 originalScale;
	public Texture plus;
	// Use this for initialization
	void Start () 
	{
		originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		timeAlive += Time.deltaTime;
		if (timeAlive < 1.0f) 
		{
			transform.localScale = originalScale + new Vector3(timeAlive, timeAlive, timeAlive);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	void OnGUI()
	{
		GUI.depth = -100;
		GUI.DrawTexture(new Rect(8.15f/10f * Screen.width, 
		                         9.55f/10f * Screen.height, 
		                         (1f + timeAlive)/80f * 3f/4f * Screen.width,
		                         (1f + timeAlive)/80f * Screen.height), plus);
		Vector3 plusPos = Camera.main.WorldToScreenPoint(transform.position);
		GUI.DrawTexture(new Rect(plusPos.x, 
		                         Screen.height - plusPos.y, 
		                         (1f + timeAlive)/60f * 3f/4f * Screen.width,
		                         (1f + timeAlive)/60f * Screen.height), plus);
	}
}
