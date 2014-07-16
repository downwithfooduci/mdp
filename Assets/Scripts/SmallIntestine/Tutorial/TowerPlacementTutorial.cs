using UnityEngine;
using System.Collections;

public class TowerPlacementTutorial : MonoBehaviour 
{
	public Texture arrow;

	// for zyme
	public GameObject zyme;
	private ZymePopupScript zymeScript;

	public float maxArrowTime = 5.0f;
	private float actualArrowTime = 0f; // find how long the arrow has been up
	private bool stopForZyme = false;

	// Use this for initialization
	void Start () 
	{
		zymeScript = ((GameObject)Instantiate(zyme)).GetComponent<ZymePopupScript> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		actualArrowTime += Time.deltaTime;

		if (actualArrowTime > maxArrowTime && PlayerPrefs.GetInt("SIStats_towersPlaced") == 0)
		{
			stopForZyme = true;
		}

		if (PlayerPrefs.GetInt("SIStats_towersPlaced") == 1)
		{
			Time.timeScale = 1;
		}
	}

	void OnGUI()
	{
		if (PlayerPrefs.GetInt("SIStats_towersPlaced") == 0)
		{
			GUI.DrawTexture(new Rect(.25f*Screen.width, .1f*Screen.height, .3f*Screen.width, .85f*Screen.height), arrow);
		}

		if (stopForZyme)
		{
			zymeScript.setDraw(true);
			zymeScript.setText("Drag a Protein Tower to \nthe wall of the small \nintestine!");
			Time.timeScale = .01f;
		}

		if (stopForZyme && PlayerPrefs.GetInt("SIStats_towersPlaced") == 1)
		{
			stopForZyme = false;
			zymeScript.setDraw(false);
		}

		if (!stopForZyme && PlayerPrefs.GetInt("SIStats_towersPlaced") == 1)
		{
			GUI.DrawTexture(new Rect(.3f*Screen.width, .62f*Screen.height, .25f*Screen.width, .35f*Screen.height), arrow);
		}
	}
}
