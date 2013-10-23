using UnityEngine;
using System.Collections;



public class EnzymeCollision : MonoBehaviour {
	
	GameObject gui;
	Buttons buttons;	
	
	// Use this for initialization
	void Start () {
		gui = GameObject.Find("EnzymeGUI");
		buttons = gui.GetComponent<Buttons> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log(collision.gameObject.name);
		if(collision.gameObject.name.Contains("Particle Parent"))
		{
			MeshRenderer particleRenderer = collision.collider.gameObject.GetComponentsInChildren<MeshRenderer>()[0];
			if(renderer.material.color == particleRenderer.material.color)
			{
				//split food particle
				ParticleSplit split = collision.gameObject.GetComponent<ParticleSplit>();
				Debug.Log(split);
				split.Split();
				// destroy old one
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
		buttons.killEnzyme();
	}
	 
}
