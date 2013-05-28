using Vector2 = Microsoft.Xna.Framework.FVector2;
using UnityEngine;
using System.Collections;
[RequireComponent (typeof (FSBodyComponent))]

public class Drag : MonoBehaviour {
	
	FSBodyComponent body;
	
void Start()
	{
		body = GetComponent <FSBodyComponent>();
	}
	

IEnumerator OnMouseDown () {
 
		
		/*var camera = Camera.mainCamera;
		if (camera) {
			
			Vector3 screenPosition = camera.WorldToScreenPoint (transform.position);		
			
			Vector3 mScreenPosition=new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
			
			Vector3 offset = transform.position - camera.ScreenToWorldPoint( mScreenPosition);
			print ("drag starting:"+transform.name);
			
			//Debug.Log("Printing offset: " + offset.x);
			 
			
			while (Input.GetMouseButton (0)) {
				
				
				mScreenPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);			 
				
				transform.position=offset + camera.ScreenToWorldPoint (mScreenPosition);
			 
				yield return new WaitForFixedUpdate ();
			}
		 
			print ("drag compeleted");
			
		}*/
		var camera = Camera.mainCamera;
		if(camera)
		{
		
			Vector3 screenPosition = camera.WorldToScreenPoint (transform.position);
			//Vector2 screenPos = new Vector2(screenPosition.x, screenPosition.y);
			
			Vector3 MPOSITION = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
			//Vector2 position = new Vector2(POSITION.x, POSITION.y);
			
			Vector3 OFFSET = transform.position - camera.ScreenToWorldPoint (MPOSITION);
			//Vector2 offset = new Vector2(OFFSET.x, OFFSET.y);
			
			while(Input.GetMouseButton (0))
			{
				MPOSITION = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
				//position = new Vector2(POSITION.x, POSITION.y);
				
				Vector3 newPosition = OFFSET + camera.ScreenToWorldPoint (MPOSITION);
				body.PhysicsBody.Position = new Vector2(newPosition.x, newPosition.y);
				//body.PhysicsBody.LinearVelocity = new Vector2(0,0);
				
				if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved) {
					transform.rotation = Quaternion.identity;
					transform.Rotate (0.0f, 0.0f, 3.0f * Time.deltaTime);
				}
				
				
				//Debug.Log ("InnerLoopRunning");
				yield return new WaitForFixedUpdate();
			}
			
		}
		
		
		//Debug.Log ("The Mouse Click Was Registered");
		
	}

}

