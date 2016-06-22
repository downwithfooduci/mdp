using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TransPageBackground : MonoBehaviour {

	public Sprite[] BGs;
	public float frameTime;
	public int totalTimes;

	private Image i;

	private bool secLastPlayed;
	private TransPageSI tpsi;
	private TransPageStomach tps;
	//private TransPageMouth tpm;

	private int currentFrame;
	private float timer;
	private int counter;






	// Use this for initialization
	void Start () {
		i = GetComponent<Image> ();
		tpsi = FindObjectOfType (typeof(TransPageSI)) as TransPageSI;
		tps = FindObjectOfType (typeof(TransPageStomach)) as TransPageStomach;

		timer = 0;
		currentFrame = 0;
		counter = 0;

	
	}
	
	// Update is called once per frame
	void Update () {
		secLastPlayed = tps.getPlayed ();

		if (secLastPlayed) {
			timer = timer + Time.deltaTime;

			if (currentFrame < BGs.Length) {
				i.sprite = BGs [currentFrame];
				if (timer >= frameTime) {
					timer = 0;
					currentFrame++;

					counter++;

				}
			} else {
				currentFrame = 0;
				counter++;
			}

		}


		if (counter >= totalTimes*2) {
			Application.LoadLevel("LoadLevelMouth");
		}
			

	
	}
}
