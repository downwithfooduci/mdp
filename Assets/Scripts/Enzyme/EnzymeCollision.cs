using UnityEngine;
using System.Collections;

public class EnzymeCollision : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log(collision.gameObject.name);
		if(collision.gameObject.name.Contains("Particle Parent"))
		{
			Debug.Log("INSIDE");
			MeshRenderer particleRenderer = collision.collider.gameObject.GetComponentsInChildren<MeshRenderer>()[0];
			if(renderer.material.color == particleRenderer.material.color)
			{
				Destroy(collision.gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
	
	void OnDestroy()
	{
		Buttons.EnzymesExist = false;
	}
	 
}
