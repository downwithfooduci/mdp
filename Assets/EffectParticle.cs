using UnityEngine;
using System.Collections;

public class EffectParticle : MonoBehaviour 
{
	private Vector3 desiredLocation;
	private Vector3 direction;
	private bool move = true;
	float speed = Random.Range(1.0f, 2.5f);

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (move)
		{
			transform.localPosition += direction * Time.deltaTime * speed;
			if (Vector3.Magnitude(transform.localPosition - desiredLocation) <= .05)
			{
				move = false;
			}
		}
	}

	public void setDesiredLocation(Vector3 desiredLocation)
	{
		this.desiredLocation = desiredLocation;
		direction = this.desiredLocation - gameObject.transform.localPosition;
		direction = direction.normalized;
	}
}
