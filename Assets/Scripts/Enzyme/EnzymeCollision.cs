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
			Debug.Log("INSIDE");
			MeshRenderer particleRenderer = collision.collider.gameObject.GetComponentsInChildren<MeshRenderer>()[0];
			if(renderer.material.color == particleRenderer.material.color)
			{
				//split food particle
			switch(collision.gameObject.name.Replace("Clone", ""))
				{
				case "Cylinder Particle Parent":
				{
					break;
				}
				case "Cylinder Capsule Particle Parent":
				{
					break;
				}
				case "Cylinder Sphere Particle Parent":
				{
					break;
				}
				case "Sphere Particle Parent":
				{
					break;
				}
				case "Sphere Cylinder Particle Parent":
				{
					break;
				}
				case "Sphere Capsule Particle Parent":
				{
					break;
				}
				case "Capsule Particle Parent":
				{
					break;
				}
				case "Capsule Cylinder Particle Parent":
				{
					break;
				}
				case "Capsule Sphere Particle Parent":
				{
					break;
				}
				default:
					break;
				}
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
