using UnityEngine;
using System.Collections;

public class moveParticle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(rigidbody.velocity.magnitude < .5)
		{
			rigidbody.velocity = new Vector3(Random.Range(-1, 2),Random.Range(-1,2),0);
		}
	
	}
	
	void OnCollisionExit(Collision collision)
	{
		if(rigidbody.velocity.magnitude < 5)
			rigidbody.velocity = 1.1f * rigidbody.velocity;
		if(collision.collider.gameObject.name.Contains("Particle Parent") && 
			collision.collider.rigidbody.velocity.magnitude < 5)
		{
			collision.collider.rigidbody.velocity = 1.1f * collision.collider.rigidbody.velocity;
		}
	}
}
