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
		if(collision.gameObject.name.Contains("Particle"))
		{
			MeshRenderer particleRenderer = collision.collider.gameObject.GetComponentsInChildren<MeshRenderer>()[0];
			if(renderer.material.color != particleRenderer.material.color)
			{
				Destroy(gameObject);
			}
			else
			{
				Vector3 direction = collision.transform.position - transform.position;
				direction.Normalize();
				collision.rigidbody.velocity = direction * 10;
			}
		}
	}
	
	void OnDestroy()
	{
		buttons.killEnzyme();
	}
	 
}
