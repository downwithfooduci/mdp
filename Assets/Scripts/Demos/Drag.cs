using Vector2 = Microsoft.Xna.Framework.FVector2;
using UnityEngine;
using System.Collections;
[RequireComponent (typeof (FSBodyComponent))]

public class Drag : MonoBehaviour {
	
	FSBodyComponent body;
	
void Start()
	{
		body = GetComponent <FSBodyComponent>();
		Input.multiTouchEnabled = true;
		
	}
	
Vector3 lastPosition;
bool left;
 

void Awake ()

{
		left = false;
   lastPosition = transform.position;

}
	
void Update()
	{
		if(lastPosition.x - transform.position.x < -.5)
			left = true;
		else if(lastPosition.x - transform.position.x > .5)
			left = false;
		Debug.Log("DELTA: " + (lastPosition.x - transform.position.x));
		Debug.Log("LEFT: " + left);
		if(Input.touches.Length == 2)
		{
			Touch finger1 = Input.touches[0];
			Touch finger2 = Input.touches[1];
			Camera camera = Camera.main;
			Vector3 finger1Pos = camera.ScreenToWorldPoint(finger1.position);
			Vector3 finger2Pos = camera.ScreenToWorldPoint(finger2.position);
			finger1Pos = new Vector3 (finger1Pos.x, finger1Pos.y, .1f);
			finger2Pos = new Vector3 (finger2Pos.x, finger2Pos.y, .1f);
			Debug.Log("Finger 1 Position: " + finger1Pos);
			Debug.Log("Finger 2 Position: " + finger2Pos);
			Debug.Log("Box Position: " + transform.position);
			Debug.Log("Distance from box F1: " + Vector3.Distance(transform.position, finger1Pos));
			Debug.Log("Distance from box F2: " + Vector3.Distance(transform.position, finger2Pos));
			
			if(Vector3.Distance(transform.position, finger1Pos) < 10 
				&& Vector3.Distance(transform.position, finger2Pos) < 10)
			{
				Vector3 low = finger1Pos.y < finger2Pos.y ? finger1Pos : finger2Pos;
				Vector3 high = finger1Pos.y < finger2Pos.y ? finger2Pos : finger1Pos;
				Vector3 differenceVector = high - low;
				Vector3 crossVector = new Vector3(0,0,10);
				Vector3 direction = Vector3.Cross(differenceVector, crossVector);
				if(left)
					direction = direction * -1;
				Debug.Log("DIRECTION: " + direction);
				Vector3 middle = low + (differenceVector / 2);
				body.PhysicsBody.Position = new Vector2(middle.x, middle.y);
				Vector3 lookAt = middle + direction;
				float angle = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x);
				body.PhysicsBody.Rotation = Mathf.Deg2Rad * angle;
				transform.eulerAngles = new Vector3(0, 0, angle);
				body.PhysicsBody.LinearVelocity = new Vector2(0,0);
			}
		}
		lastPosition = transform.position;
	}

//IEnumerator OnMouseDown () {
// 
//		
//		/*var camera = Camera.mainCamera;
//		if (camera) {
//			
//			Vector3 screenPosition = camera.WorldToScreenPoint (transform.position);		
//			
//			Vector3 mScreenPosition=new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
//			
//			Vector3 offset = transform.position - camera.ScreenToWorldPoint( mScreenPosition);
//			print ("drag starting:"+transform.name);
//			
//			//Debug.Log("Printing offset: " + offset.x);
//			 
//			
//			while (Input.GetMouseButton (0)) {
//				
//				
//				mScreenPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);			 
//				
//				transform.position=offset + camera.ScreenToWorldPoint (mScreenPosition);
//			 
//				yield return new WaitForFixedUpdate ();
//			}
//		 
//			print ("drag compeleted");
//			
//		}*/
//		var camera = Camera.mainCamera;
//		if(camera)
//		{
//		
//			Vector3 screenPosition = camera.WorldToScreenPoint (transform.position);
//			//Vector2 screenPos = new Vector2(screenPosition.x, screenPosition.y);
//			
//			Vector3 MPOSITION = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
//			//Vector2 position = new Vector2(POSITION.x, POSITION.y);
//			
//			Vector3 OFFSET = transform.position - camera.ScreenToWorldPoint (MPOSITION);
//			//Vector2 offset = new Vector2(OFFSET.x, OFFSET.y);
//			
//			while(Input.GetMouseButton (0))
//			{
//				MPOSITION = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
//				//position = new Vector2(POSITION.x, POSITION.y);
//				
//				Vector3 newPosition = OFFSET + camera.ScreenToWorldPoint (MPOSITION);
//				body.PhysicsBody.Position = new Vector2(newPosition.x, newPosition.y);
//				//body.PhysicsBody.LinearVelocity = new Vector2(0,0);
//				
//				if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved) {
//					transform.rotation = Quaternion.identity;
//					transform.Rotate (0.0f, 0.0f, 3.0f * Time.deltaTime);
//				}
//				
//				
//				//Debug.Log ("InnerLoopRunning");
//				yield return new WaitForFixedUpdate();
//			}
//			
//		}
//		
//		
//		//Debug.Log ("The Mouse Click Was Registered");
//		
//	}
//
}

