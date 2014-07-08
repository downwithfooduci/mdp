using UnityEngine;
using System.Collections;

public class BulletTutorial : MDPEntity
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
			NutrientTutorial target = Target.GetComponent<NutrientTutorial>();
			Color targetColor = target.BodyColor;
			GameObject parent = Target.transform.parent.gameObject;
			target.OnBulletCollision();
			targets--;
			
			NutrientTutorial[] nutrients = parent.GetComponentsInChildren<NutrientTutorial>();
			
			foreach (NutrientTutorial nutrient in nutrients)
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
