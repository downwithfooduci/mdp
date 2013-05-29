using Vector2 = Microsoft.Xna.Framework.FVector2;
using UnityEngine;
using System.Collections;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics.DebugViews;
using FarseerPhysics.Common;
[RequireComponent (typeof (FSBodyComponent))]

public class BouncyEnzyme : MonoBehaviour {
	bool isInvincible;
	private float lastSpawnTime;
	public float invincibilityTime;
	private TestMover[] particles;
	FSBodyComponent body;
	// Use this for initialization
	void Start () {
		isInvincible = true;
		lastSpawnTime = Time.time;
		body = GetComponent <FSBodyComponent>();
		particles = Object.FindObjectsOfType(typeof(TestMover)) as TestMover[];
		body.PhysicsBody.OnCollision+= OnCollision;
		//OnCollision(a,b,c) is an event. Above line of code delegates the below on Collision to the default physics body on collision.
		//Basically we are changing the OnCollision event.
		
	
	}
	
	//body.OnCollision += body_OnCollision;
	
	bool OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
		Debug.Log ("On Collision method is being called.");
            //if (contact.IsTouching())
			//{
                if(fixtureB.Body.UserFSBodyComponent.tag == "Particle" && fixtureB.Body.UserFSBodyComponent.renderer.material.color == renderer.material.color) //FSBodyComponent is basically Unity's component (it extends component class)
				{
					
		
					//Transform GO;
					//fixtureB.Body.GetTransform(out GO); //out means pointer instead of reference, this line of code assigns GO to the transform of fixtureB
	                    GameObject GamObj = fixtureB.Body.UserFSBodyComponent.gameObject;
						fixtureB.Body.DestroyFixture(fixtureB);
						Destroy (GamObj);
					
                }
				else if(fixtureB.Body.UserFSBodyComponent.tag == "Particle" && fixtureB.Body.UserFSBodyComponent.renderer.material.color != renderer.material.color)
				{
			      	if(!isInvincible)
					{
						GameObject GamObj = fixtureA.Body.UserFSBodyComponent.gameObject;
						fixtureA.Body.DestroyFixture(fixtureA);
						Destroy (GamObj);
		        		ObjectGenerator.EnzymesExist = false;
					}
			
				}
            //}
            return true;
        }
	
	// Update is called once per frame
	void Update ()
	{
		if(isInvincible)
		{
			if(Time.time - lastSpawnTime > invincibilityTime)
				isInvincible = false;
		}
		
	
	}
}
