using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TransPageStomach : MonoBehaviour {

	public Sprite[] foodStomach;
	public float frameTime;

	private Image i;
	private float timer;
	private int currentFrame;
	private bool animPlayed;
	private TransPageMouth tpm;

	// Use this for initialization
	void Start () {
		i = GetComponent<Image> ();
		tpm = FindObjectOfType (typeof(TransPageMouth)) as TransPageMouth;

		timer = 0;
		currentFrame = 0;
		animPlayed = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (tpm.getPlayed() == true) {
			timer = timer + Time.deltaTime;

			if (currentFrame < foodStomach.Length) {
				i.sprite = foodStomach [currentFrame];
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
