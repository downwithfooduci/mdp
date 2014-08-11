using UnityEngine;
using System.Collections;

public class MouthCollision : MonoBehaviour
{

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}
	
	void OnTriggerEnter (UnityEngine.Collider other)
	{
		if (other.gameObject.transform.parent && other.gameObject.transform.parent.gameObject.name.Contains ("Particle Parent")) {
			MeshRenderer particleRenderer = other.gameObject.transform.parent.gameObject.GetComponentsInChildren<MeshRenderer> () [0];
			if (transform.parent.renderer.material.color == particleRenderer.material.color) 
			{
				//split food particle
				ParticleSplit split = other.gameObject.transform.parent.gameObject.GetComponent<ParticleSplit> ();
				split.Split ();
				// destroy old one
				Destroy (other.gameObject.transform.parent.gameObject);
			} else {
				Destroy (transform.parent.gameObject);
			}
		}
	}
}
