using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TransPageSI : MonoBehaviour {
	
	public Sprite[] foodSI;
	public float frameTime;

	private Image i;
	private float timer;
	private int currentFrame;
	private bool animPlayed;
	private bool lastAnim;
	private TransPageStomach tps;

	// Use this for initialization
	void Start () {
		i = GetComponent<Image> ();
		tps = FindObjectOfType (typeof(TransPageStomach)) as TransPageStomach;

		timer = 0;
		currentFrame = 0;
		animPlayed = false;
		lastAnim = true;
	}

	// Update is called once per frame
	void Update () {

		if (tps.getPlayed() == true && lastAnim == false) {
			timer = timer + Time.deltaTime;

			if (currentFrame < foodSI.Length) {
				i.sprite = foodSI [currentFrame];
				if (timer >= frameTime) {
					timer = 0;
					currentFrame++;

				}
			} else {
				animPlayed = true;
			}
		}

	}

	public bool getPlayed(){
		return animPlayed;
	}


}
