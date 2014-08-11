using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour
{	
	void Start ()
	{
		Input.multiTouchEnabled = true;
		left = true;
	}
	
	Vector3 lastPosition;
	bool left;

	void Awake ()
	{}
	
	void Update ()
	{
#if UNITY_EDITOR
		GetKeyboardInput();
#endif
		if (Input.touches.Length == 2) {
			Touch finger1 = Input.touches [0];
			Touch finger2 = Input.touches [1];
			Camera camera = Camera.main;
			Vector3 finger1Pos = camera.ScreenToWorldPoint (finger1.position);
			Vector3 finger2Pos = camera.ScreenToWorldPoint (finger2.position);
			finger1Pos = new Vector3 (finger1Pos.x, finger1Pos.y, .1f);
			finger2Pos = new Vector3 (finger2Pos.x, finger2Pos.y, .1f);
	
			if (Vector3.Distance (transform.position, finger1Pos) < 10 
				&& Vector3.Distance (transform.position, finger2Pos) < 10) {
				Vector3 low = finger1Pos.y < finger2Pos.y ? finger1Pos : finger2Pos;
				Vector3 high = finger1Pos.y < finger2Pos.y ? finger2Pos : finger1Pos;
				Vector3 differenceVector = high - low;
				Vector3 crossVector = new Vector3 (0, 0, 10);
				Vector3 direction = Vector3.Cross (differenceVector, crossVector);
				Vector3 middle = low + (differenceVector / 2);
				if(middle.x - transform.position.x < -.05)
					left = true;
				else if(middle.x - transform.position.x > .05)
					left = false;
				if (!left)
					direction = direction * -1;
				transform.position = middle;
				float angle = Mathf.Rad2Deg * Mathf.Atan2 (direction.y, direction.x);
				transform.eulerAngles = new Vector3 (0, 0, angle);
			}
		}
	}
	
	void GetKeyboardInput ()
	{
		if (Input.GetKey (KeyCode.A)) {
			transform.position += new Vector3 (-.05f, 0, 0);
		} else if (Input.GetKey (KeyCode.D)) {
			transform.position += new Vector3 (.05f, 0, 0);
		}
		if (Input.GetKey (KeyCode.W)) {
			transform.position += new Vector3 (0, .05f, 0);
		} else if (Input.GetKey (KeyCode.S)) {
			transform.position += new Vector3 (0, -.05f, 0);
		}
	}

}

