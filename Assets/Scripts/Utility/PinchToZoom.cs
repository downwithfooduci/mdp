using UnityEngine;
using System.Collections;

public class PinchToZoom : MonoBehaviour {

	public int speed = 1;
	public Camera selectedCamera;
	// public float MINSCALE = 2.0f;
	// public float MAXSCALE = 5.0f;
	public float minPinchSpeed = 5.0f;
	public float varianceInDistances = 5.0f;
	private float touchDelta = 0.0f;
	private Vector2 prevDist = new Vector2(0, 0);
	private Vector2 curDist = new Vector2(0, 0);
	private float speedTouch0 = 0.0f;
	private float speedTouch1 = 0.0f;
	private int maxFOV = 60;
	private int minFOV = 1;
	private float maxMove = 5000f;
	
	// Use this for initialization
	void Start () {
		// set the camera to orthographic mode, so that we can use the fieldOfView 
		// property to create the zooming effect.
		// the initial fieldOfView setting should be chosen to show the level
		// "fully zoomed out", and can vary with the level design.
		selectedCamera.camera.orthographic = false;
		selectedCamera.camera.fieldOfView = maxFOV;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	//	transform.Rotate(0, 5*Time.deltaTime, 0);
		
		// keyboard commands to simulate zooming in and out, for testing purposes.
		// this allows us to zoom in and out without having to deploy on the device & use multitouch.
		// each press of the "I" or "O" key will zoom in / out one setp at a time.
		if (Input.GetKeyDown(KeyCode.I)) 
		{
			selectedCamera.fieldOfView = Mathf.Clamp(selectedCamera.fieldOfView - (1 + selectedCamera.fieldOfView * speed * 0.01f), minFOV, maxFOV);	
		}
		
		if (Input.GetKeyDown(KeyCode.O)) 
		{
			selectedCamera.fieldOfView = Mathf.Clamp(selectedCamera.fieldOfView + (1 + selectedCamera.fieldOfView * speed * 0.01f), minFOV, maxFOV);	
		}
		
		// check for 2 finger touch, and that both fingers have reached the "moved" touch phase
		if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved) 
		{
			curDist = Input.GetTouch(0).position - Input.GetTouch(1).position;
			// use the delta position property to determine the difference in previous finger locations
			prevDist = ((Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition) - (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition));
			touchDelta = curDist.magnitude - prevDist.magnitude;
			speedTouch0 = Input.GetTouch(0).deltaPosition.magnitude / Input.GetTouch(0).deltaTime;
			speedTouch1 = Input.GetTouch(1).deltaPosition.magnitude / Input.GetTouch(1).deltaTime;

			selectedCamera.fieldOfView = Mathf.Clamp(selectedCamera.fieldOfView + (-touchDelta * (maxFOV / maxMove) * selectedCamera.fieldOfView), minFOV, maxFOV);
		
			/* for both pinch and zoom gestures, we create the desired effect by altering the camera's FOV.
			 * we make the call to Mathf.Clamp to limit the action bounds.
			 * the speed property can be changed to affect the pinching / zooming rate.
			 * currently, a simple linear function of the current fieldOfView has been applied to smooth
			 * zooming.
			 * this means that the zoom effect is slightly faster when the field of view is larger,
			 * and slows down slightly as the field of view gets narrower.
			 */ 
			/*
			// for pinching; i.e. the touch points have moved closer together
			if ((touchDelta + varianceInDistances <= .8) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed)) {
				selectedCamera.fieldOfView = Mathf.Clamp(selectedCamera.fieldOfView + (1 + selectedCamera.fieldOfView * speed * 0.01f), minFOV, maxFOV);
			}
			// for zooming; i.e. the touch points have moved further apart
			if ((touchDelta + varianceInDistances > 1.2) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed)) {
				selectedCamera.fieldOfView = Mathf.Clamp(selectedCamera.fieldOfView - (1 + selectedCamera.fieldOfView * speed * 0.01f), minFOV, maxFOV);
			}*/
		}	
		
		// if we reach the minimum zoom, we start the game
		if (selectedCamera.fieldOfView <= minFOV)
		{
			Application.LoadLevel("loading");
		}
	}
}
