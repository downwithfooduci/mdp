using UnityEngine;
using System.Collections;

// for the collision with the enzyme guy's mouth (to split particle if needed)
public class MouthCollision : MonoBehaviour
{
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	// on trigger enter is triggered when a collision occurs
	void OnTriggerEnter (UnityEngine.Collider other)
	{
		// check if the object in the collision has a parent
		if (other.gameObject.transform.parent && 
		    other.gameObject.transform.parent.gameObject.name.Contains ("Particle Parent")) 
		{
			MeshRenderer particleRenderer = 
				other.gameObject.transform.parent.gameObject.GetComponentsInChildren<MeshRenderer> () [0];

			// check if the enzyme guy and the particle(s) are the same color
			if (transform.parent.renderer.material.color == particleRenderer.material.color) 
			{
				//split food particle
				ParticleSplit split = other.gameObject.transform.parent.gameObject.GetComponent<ParticleSplit> ();
				split.Split ();
				// destroy old one
				Destroy (other.gameObject.transform.parent.gameObject);
			} else 
			{
				// if they weren't the same color then destroy (kill) the enzyme guy
				Destroy (transform.parent.gameObject);
			}
		}
	}
}