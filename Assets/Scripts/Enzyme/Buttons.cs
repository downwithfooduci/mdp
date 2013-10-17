using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {
	
	//Invulnerability Related Code
	
	
	// Use this for initialization
	GameObject p;
	public GameObject ColorPrefeb;
	public static bool EnzymesExist = false;
	public GUIStyle style;
	void OnGUI(){
		
		string toDisplay = (90 - Time.time) + "";
		GUI.Label (new Rect(20,20,300,300), toDisplay, style);
		if(Time.time >= 90)
			Time.timeScale = 0;
		
		if(GUI.Button(new Rect(0,0,100,40), "Return"))
		{
			Application.LoadLevel("MainMenu");
		}
		
		if (GUI.Button(new Rect(Screen.width - 100,Screen.height -100 ,100,40), "RedEnzyme")) {
			if(!EnzymesExist){
			 	p = Instantiate(ColorPrefeb, transform.position, transform.rotation) as GameObject;
				p.renderer.material.color = Color.red;
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width - 100,Screen.height -150 ,100,40), "GreenEnzyme")) {
			if(!EnzymesExist){
			 	p = Instantiate(ColorPrefeb, transform.position, transform.rotation) as GameObject;
				p.renderer.material.color = Color.green;
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width - 100,Screen.height -200 ,100,40), "BlueEnzyme")) {
			if(!EnzymesExist){
			 	p = Instantiate(ColorPrefeb, transform.position, transform.rotation) as GameObject;
				p.renderer.material.color = Color.blue;
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width - 100,Screen.height -250 ,100,40), "YellowEnzyme")) {
			if(!EnzymesExist){
			 	p = Instantiate(ColorPrefeb, transform.position, transform.rotation) as GameObject;
				p.renderer.material.color = Color.yellow;
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width - 100,Screen.height -300 ,100,40), "WhiteEnzyme")) {
			if(!EnzymesExist){
			 	p = Instantiate(ColorPrefeb, transform.position, transform.rotation) as GameObject;
				p.renderer.material.color = Color.white;
				EnzymesExist = true;
			}
		}
		
	}
}
