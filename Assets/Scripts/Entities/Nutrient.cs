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
            //m_TrueColor = value;
            //m_TargetColor = value;
            renderer.materials[0].color = value;
        }
    }
    private Color m_BodyColor;

    private Color m_TrueColor;
    private Color m_TargetColor;

    public IntestineGameManager Manager;

    public GameObject EffectParticle;
    public bool IsTargetted;
	
	public bool isDead = false;
	private float elapsedTime = 0;

	protected GameObject m_Parent;
	
	private NutrientManager manager;
	//protected NutrientScript m_NutrientScript;
	
	// Use this for initialization
	void Start () {
		manager = FindObjectOfType(typeof(NutrientManager)) as NutrientManager;
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
	
	void Update()
	{
		if(isDead && elapsedTime < 1)
		{
			elapsedTime += Time.deltaTime / 3;
			manager.ChangeColor(this, Color.Lerp(m_TrueColor, m_TargetColor, elapsedTime));
		}
	}
	
	public void OnBulletCollision ()
	{
		Absorb();

        //NutrientManager manager = FindObjectOfType(typeof(NutrientManager)) as NutrientManager;
        if (m_BodyColor == Color.green)		// if the color of the nutrient was green we need to turn it white
        {
            manager.ChangeColor(this, Color.white);
        }
        else
        {
			isDead = true;
            m_TargetColor = new Color(92f / 255f, 64f / 255f, 51f / 255f);
        //    manager.RemoveNutrient(this);
			//manager.ChangeColor(this, m_TargetColor);		// change color to brown
			IsTargetted = true;
        }
		
		m_TrueColor = m_BodyColor;

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
		ShootOutParticles(1);
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
			particle.transform.LookAt(m_Parent.transform.position + m_Parent.transform.right);
			particle.particleSystem.startColor = BodyColor;
		}
	}
}
