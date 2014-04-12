using UnityEngine;
using System.Collections;

public class MoveTongue : MonoBehaviour {
	public GameObject wall;
	float moved, originalHeight, maxMove, movedFrame;
	float distance;
	Plane plane;
	// Use this for initialization
	void Start () {
		originalHeight = 3.48f;
		maxMove = .4f;
		moved = 0;
		movedFrame = 0;
		plane = new Plane( new Vector3(0, 0, -1), new Vector3(0, 0, -1));
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touches.Length == 1)
		{
			Touch touch = Input.touches[0];
			Ray ray = Camera.main.ScreenPointToRay(touch.position);
			float distance;
			if (plane.Raycast(ray, out distance)){
				Vector3 vec = ray.GetPoint(distance); // get the plane point hit
				if(Vector3.Distance(vec, transform.position) < .5f)
				{

					moved = Mathf.Clamp(moved + 
					                    touch.deltaPosition.y / 20f, 0, maxMove);
					movedFrame = touch.deltaPosition.y / 20f;
				}
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
	}
}
