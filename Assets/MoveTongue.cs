using UnityEngine;
using System.Collections;

public class MoveTongue : MonoBehaviour {
	public GameObject wall;
	float moved, originalHeight, maxMove, movedFrame;
	// Use this for initialization
	void Start () {
		originalHeight = 3.48f;
		maxMove = .4f;
		moved = 0;
		movedFrame = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touches.Length == 1)
		{
			Touch touch = Input.touches[0];
			Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
			touchPos = new Vector3(touchPos.x, touchPos.y, transform.position.z);
			if(Vector3.Distance(touchPos, transform.position) < 1)
			{

				moved = Mathf.Clamp(moved + 
				                    touch.deltaPosition.y / 20f, 0, maxMove);
				movedFrame = touch.deltaPosition.y / 20f;
			}
		}
		if(Input.GetKey(KeyCode.S))
		{
			moved = Mathf.Clamp(moved - .4f * Time.deltaTime, 0, maxMove);
		}
		else if(Input.GetKey(KeyCode.W))
		{
			moved = Mathf.Clamp(moved + .4f * Time.deltaTime, 0, maxMove);
		}
		transform.position = new Vector3(transform.position.x, originalHeight + moved, transform.position.z);
		if(moved >= maxMove - .05f)
		{
			wall.transform.position = new Vector3(wall.transform.position.x, 0, wall.transform.position.z);
		}
		else
		{
			wall.transform.position = new Vector3(wall.transform.position.x, 3.5f, wall.transform.position.z);
		}
	}

	void OnGUI(){
		if(GUI.Button(new Rect(0,0,100,100), "Moved " + moved + "\nMovedFrame " + movedFrame))
		{
		}
	}
}
