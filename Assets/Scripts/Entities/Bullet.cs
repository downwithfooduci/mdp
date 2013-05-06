using UnityEngine;
using System.Collections;

public class Bullet : MDPEntity
{
    public GameObject Target;
	public Color BulletColor;
	
	public float Velocity;
	
	// Use this for initialization
	void Start () {
		Collider = new CircleCollider(this);
	}

    void OnDestroy()
    {
        DestroyImmediate(renderer.material);
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
	
    //void OnGUI()
    //{
    //    if (Target)
    //    {
    //        GL.PushMatrix();
    //        GL.Begin(GL.LINES);
			
    //        GL.Color(new Color(0, 0, 0, 1));
    //        GL.Vertex3(transform.position.x, transform.position.y, transform.position.z);
    //        GL.Vertex3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z);
				
    //        GL.End();
    //        GL.PopMatrix();
    //    }
    //}
	
	protected override void CheckCollisions ()
	{
		if (Collider.CollidesWith(Target))
		{
			Destroy(gameObject);

			Nutrient target = Target.GetComponent<Nutrient>();
			target.OnBulletCollision();
		}
	}
}
