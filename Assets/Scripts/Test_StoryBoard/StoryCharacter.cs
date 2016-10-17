using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class StoryCharacter : MonoBehaviour {


	public Sprite[] CharacterImages;
	public Sprite TransImage;
	public Sprite FirstImage;
	private Image image;
	private BackGroundTurner bgt;
	private bool charOn = false;
	private BoxCollider2D charBox;

	private int charTracker;

	public int pageNum;
	public bool clickable;
	public bool animated;


	public int animNums;
	public float flameTime;
	private float counter;
	private int currentAnim;
	private int currentFlame;
	private int flamePerAnim;
	private bool animPlaying;


	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
		charBox = GetComponent<BoxCollider2D> ();
		bgt = FindObjectOfType (typeof(BackGroundTurner)) as BackGroundTurner;


		charTracker = 0;
		currentAnim = 0;
		currentFlame = 0;
		animPlaying = false;

		/*
		if (bgt.CharacterPage.Length != 0) {
			CharacterImages = bgt.CharacterImage;
		}
		*/


		if (pageNum <= bgt.totalPages ()) {						//if we can find the page, add images;


		} else {

		}

	
		if (animated) {
			flamePerAnim = CharacterImages.Length / animNums;
		}



	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (bgt.currentPage() == pageNum)
			setcharOn ();
		else
			setcharOff ();
		
		if(charOn){
			//transform.position = bgt
			//image.sprite = bgt.PageList [bgt.currentPage ()].PageCharacter.charSprite[charTracker];
			if (!animated) {
				image.sprite = CharacterImages [charTracker % CharacterImages.Length];
			} else if (clickable) {
				if (charTracker == 0) {
					image.sprite = FirstImage;
				}
				else {
					image.sprite = CharacterImages [((charTracker == 0 ? 0 : ((charTracker - 1) % animNums)) * flamePerAnim + currentFlame) % CharacterImages.Length];
				}
				if (animPlaying) {
					//clickable = false;
					counter = counter + Time.deltaTime;
					if (counter >= flameTime) {
						if (currentFlame < flamePerAnim)
							currentFlame++;
						else {
							animPlaying = false;

						}
						counter = 0f;
					} else if (counter >= flameTime) {
						currentFlame++;
						counter = 0f;
					}
				}
			} else {
				image.sprite = CharacterImages [currentFlame];
				counter = counter + Time.deltaTime;
				if (counter >= flameTime) {
					currentFlame++;
					counter = 0;
					if (currentFlame == CharacterImages.Length) {
						currentFlame = 0;
					}
				}
			}


		} else {
			image.sprite = TransImage;
			counter = 0f;
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
		if (clickable && !animPlaying) {
			Debug.Log ("on mouse up");
			charTracker ++;
			Debug.Log ("Current status: " + charTracker);
			/*
			if (charTracker == 0)
				charTracker = 1;
			else
				charTracker = 0;
				*/

			if (animated) {
				currentFlame = 0;
				animPlaying = true;
			}
		}
	}


}
