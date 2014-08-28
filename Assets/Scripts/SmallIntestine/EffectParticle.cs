using UnityEngine;
using System.Collections;

// script that handles behavior for the effect particles in the small intestine game
public class EffectParticle : MonoBehaviour 
{
	private IntestineGameManager intestineGameManager;	// to hold a reference to the intestineGameManager

	private Vector3 desiredLocation;					// to store the desired location to move an effect particle to
	private Vector3 direction;							// to store the direction to move the effect particle

	private bool move = true;							// variable to move the particle on creation
														// the value starts off as move because when an effect particle is
														// created we want it to move to the desired location immediately.
														// once it gets to the desired location "move" will be set to false

	private bool moveAndDie = false;					// variable to move the particle in the absorbtion phase
	private bool finalMove = false;						// for the final move and absorbtion into the nutrients text

	private float speed = Random.Range(1.0f, 2.5f);		// a random speed to assign to the particle on initial spawn

	private float distance;								// to store the total distance between an effect particle's 
														// starting location and where its desired location is

	private float distanceTravelled;					// to store the distance travelled by the particle

	// Use this for initialization
	void Start () 
	{
		// get a reference to the intestine game manager currently being used
		intestineGameManager = GameObject.Find ("Managers").GetComponent<IntestineGameManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (move)	// what to do when moving on initial spawn
		{
			transform.localPosition += direction * Time.deltaTime * speed;	// move the particle in the desired direction
			distanceTravelled += Time.deltaTime * speed; 					// increment the distance travelled counter
			if (distanceTravelled * distanceTravelled >= distance)			// check if the distance travelled is the desired distance
			{
				move = false;				// if it has travelled the specified distance, stop moving it
				distanceTravelled = 0f;		// reset the distance travelled variable so we can reuse it killing the particle
			}
		}

		if (moveAndDie)	// what to do if moving on death
		{
			transform.position += direction * Time.deltaTime * 2.0f;	// move the particle in the desired direction
			distanceTravelled += Time.deltaTime * 2.0f;					// increment the distance travelled counter
			if (distanceTravelled * distanceTravelled >= distance)		// check if the distance travelled is the desired distance
			{
				moveAndDie = false;										// unflag the moveanddie so we don't go in that code again
				finalMove = true;										// throw the flag that we're ready for the next block of code
				transform.position = new Vector3(-26f, 0, -13 + Random.Range(-.3f, .4f));
				desiredLocation = new Vector3(-7f, 0, transform.position.z);

				direction = desiredLocation - gameObject.transform.position;	// calculate the direction to move
				direction = direction.normalized;									// normalize the direction vector
				
				// find the distance between the particle's location and the desired location
				distance = Vector3.SqrMagnitude(this.desiredLocation - gameObject.transform.position);
				distanceTravelled = 0f;
			}
		}

		if (finalMove)
		{
			transform.position += direction * Time.deltaTime * 4.0f;	// move the particle in the desired direction
			distanceTravelled += Time.deltaTime * 4.0f; 					// increment the distance travelled counter
			if (distanceTravelled * distanceTravelled >= distance)			// check if the distance travelled is the desired distance
			{
				finalMove = false;				// if it has travelled the specified distance, stop moving it
				intestineGameManager.OnNutrientHit();		// add the score to the nutrients
				Destroy(this.gameObject);			// destroy the particle
			}
		}
	}

	// this is for moving the particles the first time, when they are spawned
	public void setDesiredLocation(Vector3 desiredLocation)
	{
		this.desiredLocation = desiredLocation;		// set the desiredLocation to the value passed in

		direction = this.desiredLocation - gameObject.transform.localPosition;	// calculate the direction to move
		direction = direction.normalized;										// normalize the direction vector

		// find the distance between the particle's location and the desired location
		distance = Vector3.SqrMagnitude(this.desiredLocation - gameObject.transform.localPosition); 
	}

	// this is for movingg the effect particles on absorbtion
	public IEnumerator killParticle(Vector3 desiredLocation)
	{
		if (!moveAndDie)	// only let the particles die once to avoid bouncing around
		{
			if (transform.parent != null)
			{
				Transform parent = transform.parent;	// find a reference to the particle's parent
				transform.parent = null;				// remove the particle from the parent
				parent.GetComponent<FoodBlobEffectParticles>().decreaseAliveChildren();	// to determine when to destroy parent
			}
		
			this.desiredLocation = desiredLocation;	// set the desiredLocation to the value passed in

			direction = this.desiredLocation - gameObject.transform.position;	// calculate the direction to move
			direction = direction.normalized;									// normalize the direction vector

			// find the distance between the particle's location and the desired location
			distance = Vector3.SqrMagnitude(this.desiredLocation - gameObject.transform.position);
			yield return distance;	// wait until the above calculation is done to save time

			moveAndDie = true;		// set the moveanddie variable to true to indicate we are ready to kill the particle
		}
	}

	// function that can be used to see if we are currently trying to kill the given effect particle
	public bool getMoveAndDie()
	{
		return moveAndDie;
	}
}
