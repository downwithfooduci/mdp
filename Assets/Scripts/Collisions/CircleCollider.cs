using UnityEngine;
using System.Collections;

public class CircleCollider : Collider {
	
	private GameObject m_GameObject;
	
	public CircleCollider(GameObject gameObject) 
	{
		m_GameObject = gameObject;
		
		float lengthX = m_GameObject.renderer.bounds.size.x * 0.5f;
		float lengthZ = m_GameObject.renderer.bounds.size.z * 0.5f;
		
		Properties.Radius = (lengthX > lengthZ) ? lengthX : lengthZ;
	}
	
	public override bool CollidesWith(GameObject o2)
	{
		MDPEntity entity = o2.GetComponent(typeof(MDPEntity)) as MDPEntity;
		Collider o2Collider = entity.Collider;
				
		if (o2Collider is CircleCollider)
			return CircleToCircleCollision(o2, o2Collider);
		else
			return false;
	}
	
	// Circles collide if distance between objects is less
	// than the sum of their radii
	private bool CircleToCircleCollision(GameObject o2, Collider collider)
	{
		float radiusSum = Properties.Radius + collider.Properties.Radius;
		
		float distanceSquared = MDPUtility.DistanceSquared(m_GameObject, o2);
			
		// Square root is a slow operation so square the radii instead
		return distanceSquared < radiusSum * radiusSum;
	}
}
