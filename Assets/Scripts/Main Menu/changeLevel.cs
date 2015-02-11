using UnityEngine;
using System.Collections;

public class changeLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void changeScene (string Level) {
		Application.LoadLevel (Level);
	}

 	public void changeSILevel (int l){
		PlayerPrefs.SetInt("DesiredSILevel", l);
		PlayerPrefs.Save();
		Application.LoadLevel("LoadLevelSmallIntestine");
	}

	public void changeMouthLevel(int l){
		PlayerPrefs.SetInt("DesiredMouthLevel", l);
		PlayerPrefs.Save();
		Application.LoadLevel("LoadLevelMouth");
	}
	
	public void skipStory(int n){
		PlayerPrefs.SetInt ("PlayedIntroStory", n);
		PlayerPrefs.SetInt ("PlayedMouthStory", n);
		PlayerPrefs.SetInt ("PlayedMouthEndStory", n);
		PlayerPrefs.SetInt ("PlayedSIStory", n);
		PlayerPrefs.Save ();
	}

	public void Reset(){
		PlayerPrefs.DeleteAll ();
	}

	public void ResetScores(){
		PlayerPrefs.DeleteKey("Mouth1");
		PlayerPrefs.DeleteKey("Mouth2");
		PlayerPrefs.DeleteKey("SI1");
		PlayerPrefs.DeleteKey("SI2");
		PlayerPrefs.DeleteKey("SI3");
		PlayerPrefs.DeleteKey("SI4");
		PlayerPrefs.DeleteKey("SI5");
		PlayerPrefs.DeleteKey("SI6");
	}

}
