using UnityEngine;
using System.Collections;

public class MoveFood : MonoBehaviour {
	openFlap flap;
	GameObject flaps;
	// Use this for initialization
	void Start () {
		GameObject flaps = GameObject.Find ("Flaps");
		flap = flaps.GetComponent<openFlap>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (rigidbody.velocity.x < .9f)
		{
			rigidbody.velocity += new Vector3(.9f, 0, 0);
		}
		if(flap.isCough())
		{
			rigidbody.velocity = new Vector3(-3f, rigidbody.velocity.y, rigidbody.velocity.z);
		}
		if (transform.position.y < -20)
			Destroy (gameObject);
	}
}
