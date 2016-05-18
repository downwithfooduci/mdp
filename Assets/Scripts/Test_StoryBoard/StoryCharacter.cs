using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class StoryCharacter : MonoBehaviour {


	public Sprite[] CharacterImages;
	public Sprite TransImage;
	private Image image;
	private BackGroundTurner bgt;
	private bool charOn = false;
	private BoxCollider2D charBox;

	private int charTracker;


	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
		charBox = GetComponent<BoxCollider2D> ();
		bgt = FindObjectOfType (typeof(BackGroundTurner)) as BackGroundTurner;


		charTracker = 0;

		if (bgt.CharacterPage.Length != 0) {
			CharacterImages = bgt.CharacterImage;
		}

	
	}
	
	// Update is called once per frame
	void Update () {
		if(charOn){
			//transform.position = bgt
			image.sprite = bgt.PageList [bgt.currentPage ()].PageCharacter.charSprite[charTracker];
			/*
			transform.position = new Vector3 (
				bgt.PageList [bgt.currentPage ()].PageCharacter.posx,
				bgt.PageList [bgt.currentPage ()].PageCharacter.posy,0f);
				*/

		} else {
			image.sprite = TransImage;
		}
	
	}

	public void setcharOn(){
		charOn = true;
	}

	public void setcharOff(){
		charOn = false;
	}


	void OnMouseDown(){
		Debug.Log("on mouse down");
		Debug.Log ("Current Page:" + bgt.currentPage ());

	}

	void OnMouseUp(){
		Debug.Log ("on mouse up");
		if (charTracker == 0)
			charTracker = 1;
		else
			charTracker = 0;

	}


}
