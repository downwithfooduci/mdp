using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {
	
	//Invulnerability Related Code
	
	
	// Use this for initialization
	TestMover p;
	public Transform[] prefab;
	public GameObject ColorPrefeb;
	public static bool EnzymesExist = false;
	private Color[] colorChoice = {Color.green, Color.white, Color.yellow, Color.blue, Color.red};
	public GUIStyle style;
	void OnGUI(){
		/*if(GUI.Button(new Rect(Screen.width - 100,Screen.height -50 ,100,40), "Generator")){
		
			p = Instantiate(prefab[Random.Range(0,3)], transform.position, transform.rotation) as TestMover;
			ObjectGenerator.particles = Object.FindObjectsOfType(typeof(Particle)) as TestMover[];
			ObjectGenerator.particles[0].renderer.material.color = Color.green;
		}*/
		//NEED TO FIX COLORING PROBLEMS
		
		string toDisplay = (90 - Time.time) + "";
		GUI.Label (new Rect(20,20,300,300), toDisplay, style);
		if(Time.time >= 90)
			Time.timeScale = 0;
		
		
		if (GUI.Button(new Rect(Screen.width - 100,Screen.height -100 ,100,40), "RedEnzyme")) {
			if(!EnzymesExist){
			 	p = Instantiate(ColorPrefeb, transform.position, transform.rotation) as TestMover;
				
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width - 100,Screen.height -150 ,100,40), "GreenEnzyme")) {
			if(!EnzymesExist){
			 	p = Instantiate(ColorPrefeb, transform.position, transform.rotation) as TestMover;
				
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width - 100,Screen.height -200 ,100,40), "BlueEnzyme")) {
			if(!EnzymesExist){
			 	p = Instantiate(ColorPrefeb, transform.position, transform.rotation) as TestMover;
		
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width - 100,Screen.height -250 ,100,40), "YellowEnzyme")) {
			if(!EnzymesExist){
			 	p = Instantiate(ColorPrefeb, transform.position, transform.rotation) as TestMover;
			
				EnzymesExist = true;
			}
		}
		
	}
}
