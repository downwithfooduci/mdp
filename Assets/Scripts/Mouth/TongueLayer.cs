using UnityEngine;
using System.Collections;

public class TongueLayer : MonoBehaviour {
	public Texture[] tongue;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.depth++;
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), tongue[0]);
	}
}
