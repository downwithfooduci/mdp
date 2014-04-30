using UnityEngine;
using System.Collections;

public class EsophagusGameOver : MonoBehaviour 
{
	private bool isGameOver = false;
	public Texture gameOverPopup;
	public GUIStyle restart;
	public GUIStyle mainMenu;
	OxygenBar oxygenBar;
	
	// Use this for initialization
	void Start () 
	{
		oxygenBar = gameObject.GetComponent<OxygenBar> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (oxygenBar.getPercent() <= 0 && !isGameOver)
		{
			isGameOver = true;
			Time.timeScale = 0;
		}
	}

	void OnGUI()
	{
		if (isGameOver)
		{
			GUI.DrawTexture(new Rect(Screen.width * 0.3193359375f, 
			                         Screen.height * 0.28515625f, 
			                         Screen.width * 0.3603515625f, 
			                         Screen.height * 0.248697917f), gameOverPopup);
			
			// draw yes button
			if (GUI.Button(new Rect(Screen.width * 0.41015625f, 
			                        Screen.height * 0.41927083f,
			                        Screen.width * 0.0654296875f,
			                        Screen.height * 0.06640625f), "", restart))
			{
				Time.timeScale = 1;
				Application.LoadLevel("Esophagus");
			}
			
			// draw no button
			if (GUI.Button(new Rect(Screen.width * 0.53125f, 
			                        Screen.height * 0.41927083f,
			                        Screen.width * 0.0654296875f,
			                        Screen.height * 0.06640625f), "", mainMenu))
			{
				Time.timeScale = 1;
				Application.LoadLevel("MainMenu");
			}
		}
	}
}	