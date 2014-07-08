using UnityEngine;
using System.Collections;

public class NutrientTutorial : MDPEntity 
{
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
	
	private Color m_TrueColor;
	private Color m_TargetColor;
	
	public IntestineGameManagerTutorial intestineGameManager;
	
	public GameObject EffectParticle;
	public bool IsTargetted;
	
	public bool isDead = false;
	private float elapsedTime = 0;
	
	protected GameObject m_Parent;
	
	private NutrientManagerTutorial nutrientManager;
	
	// Use this for initialization
	void Start () 
	{
		nutrientManager = FindObjectOfType(typeof(NutrientManagerTutorial)) as NutrientManagerTutorial;
		Collider = new CircleCollider(this);
		IsTargetted = false;
		
		if (gameObject.transform.parent)
			m_Parent = gameObject.transform.parent.gameObject;
	}
	
	void Update()
	{
		if(isDead && elapsedTime < 1)
		{
			elapsedTime += Time.deltaTime / 3;
			nutrientManager.ChangeColor(this, Color.Lerp(m_TrueColor, m_TargetColor, elapsedTime));
		}
	}
	
	public void OnBulletCollision ()
	{
		Absorb();
		if (m_BodyColor == Color.green)		// if the color of the nutrient was green we need to turn it white
		{
			nutrientManager.ChangeColor(this, Color.white);
			((Behaviour)gameObject.GetComponent("Halo")).enabled = true;
		}
		else
		{
			((Behaviour)gameObject.GetComponent("Halo")).enabled = false;
			isDead = true;
			m_TargetColor = new Color(92f / 255f, 64f / 255f, 51f / 255f);
			IsTargetted = true;
		}
		
		m_TrueColor = m_BodyColor;
		
		intestineGameManager.OnNutrientHit();
	}
	
	virtual protected void Absorb()
	{
		FoodBlobTutorial blob = m_Parent.GetComponent<FoodBlobTutorial>();
		blob.TakeHit();
		
		IsTargetted = false;
		
		ShootOutParticles(1);
	}
	
	// Emits numParticles amount particles around this object upon
	// bullet collision
	private void ShootOutParticles(int numParticles)
	{
		GameObject particle;
		GameObject particle2;
		Vector3 delta = new Vector3(0, transform.localScale.y * 0.25f, 0);
		Quaternion rotation = m_Parent.transform.rotation;
		Transform effect;//To store EffectParticle
		
		for (int i = 0; i < numParticles; i++)
		{
			particle = Instantiate(EffectParticle, transform.position + delta, rotation) as GameObject;
			particle.transform.parent = m_Parent.transform;
			particle.transform.localEulerAngles = new Vector3(0, 40 + (i * 10), 0);
			particle.transform.LookAt(m_Parent.transform.position + m_Parent.transform.right);
			particle.particleSystem.startColor = BodyColor;
			
			particle2 = Instantiate(EffectParticle, transform.position + delta, rotation) as GameObject;
			particle2.transform.parent = m_Parent.transform;
			particle2.transform.localEulerAngles = new Vector3(0, 40 + (i * 10), 0);
			particle2.transform.LookAt(m_Parent.transform.position - m_Parent.transform.right);
			particle2.particleSystem.startColor = BodyColor;
		}
	}
}