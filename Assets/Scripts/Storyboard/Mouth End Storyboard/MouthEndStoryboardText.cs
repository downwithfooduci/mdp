using UnityEngine;
using System.Collections;
using System.IO;


// all the text classes are really hacked together because they were done late at night at the last minute
// they have the text show up with the audio on the screen.
public class MouthEndStoryboardText : MonoBehaviour 
{
	MouthEndStoryboard mouthStoryboard;
	private string[] text;
	private float timer;
	
	// Use this for initialization
	void Start () 
	{
		mouthStoryboard = this.gameObject.GetComponent<MouthEndStoryboard> ();
		
		TextAsset mouthText = Resources.Load ("MouthEndText") as TextAsset;
		text = mouthText.text.Split("\n"[0]);	
		
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
	}
	
	void OnGUI()
	{
		GUI.depth--;
		
		GUIStyle statsStyle = GUI.skin.box;
		statsStyle.font = (Font)Resources.Load ("Fonts/JandaManateeSolid");
		statsStyle.normal.textColor = Color.yellow;
		statsStyle.fontSize = (int)(20f / 597f * Screen.height);
		statsStyle.wordWrap = true;
		statsStyle.alignment = TextAnchor.MiddleCenter;
		
		if (mouthStoryboard.getCurrPage() == 1)
		{
			if (timer < 8.0)
			{
				GUI.Box(new Rect(.05f*Screen.width, (625f/768f)*Screen.height, .9f*Screen.width,
				                 .15f*Screen.height), text[0], statsStyle);
			} else
			{
				GUI.Box(new Rect(.05f*Screen.width, (625f/768f)*Screen.height, .9f*Screen.width,
				                 .15f*Screen.height), text[1], statsStyle);
			}
		} 
	}
}
