using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerTutorial : MonoBehaviour 
{
	// for manging costs
	public int TOWER_BASE_COST = 20;
	public int TOWER_UPGRADE_LEVEL_1_COST = 50;
	public int TOWER_UPGRADE_LEVEL_2_COST = 50;
	
	// for sounds
	public AudioClip towerShootSound;
	public AudioClip upgradeSound;
	
	// for holding the tracker
	private GameObject statTracker;
	private TrackStatVariables trackStatVariables;
	
	public GameObject Projectile;
	
	public GameObject wall;
	
	public string ActiveModelName
	{
		get { return m_ActiveModelName; }
	}
	private string m_ActiveModelName;
	
	public float FiringRange = 100f;
	
	// Firing cooldown in seconds
	public float BaseCooldown = 2f;
	public float Level1Cooldown = 1f;
	public float Level2Cooldown = .5f;
	
	// for power towers, max blobs killed at once
	public int baseTargets = 1;
	public int level1Targets = 3;
	public int level2Targets = 6;
	
	private TowerMenu m_Menu;
	private Transform m_ActiveModel;
	
	private Color m_TargetColor;
	private NutrientManagerTutorial m_NutrientManager;
	private IntestineGameManagerTutorial m_GameManager;
	
	private float m_Cooldown;
	private int targets;
	private float m_CurrentCooldown;
	private bool m_CanFire;
	
	// Use this for initialization
	void Start () 
	{
		statTracker = GameObject.Find ("SIStatTracker(Clone)");
		trackStatVariables = statTracker.GetComponent<TrackStatVariables>();

		m_Cooldown = BaseCooldown;
		m_CurrentCooldown = m_Cooldown;
		m_CanFire = true;
		
		m_NutrientManager = GameObject.Find("managers").GetComponent<NutrientManagerTutorial>();
		m_GameManager = GameObject.Find ("managers").GetComponent<IntestineGameManagerTutorial>();
		
		m_Menu = gameObject.GetComponent<TowerMenu>();
		
		foreach (Transform child in transform)
		{
			child.localPosition = Vector3.zero;
			child.gameObject.SetActive(false);
		}
		
		SetActiveModel("Base");		
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (m_ActiveModelName)
		{
		case "Base":
			m_Cooldown = BaseCooldown;
			targets = baseTargets;
			break;
		case "Speed1":
			m_Cooldown = Level1Cooldown;
			break;
		case "Speed2":
			m_Cooldown = Level2Cooldown;
			break;
		case "Power1":
			targets = level1Targets;
			break;
		case "Power2":
			targets = level2Targets;
			break;
		default:
			break;
		}

		if (m_CanFire)
		{
			Fire();
		}
		else
		{
			m_CurrentCooldown -= Time.deltaTime;
			if (m_CurrentCooldown <= 0f)
			{
				m_CanFire = true;
				m_CurrentCooldown = m_Cooldown;
			}
		}
	}
	
	public void SetColor(Color color)
	{
		m_TargetColor = color;
		
		foreach (Transform child in transform)
		{
			Transform circle = child.FindChild("Circle");
			circle.renderer.materials[0].color = m_TargetColor;
		}
	}
	
	private void SetActiveModel(string name)
	{
		if(m_ActiveModelName != null)
			m_ActiveModel.gameObject.SetActive(false);
		
		m_ActiveModelName = name;
		m_ActiveModel = transform.FindChild(m_ActiveModelName);
		m_ActiveModel.gameObject.SetActive(true);
	}
	
	private void Fire()
	{
		NutrientTutorial target = AcquireTarget();
		if (target)
		{
			// play sound
			audio.clip = towerShootSound;
			
			// track stats
			trackStatVariables.increaseEnzymesFired();
			
			transform.Rotate(new Vector3(90,0,0), -40, Space.World);
			// Look at target but lock rotation on x axis
			float xRotation = transform.rotation.eulerAngles.x;
			transform.LookAt(target.transform);
			transform.Rotate(new Vector3(90,0,0), 40, Space.World);
			transform.FindChild(m_ActiveModelName).animation.Play("Default Take", PlayMode.StopAll);
			
			GameObject bulletObject = Instantiate(Projectile, transform.position, transform.rotation) as GameObject;
			bulletObject.renderer.material.color = m_TargetColor;
			
			BulletTutorial bullet = bulletObject.GetComponent<BulletTutorial>();
			bullet.Target = target.gameObject;
			bullet.targets = targets;
			
			target.IsTargetted = true;
			
			audio.Play ();
			
			m_CanFire = false;
		}
	}
	
	// Returns closest nutrient within range of TargetColor's type 
	// that isn't already targeted and is in direct line of sight
	// or null if there are no valid targets
	private NutrientTutorial AcquireTarget()
	{
		Debug.Log ("" + m_TargetColor);
		IList<NutrientTutorial> nutrients = m_NutrientManager.GetNutrients(m_TargetColor);

		if (nutrients == null)
		{
			return null;
		}
		
		NutrientTutorial closestNutrient = null;
		float closestDistance = float.MaxValue;
		
		foreach (NutrientTutorial e in nutrients)
		{
			if (!e.IsTargetted)
			{
				float distance = MDPUtility.DistanceSquared(gameObject, e.gameObject);

				if (distance < closestDistance && distance < FiringRange * FiringRange && IsInLineOfSight(e.transform))
				{
					closestNutrient = e;
					closestDistance = distance;
					Debug.Log ("Closest distance2: " + closestDistance);
				}
			}
		}
		
		return closestNutrient;
	}
	
	private bool IsInLineOfSight(Transform target)
	{
		Vector3 direction = (target.position - wall.transform.position).normalized;
		if (!Physics.Linecast (wall.transform.position + direction * .7f, target.position)) 
		{
			Debug.DrawLine(wall.transform.position + direction * .5f, target.position, Color.red, 5.0f);
			return true;
		}
		return false;
	}
	
	public void UpgradeSpeed()
	{
		switch (m_ActiveModelName)
		{
		case "Base":
			if (m_GameManager.nutrients - TOWER_UPGRADE_LEVEL_1_COST >= 0)  // if you have enough nutrients to upgrade
			{
				SetActiveModel("Speed1");
				m_Cooldown = Level1Cooldown;
				AdjustAnimationSpeed(m_Cooldown);
				m_GameManager.nutrients = m_GameManager.nutrients - TOWER_UPGRADE_LEVEL_1_COST;	// upgrade costs  nutrients (for test)
				
				// play sounds
				audio.clip = upgradeSound;
				audio.Play();
				
				// track stats
				trackStatVariables.increaseTowersUpgraded();
				trackStatVariables.increaseNutrientsSpent(TOWER_UPGRADE_LEVEL_1_COST);
			}
			break;
		case "Speed1":
			if (m_GameManager.nutrients - TOWER_UPGRADE_LEVEL_2_COST >= 0)  // if you have enough nutrients to upgrade
			{
				SetActiveModel("Speed2");
				m_Cooldown = Level2Cooldown;
				AdjustAnimationSpeed(m_Cooldown);
				m_GameManager.nutrients = m_GameManager.nutrients - TOWER_UPGRADE_LEVEL_2_COST;		// upgrade costs  nutrients (for test)
				
				// play sounds
				audio.clip = upgradeSound;
				audio.Play();
				
				// track stats
				trackStatVariables.increaseTowersUpgraded();
				trackStatVariables.increaseNutrientsSpent(TOWER_UPGRADE_LEVEL_2_COST);
			} 
			break;
		default:
			break;
		}
	}
	
	private void AdjustAnimationSpeed(float newCooldown)
	{
		foreach (AnimationState state in transform.FindChild(m_ActiveModelName).animation)
		{
			state.speed = BaseCooldown / newCooldown;
		}
	}
	
	public void UpgradePower()
	{
		switch (m_ActiveModelName)
		{
		case "Base":
			if (m_GameManager.nutrients - TOWER_UPGRADE_LEVEL_1_COST >= 0)  // if the upgrade is successful
			{
				SetActiveModel("Power1");
				targets = level1Targets;
				m_GameManager.nutrients = m_GameManager.nutrients - TOWER_UPGRADE_LEVEL_1_COST;		// upgrade costs nutrients (for test
				
				// play sounds
				audio.clip = upgradeSound;
				audio.Play();
				
				// track stats
				trackStatVariables.increaseTowersUpgraded();
				trackStatVariables.increaseNutrientsSpent(TOWER_UPGRADE_LEVEL_1_COST);
			} 
			break;
		case "Power1":
			if (m_GameManager.nutrients - TOWER_UPGRADE_LEVEL_2_COST >= 0) // if the upgrade is successful
			{
				SetActiveModel("Power2");
				targets = level2Targets;
				m_GameManager.nutrients = m_GameManager.nutrients - TOWER_UPGRADE_LEVEL_2_COST;		// upgrade costs  nutrients (for test
				
				// play sounds
				audio.clip = upgradeSound;
				audio.Play();
				
				// track stats
				trackStatVariables.increaseTowersUpgraded();
				trackStatVariables.increaseNutrientsSpent(TOWER_UPGRADE_LEVEL_2_COST);
			} 
			break;
		default:
			break;
		}
	}
}
