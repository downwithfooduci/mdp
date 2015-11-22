using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {
	Camera camera1;
	public LayerMask touchInputMask;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++;
		}
		if (fingerCount > 0)
			Debug.Log ("User has " + fingerCount + "finger(s) touching the screen");
	}
}
