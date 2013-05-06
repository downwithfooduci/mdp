using UnityEngine;

public static class Intersection 
{
	/*public static bool Collides(CircleCollider o1, CircleCollider o2)
	{
		float radiusSum = o1.Properties.Radius + o2.Properties.Radius;

        float distanceSquared = MDPUtility.DistanceSquared(o1.gameObject, o2.gameObject);

        // Square root is a slow operation so square the radii instead
        return distanceSquared < radiusSum * radiusSum;
	}*/
	
    public static bool CircleToCircle(MDPEntity o1, MDPEntity o2)
    {
        float radiusSum = o1.Collider.Properties.Radius + o2.Collider.Properties.Radius;

        float distanceSquared = MDPUtility.DistanceSquared(o1.gameObject, o2.gameObject);

        // Square root is a slow operation so square the radii instead
        return distanceSquared < radiusSum * radiusSum;
    }

    public static bool CircleToRect(MDPEntity circle, MDPEntity rectangle)
    {
        float circleRadius = circle.Collider.Properties.Radius;
        float rectWidth = rectangle.Collider.Properties.Width;
        float rectHeight = rectangle.Collider.Properties.Height;

        float xDistance = Mathf.Abs(circle.transform.position.x - rectangle.transform.position.x);
        float zDistance = Mathf.Abs(circle.transform.position.z - rectangle.transform.position.z);

        if (xDistance > rectWidth / 2 + circleRadius || zDistance > rectHeight / 2 + circleRadius)
        {
            return false;
        }

        if (xDistance <= rectWidth / 2 || zDistance <= rectHeight / 2)
        {
            return true;
        }

        float cornerX = xDistance - rectWidth / 2;
        float cornerZ = zDistance - rectHeight / 2;
        float cornerDistanceSquared = cornerX * cornerX + cornerZ * cornerZ;

        return cornerDistanceSquared < circleRadius * circleRadius;
    }

    public static bool RectToRect(MDPEntity o1, MDPEntity o2)
    {
        return (Mathf.Abs(o1.transform.position.x - o2.transform.position.x) * 2 < o1.Collider.Properties.Width + o2.Collider.Properties.Width) &&
            (Mathf.Abs(o1.transform.position.z - o2.transform.position.z) * 2 < o1.Collider.Properties.Height + o2.Collider.Properties.Height);
    }
}
