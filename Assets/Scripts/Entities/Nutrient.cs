using UnityEngine;
using System.Collections;

[RequireComponent(typeof (AudioSource))]
public class Nutrient : MDPEntity {
    public Color BodyColor
    {
        get { return m_BodyColor; }
        set
        {
            m_BodyColor = value;
            renderer.materials[0].color = value;
        }
    }
    private Color m_BodyColor;

    public IntestineGameManager Manager;

    public Transform EffectParticle;
    public bool IsTargetted;

	protected GameObject m_Parent;
	//protected NutrientScript m_NutrientScript;
	
	// Use this for initialization
	void Start () {
        Collider = new CircleCollider(this);
        IsTargetted = false;

        if (gameObject.transform.parent)
		    m_Parent = gameObject.transform.parent.gameObject;
	}
	
	public void OnBulletCollision ()
	{
		Absorb();

        NutrientManager manager = FindObjectOfType(typeof(NutrientManager)) as NutrientManager;
        if (m_BodyColor == Color.white)
        {
            manager.ChangeColor(this, Color.green);
        }
        else
        {
            manager.RemoveNutrient(this);
        }

        Manager.OnNutrientHit();
	}
	
	virtual protected void Absorb()
	{
		FoodBlob blob = m_Parent.GetComponent<FoodBlob>();
		blob.TakeHit();
		
        //m_NutrientScript.SetIsDead(true);
        //m_NutrientScript.TurnToDiffuse();
        //m_NutrientScript.SetTurnBrown(true);
		//ShootOutParticles(3);
	}
	
	// Emits numParticles amount particles around this object upon
	// bullet collision
	private void ShootOutParticles(ushort numParticles)
	{
		Transform particle;
		Vector3 delta = new Vector3(0, transform.localScale.y * 0.25f, 0);
		Quaternion rotation = m_Parent.transform.rotation;
		Transform effect;//To store EffectParticle
		
		for (int i = 0; i <= numParticles; i++)
		{
			particle = Instantiate(EffectParticle, transform.position + delta, rotation) as Transform;
			particle.parent = m_Parent.transform;
			particle.transform.localEulerAngles = new Vector3(0, 40 + (i * 10), 0);
			effect = particle.transform.Find("EffectParticle");
			
			effect.particleSystem.startColor = BodyColor;
		}
	}
}
