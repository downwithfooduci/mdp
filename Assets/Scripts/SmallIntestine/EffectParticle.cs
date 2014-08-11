using UnityEngine;
using System.Collections;

public class EffectParticle : MonoBehaviour 
{
	private Vector3 desiredLocation;
	private Vector3 direction;
	private bool move = true;
	private bool moveAndDie = false;
	private float speed = Random.Range(1.0f, 2.5f);
	private float distance;
	private float distanceTravelled;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () 
	{
		if (move)	// what to do when moving on initial spawn
		{
			transform.localPosition += direction * Time.deltaTime * speed;
			distanceTravelled += Time.deltaTime * speed; 
			if (distanceTravelled * distanceTravelled >= distance)
			{
				move = false;
				distanceTravelled = 0f;
			}
		}

		if (moveAndDie)	// what to do if moving on death
		{
			transform.position += direction * Time.deltaTime * 2.0f;
			distanceTravelled += Time.deltaTime * 2.0f;
			if (distanceTravelled * distanceTravelled >= distance)
			{
				Destroy(this.gameObject);
			}
		}
	}

	// this is for moving the particles the first time, when they are spawned
	public void setDesiredLocation(Vector3 desiredLocation)
	{
		this.desiredLocation = desiredLocation;

		direction = this.desiredLocation - gameObject.transform.localPosition;
		direction = direction.normalized;

		distance = Vector3.SqrMagnitude(this.desiredLocation - gameObject.transform.localPosition); 
	}

	// this is for movingg the effect particles on absorbtion
	public IEnumerator killParticle(Vector3 desiredLocation)
	{
		if (!moveAndDie)	// only let the particles die once to avoid bouncing around
		{
			transform.parent = null;	// remove the particle from the parent
		
			this.desiredLocation = desiredLocation;

			direction = this.desiredLocation - gameObject.transform.position; 
			direction = direction.normalized;

			distance = Vector3.SqrMagnitude(this.desiredLocation - gameObject.transform.position);
			yield return distance;

			moveAndDie = true;
		}
	}

	public bool getMoveAndDie()
	{
		return moveAndDie;
	}
}
