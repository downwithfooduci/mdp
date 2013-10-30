using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour
{
	
	//Invulnerability Related Code
	
	public GameObject objectGenerator;
	ParticleGenerator generator;
	// Use this for initialization
	GameObject p;
	public GameObject ColorPrefeb;
	public bool EnzymesExist = false;
	public GUIStyle style;
	
	void Start ()
	{
		generator = objectGenerator.GetComponent<ParticleGenerator> ();
	}

	void OnGUI ()
	{
		if (GUI.Button (new Rect (0, 0, 100, 40), "Return")) {
			Time.timeScale = 1;
			Application.LoadLevel ("MainMenu");
		}
		
		if (GUI.Button (new Rect (Screen.width - 100, Screen.height - 100, 100, 40), "RedEnzyme")) {
			if (!EnzymesExist) {
				p = Instantiate (ColorPrefeb, transform.position, transform.rotation) as GameObject;
				p.renderer.material.color = Color.red;
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button (new Rect (Screen.width - 100, Screen.height - 150, 100, 40), "GreenEnzyme")) {
			if (!EnzymesExist) {
				p = Instantiate (ColorPrefeb, transform.position, transform.rotation) as GameObject;
				p.renderer.material.color = Color.green;
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button (new Rect (Screen.width - 100, Screen.height - 200, 100, 40), "BlueEnzyme")) {
			if (!EnzymesExist) {
				p = Instantiate (ColorPrefeb, transform.position, transform.rotation) as GameObject;
				p.renderer.material.color = Color.blue;
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button (new Rect (Screen.width - 100, Screen.height - 250, 100, 40), "YellowEnzyme")) {
			if (!EnzymesExist) {
				p = Instantiate (ColorPrefeb, transform.position, transform.rotation) as GameObject;
				p.renderer.material.color = Color.yellow;
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button (new Rect (Screen.width - 100, Screen.height - 300, 100, 40), "WhiteEnzyme")) {
			if (!EnzymesExist) {
				p = Instantiate (ColorPrefeb, transform.position, transform.rotation) as GameObject;
				p.renderer.material.color = Color.white;
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button (new Rect (Screen.width - 100, Screen.height - 350, 100, 40), "Generate")) {
			generator.SpawnParticle();
		}
		
	}
	
	public void killEnzyme()
	{
		EnzymesExist = false;
	}
}
