using UnityEngine;
using System.Collections;

public class UvulaEpiglottisLayer : MonoBehaviour {
	public Texture[] epiglottis, uvula;
	openFlap epiglottisObject;
	// Use this for initialization
	void Start () {
		epiglottisObject = GameObject.Find("Flaps").GetComponent<openFlap>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.depth++;
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height),
		                epiglottis[epiglottisObject.isEpiglotisOpen() ? 1 : 0]);
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height),
		                uvula[epiglottisObject.isEpiglotisOpen() ? 1 : 0]);
	}
}
