using System;
using System.IO;
using UnityEngine;
using System.Collections;

// sample loading an audio file using WWW
// this can be adapted to be used as needed in the story
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
			loaded = true;
			AudioClip audioTrack = w.GetAudioClip(false, true);	// must use this line for it to work on ipad
			audioSource.clip = audioTrack;
			audioSource.Play ();
		}
	}

	void OnGUI()
	{
		// when the replay button is clicked we try to load up the audio clip
		if(GUI.Button(new Rect(Screen.width/2-100, Screen.height/2+75, 200, 50), "Replay"))
		{
			string fileURL = Path.Combine(Application.persistentDataPath, fileName);
			w = new WWW("file:///" + fileURL);
			loaded = false;
		}
	}
}
