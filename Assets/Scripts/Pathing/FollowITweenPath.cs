using UnityEngine;
using System.Collections;

public class FollowITweenPath : MonoBehaviour {
	
	public float pathPosition;
	public float nutrientSpeed;
	private SmoothQuaternion quaternion;
	DebugConfig debugConfig;
	
	void Start() {
		quaternion = transform.rotation;
		quaternion.Duration = .5f;
		debugConfig = ((GameObject)GameObject.Find("Debug Config")).GetComponent<DebugConfig>();
	}

	void Update() {
		if(debugConfig.debugActive)
			nutrientSpeed = debugConfig.NutrientSpeed;
		Quaternion q = transform.rotation;
	 	transform.position = Spline.MoveOnPath(iTweenPath.GetPath("Path"), transform.position, ref pathPosition, ref q, nutrientSpeed,100,EasingType.Linear,false,false);
		quaternion.Value = q;
		transform.rotation = quaternion;
	}
	
}
