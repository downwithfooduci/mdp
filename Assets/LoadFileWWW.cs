using System;
using System.IO;
using UnityEngine;
using System.Collections;

public class LoadFileWWW : MonoBehaviour 
{
	public string fileName;

	private WWW w;
	private AudioSource audioSource;
	private bool loaded = false;

	// Use this for initialization
	void Start () 
	{
		//Get the attached AudioSource component
		audioSource = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!loaded && w != null && w.isDone)
		{
			Debug.Log ("w.isDone");
			loaded = true;
			audioSource.clip = w.audioClip;
			audioSource.Play ();
		}
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width/2-100, Screen.height/2+75, 200, 50), "Replay"))
		{
			w = new WWW("file:///" + Path.Combine(Application.persistentDataPath, fileName));
			loaded = false;
		}
	}
}
