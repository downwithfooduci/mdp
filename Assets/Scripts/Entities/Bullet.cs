using UnityEngine;
using System.Collections;

public class Bullet : MDPEntity
{
    public GameObject Target;
	public Color BulletColor;
	
	public float Velocity;

	public int targets;
	
	// Use this for initialization
	void Start () 
	{
		Collider = new CircleCollider(this);
	}
	
	// Update is called once per frame
	void Update () {
		if (Target)
		{
			transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * Velocity);
			transform.LookAt(Target.transform);
			
			CheckCollisions();
		}
		else
			Destroy(gameObject);
	}
	
	protected override void CheckCollisions ()
	{
		if (Collider.CollidesWith(Target))
		{
			Destroy(gameObject);
			Nutrient target = Target.GetComponent<Nutrient>();
			Color targetColor = target.BodyColor;
			GameObject parent = Target.transform.parent.gameObject;
			target.OnBulletCollision();
			targets--;

			Nutrient[] nutrients = parent.GetComponentsInChildren<Nutrient>();

			foreach (Nutrient nutrient in nutrients)
			{
				if (nutrient.BodyColor == targetColor && targets > 0 && !nutrient.IsTargetted)
				{
					targets--;
					nutrient.OnBulletCollision();
				}
			}
		}
	}
}
