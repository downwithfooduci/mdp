using UnityEngine;
using System.Collections;

public class TongueLayer : MonoBehaviour {
	public Texture[] tongue;
	MoveTongue tongueObject;
	public float interval;
	// Use this for initialization
	void Start () {
		tongueObject = GameObject.Find("Wedge").GetComponent<MoveTongue>();
		interval = tongueObject.getMaxMove() / tongue.Length;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.depth++;
		//Subtract .0001f just so we don't get the last index and get overflow
		int index = (int)(tongueObject.getMoved() / interval - .0001f);
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), tongue[index]);
	}
}
