using UnityEngine;
using System.Collections;

public class TowerPlacementTutorial : MonoBehaviour 
{
	public Texture arrow;
	public Texture zyme;
	float ratio = 1.4250681198910081743869209809264f;
	public float maxArrowTime = 5.0f;

	private float actualArrowTime = 0f; // find how long the arrow has been up
	private bool stopForZyme = false;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () 
	{
		actualArrowTime += Time.deltaTime;

		if (actualArrowTime > maxArrowTime && PlayerPrefs.GetInt("SIStats_towersPlaced") == 0)
		{
			stopForZyme = true;
		}
	}

	void OnGUI()
	{
		// font
		GUIStyle style = new GUIStyle ();
		style.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		style.normal.textColor = new Color(248f/255f, 157f/255f, 48f/255f);
		style.fontSize = (int)(18f / 597f * Screen.height);
		style.wordWrap = true;

		if (PlayerPrefs.GetInt("SIStats_towersPlaced") == 0)
		{
			GUI.DrawTexture(new Rect(.25f*Screen.width, .1f*Screen.height, .3f*Screen.width, .85f*Screen.height), arrow);
		}

		if (stopForZyme)
		{
			GUI.DrawTexture(new Rect(Screen.width - (.4f * Screen.height * ratio), 
			                         (Screen.height * 0.82421875f) - (.4f * Screen.height),
			                         (.4f * Screen.height * ratio),
			                         (.4f * Screen.height)), zyme);
			GUI.Label(new Rect(.58f*Screen.width, .42f*Screen.height, .8f*Screen.width, .8f*Screen.height),
			          "Drag a Protein Tower to \nthe wall of the small \nintestine!",
			               style);
		}

		if (stopForZyme && PlayerPrefs.GetInt("SIStats_towersPlaced") == 1)
		{
			stopForZyme = false;
		}

		if (!stopForZyme && PlayerPrefs.GetInt("SIStats_towersPlaced") == 1)
		{
			GUI.DrawTexture(new Rect(.3f*Screen.width, .62f*Screen.height, .25f*Screen.width, .35f*Screen.height), arrow);
		}
	}
}
