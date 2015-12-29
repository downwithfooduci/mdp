using UnityEngine;
using System.Collections;

public class mouseDrag : MonoBehaviour 
{
	
	private Vector3 screenPoint;
	private Vector3 offset;

	void Start(){
		Debug.Log ("start");
	}
//
//	void Update(){
//		Debug.Log ("update");
//	}
	
	void OnMouseDown(){
		Debug.Log("on mouse down");
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		Debug.Log (offset);
	}
	
	void OnMouseDrag(){
		Debug.Log ("on mouse drag");
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;
		Debug.Log (cursorPosition);
	}
	
}
