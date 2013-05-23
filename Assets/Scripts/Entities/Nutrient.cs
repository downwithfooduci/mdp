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
            m_TrueColor = value;
            m_TargetColor = value;
            renderer.materials[0].color = value;
        }
    }
    private Color m_BodyColor;

    private Color m_TrueColor;
    private Color m_TargetColor;

    public IntestineGameManager Manager;

    public GameObject EffectParticle;
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

    //void Update()
    //{
    //    if (!m_BodyColor.Equals(m_TargetColor))
    //    {
    //        BodyColor = Color.Lerp()
    //    }
    //    else
    //    {
    //        BodyColor = Color.Lerp(m_BodyColor, m_TargetColor, Time.deltaTime);
    //    }

    //    if (m_BodyColor.Equals(m_TargetColor))
    //    {
    //        m_TargetColor = m_TrueColor;
    //    }
    //}
	
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
            m_TargetColor = new Color(89, 38, 38);
            manager.RemoveNutrient(this);
        }

        Manager.OnNutrientHit();
	}
	
	virtual protected void Absorb()
	{
		FoodBlob blob = m_Parent.GetComponent<FoodBlob>();
		blob.TakeHit();

        IsTargetted = false;
		
        //m_NutrientScript.SetIsDead(true);
        //m_NutrientScript.TurnToDiffuse();
        //m_NutrientScript.SetTurnBrown(true);
		//ShootOutParticles(3);
	}
	
	// Emits numParticles amount particles around this object upon
	// bullet collision
	private void ShootOutParticles(int numParticles)
	{
		GameObject particle;
		Vector3 delta = new Vector3(0, transform.localScale.y * 0.25f, 0);
		Quaternion rotation = m_Parent.transform.rotation;
		Transform effect;//To store EffectParticle
		
		for (int i = 0; i <= numParticles; i++)
		{
			particle = Instantiate(EffectParticle, transform.position + delta, rotation) as GameObject;
			particle.transform.parent = m_Parent.transform;
			particle.transform.localEulerAngles = new Vector3(0, 40 + (i * 10), 0);
			particle.particleSystem.startColor = BodyColor;
		}
	}
}
