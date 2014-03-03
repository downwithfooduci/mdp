using UnityEngine;
using System.Collections;

public class MoveFood : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (rigidbody.velocity.x < .5f)
		{
			rigidbody.velocity += new Vector3(.5f, 0, 0);
		}
	}
}
