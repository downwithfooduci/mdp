using UnityEngine;
using System.Collections;

public class ParticleSplit : MonoBehaviour 
{
	// variables for the children of a parent and to monitor if it is split
	public GameObject child1;
	public GameObject child2;
	private bool isSplit;

	// Use this for initialization
	void Start () 
	{
		isSplit = false;	// when we begin the particle will not be split
							// it will need to be split with an appropriate collision
	}
	
	// Update is called once per frame
	void Update () {}

	// function to split a particle
	public void Split()
	{
		if(!isSplit)	// first make sure it's not already split
		{
			isSplit = true;

			// cause the particles to split off from the parent
			foreach(Transform child in transform)
			{
				GameObject toCreate = child.gameObject.name == child1.gameObject.name ? child1 : child2;
				GameObject created = (GameObject)Instantiate(toCreate, 
					transform.position,
					transform.rotation);

				// assign proper color, zero the velocity, and give each split child an impulse force to start moving
				created.renderer.material.color = child.gameObject.renderer.material.color;
				created.rigidbody.velocity = Vector3.zero;
				created.rigidbody.AddForce(created.transform.right * (10 * child.position.x), ForceMode.Impulse);
			}
		}
	}
}
