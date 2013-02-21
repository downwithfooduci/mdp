using UnityEngine;
using System.Collections;

public class FollowITweenPath : MonoBehaviour {
	
	public float pathPosition;
	private SmoothQuaternion quaternion;
	
	void Start() {
		quaternion = transform.rotation;
		quaternion.Duration = .5f;
	}

	void Update() {
		Quaternion q = transform.rotation;
	 	transform.position = Spline.MoveOnPath(iTweenPath.GetPath("Path"), transform.position, ref pathPosition, ref q, 1f,100,EasingType.Linear,false,false);
		quaternion.Value = q;
		transform.rotation = quaternion;
	}
	
}
