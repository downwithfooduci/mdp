using UnityEngine;
using System.Collections;

public class UvulaEpiglottisLayer : MonoBehaviour {
	public Texture[] epiglottis, uvula;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.depth++;
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), epiglottis[0]);
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), uvula[0]);
	}
}
