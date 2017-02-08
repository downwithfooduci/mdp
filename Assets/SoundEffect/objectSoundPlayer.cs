using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSoundPlayer : MonoBehaviour {

	public int pageNum;
	public bool hasSound;
	public bool soundLoop;
	public AudioClip sounds;


	private bool soundPlayed;
	private bool charOn = false;
	private BackGroundTurner bgt;


	// Use this for initialization
	void Start () {

		bgt = FindObjectOfType (typeof(BackGroundTurner)) as BackGroundTurner;

		if (hasSound) {
			soundPlayed = false;
		}


		
	}
	
	// Update is called once per frame
	void Update () {
		if (bgt.currentPage() == pageNum)
			setcharOn ();
		else
			setcharOff ();

		if (charOn && !soundPlayed) {
			GetComponent<AudioSource> ().clip = sounds;
			if (soundLoop) {
				playclip ();
				GetComponent<AudioSource> ().loop = true;
				soundPlayed = true;

			} else if (!soundLoop) {
				playclip ();
				soundPlayed = true;
			}
			
		} else {
			
		}
		
	}
	public void setcharOn(){
		charOn = true;
	}

	public void setcharOff(){
		charOn = false;
		GetComponent<AudioSource> ().Stop ();
	}
	private void playclip(){
		GetComponent<AudioSource>().Play();
		Debug.Log ("Sound Played");
	}

}
