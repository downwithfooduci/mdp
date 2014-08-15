using UnityEngine;
using System.Collections;

public class FatsTutorial : MonoBehaviour 
{
	// for zyme
	public GameObject zyme;
	private ZymePopupScript zymeScript;
	private bool showTutorial;
	public GUIStyle gotIt;
	public float maxTimeSinceStart;
	private float elapsedTimeSinceStart;

	// Use this for initialization
	void Start () 
	{
		zymeScript = ((GameObject)Instantiate(zyme)).GetComponent<ZymePopupScript> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		elapsedTimeSinceStart += Time.deltaTime;

		if (PlayerPrefs.GetInt ("SIFatsTutorial") == 1 && elapsedTimeSinceStart > maxTimeSinceStart)
		{
			showTutorial = true;
		}
	}

	void OnGUI()
	{
		gotIt.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		gotIt.fontSize = (int)(20f / 597f * Screen.height);
		gotIt.alignment = TextAnchor.MiddleCenter;

		if (showTutorial)
		{
			Instantiate(zyme);
			zymeScript.setDraw(true);
			zymeScript.setText("Fats require two \nenzymes to break down. \nTry placing a green and white tower!");
			Time.timeScale = .01f;
			
			// show zyme popup
			if (GUI.Button(new Rect(Screen.width - (.5112f * Screen.height), 
			                        (Screen.height * 0.82421875f) - (.15f * Screen.height),
			                        (.12f * Screen.width),
			                        (.1f * Screen.height)), "Got it!", gotIt))
			{
				zymeScript.setDraw(false);
				Time.timeScale = 1;
				PlayerPrefs.SetInt ("SIFatsTutorial", 0);
				PlayerPrefs.Save();
				showTutorial = false;
			}
		}
	}
}
