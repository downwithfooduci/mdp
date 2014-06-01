using UnityEngine;
using System.Collections;

public class TongueLayer : MonoBehaviour {
	public Texture tongue;
	//MoveTongue tongueObject; // UNUSED
	//public float interval; // UNUSED

	// Use this for initialization
	void Start () 
	{
		//tongueObject = GameObject.Find("Wedge").GetComponent<MoveTongue>();  // UNUSED 
		//interval = tongueObject.getMaxMove() / tongue.Length;					// UNUSED
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.depth++;
		//Subtract .0001f just so we don't get the last index and get overflow
		//int index = (int)(tongueObject.getMoved() / interval - .0001f); // UNUSED
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), tongue);
	}
}
