using UnityEngine;
using System.Collections;

public class TowerUpgradeTutorial : MonoBehaviour 
{
	public Texture zyme;
	float ratio = 1.4250681198910081743869209809264f;
	float popUpTime = 1f;
	private IntestineGameManager m_GameManager;
	bool hasPoppedUp = false;
	bool show = false;

	// Use this for initialization
	void Start () 
	{
		m_GameManager = GameObject.Find ("Managers").GetComponent<IntestineGameManager> ();
		GameObject chooseBackground = GameObject.Find("ChooseBackground");
		SmallIntestineLoadLevelCounter  level = chooseBackground.GetComponent<SmallIntestineLoadLevelCounter>();

		if(level.getLevel() > 1)
		{
			hasPoppedUp = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!show && !hasPoppedUp && m_GameManager.nutrients >= 50)
		{
			GameObject girl = GameObject.Find("GirlTower(Clone)");
			GameObject boy =  GameObject.Find ("BoyTower(Clone)");
			if(girl != null || boy != null)
			{
				show = true;
				Time.timeScale = 0.001f;
			}
		}
		if(show && popUpTime >= 0)
		{
			popUpTime -= Time.deltaTime * 1000f;
		}
	}

	void OnGUI() {
		if(show)
			GUI.DrawTexture(new Rect(Screen.width - (.4f * Screen.height * ratio), 
		                         (Screen.height * 0.82421875f) - (.4f * Screen.height),
		                         (.4f * Screen.height * ratio),
		                         (.4f * Screen.height)), zyme);
		GUI.color = new Color(1.0f, 1.0f, 1.0f, .0f);
		if(show && popUpTime < 0 && GUI.Button (new Rect(0, 0, Screen.width, Screen.height), ""))
		{
			Time.timeScale = 1;
			hasPoppedUp = true;
			show = false;
		}
		GUI.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	}
}
