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
		if (move)
		{
			transform.localPosition += direction * Time.deltaTime * speed;
			distanceTravelled += Time.deltaTime * speed;
			if (distanceTravelled >= distance)
			{
				move = false;
				distanceTravelled = 0f;
			}
		}

		if (moveAndDie)
		{
			transform.position += direction * Time.deltaTime * 2.0f;
			distanceTravelled += Time.deltaTime * 2.0f;
			if (distanceTravelled >= distance)
			{
				Destroy(this.gameObject);
			}
		}
	}

	public void setDesiredLocation(Vector3 desiredLocation)
	{
		this.desiredLocation = desiredLocation;
		direction = this.desiredLocation - gameObject.transform.localPosition;
		distance = Vector3.Magnitude(this.desiredLocation - gameObject.transform.localPosition); 
		direction = direction.normalized;
	}

	public void killParticle(Vector3 desiredLocation)
	{
		if (!moveAndDie)
		{
			transform.parent = null;
			this.desiredLocation = desiredLocation;
			direction = this.desiredLocation - gameObject.transform.position;
			distance = Vector3.Magnitude(this.desiredLocation - gameObject.transform.position); 
			direction = direction.normalized;
			moveAndDie = true;
		}
	}
}
